﻿using Microsoft.Extensions.Logging;
using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace SlimLib.Microsoft.Graph
{
    internal sealed partial class SlimGraphClientImpl : ISlimGraphAdministrativeUnitsClient, ISlimGraphApplicationsClient, ISlimGraphAuditEventsClient, ISlimGraphAuditLogsClient, ISlimGraphDeviceManagementReportsClient, ISlimGraphOrganizationsClient, ISlimGraphOrgContactsClient, ISlimGraphDevicesClient, ISlimGraphDirectoryRolesClient, ISlimGraphDetectedAppsClient, ISlimGraphMobileAppsClient, ISlimGraphManagedDevicesClient, ISlimGraphGroupsClient, ISlimGraphSubscribedSkusClient, ISlimGraphServicePrincipalsClient, ISlimGraphPrivilegedAccessClient, ISlimGraphUsersClient, ISlimGraphDeviceLocalCredentialsClient, ISlimGraphPartnerBillingReportsClient, ISlimGraphTenantRelationshipsClient
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly HttpClient httpClient;
        private readonly ILogger<SlimGraphClient> logger;

        public SlimGraphClientImpl(IAuthenticationProvider authenticationProvider, HttpClient httpClient, ILogger<SlimGraphClient> logger)
        {
            this.authenticationProvider = authenticationProvider;
            this.httpClient = httpClient;
            this.logger = logger;
        }

        internal async Task DeleteAsync(IAzureTenant tenant, string requestUri, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            using var doc = await SendAsync(tenant, HttpMethod.Delete, requestUri, null, options, null, cancellationToken).ConfigureAwait(false);
        }

        internal Task<JsonDocument?> GetAsync(IAzureTenant tenant, string requestUri, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Get, requestUri, null, options, null, cancellationToken);

        internal Task<JsonDocument?> PatchAsync(IAzureTenant tenant, string requestUri, ReadOnlyMemory<byte> utf8Data, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Patch, requestUri, utf8Data, options, null, cancellationToken);

        internal Task<JsonDocument?> PostAsync(IAzureTenant tenant, string requestUri, ReadOnlyMemory<byte> utf8Data, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => SendAsync(tenant, HttpMethod.Post, requestUri, utf8Data, options, null, cancellationToken);

        internal async IAsyncEnumerable<JsonDocument> GetArrayAsync(IAzureTenant tenant, string nextLink, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            string? link = nextLink;

            do
            {
                var doc = await GetAsync(tenant, link, options, cancellationToken).ConfigureAwait(false);

                if (doc is not null)
                {
                    HandleNextLink(doc.RootElement, ref link);
                    yield return doc;
                }

            } while (link != null);
        }

        public async Task BatchRequestAsync(IAzureTenant tenant, IList<GraphOperation> operations, CancellationToken cancellationToken)
        {
            var requests = new JsonArray();

            var payload = new JsonObject
            {
                ["requests"] = requests
            };

            var i = 0;

            foreach (var operation in operations)
            {
                var request = new JsonObject
                {
                    ["id"] = i++.ToString(),
                    ["method"] = operation.Method.ToString(),
                    ["url"] = operation.RequestUrl,
                };

                if (operation.BatchDependsOn is not null)
                {
                    request["dependsOn"] = JsonSerializer.SerializeToNode(operation.BatchDependsOn);
                }

                operation.Options?.ConfigureBatchRequest(request);

                requests.Add(request);
            }

            using var response = await PostAsync(tenant, "$batch", JsonSerializer.SerializeToUtf8Bytes(payload), options: null, cancellationToken) ?? throw new InvalidOperationException("Batch request failed.");

            if (response.RootElement.TryGetProperty("responses", out var responses) && responses is { ValueKind: JsonValueKind.Array })
            {
                for (var j = 0; j < requests.Count; j++)
                {
                    var item = responses.EnumerateArray().FirstOrDefault(x => x.TryGetProperty("id", out var id) && id.GetString() == j.ToString());

                    if (item.TryGetProperty("body", out var body))
                    {
                        operations[j].SetBatchResult(body);
                    }
                }

                return;
            }

            throw new InvalidOperationException("Batch request failed.");
        }

        private async Task<Results.Delta.DeltaResult<JsonElement>> GetDeltaAsync(IAzureTenant tenant, string nextLink, DeltaRequestOptions? options, CancellationToken cancellationToken)
        {
            var result = new List<JsonElement>();

            string? nLink = nextLink;
            string? dLink = default;

            do
            {
                using var doc = await GetAsync(tenant, nLink, options, cancellationToken).ConfigureAwait(false);

                if (doc is not null)
                {
                    if (doc.RootElement.TryGetProperty("value", out var items) && items.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in items.EnumerateArray())
                        {
                            if (cancellationToken.IsCancellationRequested)
                                break;

                            result.Add(item);
                        }
                    }

                    if (cancellationToken.IsCancellationRequested)
                        break;

                    HandleNextLink(doc.RootElement, ref nLink);
                    HandleDeltaLink(doc.RootElement, ref dLink);
                }

            } while (nLink != null);

            return new Results.Delta.DeltaResult<JsonElement>(result, dLink);
        }

        private async Task<JsonDocument?> SendAsync(IAzureTenant tenant, HttpMethod method, string requestUri, ReadOnlyMemory<byte>? utf8Data, InvokeRequestOptions? options, Func<HttpResponseMessage, Task>? httpResponseMessageCustomResponseHandler, CancellationToken cancellationToken)
        {
            using var response = await SendInternalAsync(tenant, method, requestUri, utf8Data, options, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NoContent || response.Content.Headers.ContentLength == 0)
            {
                logger.LogInformation("Got no content for HTTP request to {requestUri}.", requestUri);
                if (httpResponseMessageCustomResponseHandler != null)
                {
                    await httpResponseMessageCustomResponseHandler(response);
                }
                return null;
            }

            if (httpResponseMessageCustomResponseHandler != null)
            {
                await httpResponseMessageCustomResponseHandler(response);
            }

            using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var doc = await JsonSerializer.DeserializeAsync<JsonDocument>(content, cancellationToken: cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw HandleError(response.StatusCode, response.Headers, doc);

            if (doc is not null)
            {
                var batchErrors = HandleBatchError(response.Headers, doc);

                if (batchErrors is not null)
                    throw batchErrors;
            }

            return doc;
        }

        private async Task<SlimGraphPicture?> GetPictureAsync(IAzureTenant tenant, string requestUri, CancellationToken cancellationToken)
        {
            using var response = await SendInternalAsync(tenant, HttpMethod.Get, requestUri, null, null, cancellationToken);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                logger.LogInformation("Got no content for HTTP request to {requestUri}.", requestUri);
                return null;
            }

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            return new SlimGraphPicture(buffer, response.Content.Headers.ContentType);
        }

        private async Task<HttpResponseMessage> SendInternalAsync(IAzureTenant tenant, HttpMethod method, string requestUri, ReadOnlyMemory<byte>? utf8Data, InvokeRequestOptions? options, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(method, requestUri);

            if (utf8Data != null)
            {
                request.Content = new ReadOnlyMemoryContent(utf8Data.Value)
                {
                    Headers = { ContentType = new MediaTypeHeaderValue("application/json") { CharSet = Encoding.UTF8.WebName } }
                };
            }

            await authenticationProvider.AuthenticateRequestAsync(tenant, SlimGraphConstants.ScopeDefault, request).ConfigureAwait(false);

            options?.ConfigureHttpRequest(request);

            return await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }

        private static SlimGraphException HandleError(HttpStatusCode statusCode, HttpResponseHeaders? headers, JsonDocument? root)
        {
            try
            {
                if (root?.RootElement.TryGetProperty("error", out var error) == true)
                {
                    return new SlimGraphException(statusCode, headers, error.GetProperty("code").GetString() ?? "", error.GetProperty("message").GetString() ?? "");
                }
            }
            catch
            {
            }

            return new SlimGraphException(0, null, "Unkown error", "");
        }

        private static AggregateException? HandleBatchError(HttpResponseHeaders headers, JsonDocument root)
        {
            if (root.RootElement is not { ValueKind: JsonValueKind.Object })
                return null;

            var exceptions = new List<SlimGraphException>();

            try
            {
                if (root.RootElement.TryGetProperty("responses", out var responses) && responses is { ValueKind: JsonValueKind.Array })
                {
                    foreach (var item in responses.EnumerateArray())
                    {
                        if (item is not { ValueKind: JsonValueKind.Object })
                            continue;

                        if (item.TryGetProperty("status", out var status) && status is { ValueKind: JsonValueKind.Number })
                        {
                            var http = (HttpStatusCode)status.GetInt32();

                            if (http == HttpStatusCode.OK)
                                continue;

                            if (item.TryGetProperty("body", out var body) && body is { ValueKind: JsonValueKind.Object })
                            {
                                if (body.TryGetProperty("error", out var error))
                                {
                                    if (error is { ValueKind: JsonValueKind.Object })
                                        exceptions.Add(new(http, headers, error.GetProperty("code").GetString() ?? "", error.GetProperty("message").GetString() ?? ""));
                                    else
                                        exceptions.Add(new(http, headers, "Unkown error", ""));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }

            if (exceptions.Count == 0)
            {
                return null;
            }

            return new AggregateException(exceptions);
        }

        private static void HandleNextLink(JsonElement root, ref string? nextLink)
        {
            if (root.TryGetProperty("@odata.nextLink", out var el))
            {
                nextLink = el.GetString();
            }
            else
            {
                nextLink = null;
            }
        }

        private static void HandleDeltaLink(JsonElement root, ref string? deltaLink)
        {
            if (root.TryGetProperty("@odata.deltaLink", out var el))
            {
                deltaLink = el.GetString();
            }
            else
            {
                deltaLink = null;
            }
        }

        private static string BuildLink(ScalarRequestOptions? options, string call)
        {
            var args = new List<string>();

            if (options?.Select != null)
                args.Add("$select=" + Uri.EscapeDataString(string.Join(",", options.Select)));

            if (options?.Expand != null)
                args.Add("$expand=" + Uri.EscapeDataString(options.Expand));

            return RequestOptions.BuildLink(call, args);
        }

        private static string BuildLink(ListRequestOptions? options, string call)
        {
            var args = new List<string>();

            if (options?.Select.Count > 0)
                args.Add("$select=" + Uri.EscapeDataString(string.Join(",", options.Select)));

            if (options?.Filter != null)
                args.Add("$filter=" + Uri.EscapeDataString(options.Filter));

            if (options?.Search != null)
                args.Add("$search=" + Uri.EscapeDataString(options.Search));

            if (options?.Expand != null)
                args.Add("$expand=" + Uri.EscapeDataString(options.Expand));

            if (options?.OrderBy.Count > 0)
                args.Add("$orderby=" + Uri.EscapeDataString(string.Join(",", options.OrderBy)));

            if (options?.Count != null)
                args.Add("$count=" + (options.Count.Value ? "true" : "false"));

            if (options?.Skip != null)
                args.Add("$skip=" + options.Skip);

            if (options?.Top != null)
                args.Add("$top=" + options.Top);

            return RequestOptions.BuildLink(call, args);
        }

        private static string BuildLink(InvokeRequestOptions? options, string call)
        {
            return RequestOptions.BuildLink(call, Enumerable.Empty<string>());
        }

        private static string BuildLink(DeltaRequestOptions? options, string call)
        {
            var args = new List<string>();

            if (options?.Select != null)
                args.Add("$select=" + Uri.EscapeDataString(string.Join(",", options.Select)));

            if (options?.Filter != null)
                args.Add("$filter=" + Uri.EscapeDataString(options.Filter));

            return RequestOptions.BuildLink(call, args);
        }
    }
}