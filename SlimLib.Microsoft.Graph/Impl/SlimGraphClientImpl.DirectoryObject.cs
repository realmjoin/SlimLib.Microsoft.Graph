using SlimLib.Auth.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;

namespace SlimLib.Microsoft.Graph
{
    partial class SlimGraphClientImpl
    {
        GraphOperation<JsonDocument?> ISlimGraphDirectoryObjectsClient.GetObjectAsync(IAzureTenant tenant, Guid objectID, ScalarRequestOptions? options, CancellationToken cancellationToken)
        {
            var link = BuildLink(options, $"directoryObjects/{objectID}");

            return new(this, tenant, HttpMethod.Get, link, options, static doc => doc);
        }

        GraphArrayOperation<JsonDocument> ISlimGraphDirectoryObjectsClient.GetObjectsAsync(IAzureTenant tenant, string type, ListRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"directoryObjects/{type}");

            return new(this, tenant, HttpMethod.Get, nextLink, options, static doc => doc);
        }

        GraphArrayOperation<Guid[]> ISlimGraphDirectoryObjectsClient.CheckMemberGroupsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> groupIDs, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberGroupsImplAsync(tenant, "directoryObjects", objectID.ToString(), groupIDs, options, cancellationToken);

        GraphArrayOperation<Guid[]> ISlimGraphDirectoryObjectsClient.GetMemberGroupsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberGroupsImplAsync(tenant, "directoryObjects", objectID.ToString(), securityEnabledOnly, options, cancellationToken);

        GraphArrayOperation<Guid[]> ISlimGraphDirectoryObjectsClient.CheckMemberObjectsAsync(IAzureTenant tenant, Guid objectID, ICollection<Guid> ids, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => CheckMemberObjectsImplAsync(tenant, "directoryObjects", objectID.ToString(), ids, options, cancellationToken);

        GraphArrayOperation<Guid[]> ISlimGraphDirectoryObjectsClient.GetMemberObjectsAsync(IAzureTenant tenant, Guid objectID, bool securityEnabledOnly, InvokeRequestOptions? options, CancellationToken cancellationToken)
            => GetMemberObjectsImplAsync(tenant, "directoryObjects", objectID.ToString(), securityEnabledOnly, options, cancellationToken);

        GraphArrayOperation<Guid[]> CheckMemberGroupsImplAsync(IAzureTenant tenant, string type, string id, ICollection<Guid> groupIDs, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/checkMemberGroups");

            var data = new JsonObject
            {
                ["groupIds"] = new JsonArray(groupIDs.Select(x => JsonValue.Create(x)).ToArray())
            };

            return new(this, tenant, HttpMethod.Post, nextLink, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc =>
            {
                using (doc)
                {
                    return [.. doc.RootElement.GetProperty("value").EnumerateArray().Select(x => x.GetGuid())];
                }
            });
        }

        GraphArrayOperation<Guid[]> GetMemberGroupsImplAsync(IAzureTenant tenant, string type, string id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/getMemberGroups");

            var data = new JsonObject
            {
               { "securityEnabledOnly", securityEnabledOnly }
            };

            return new(this, tenant, HttpMethod.Post, nextLink, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc =>
            {
                using (doc)
                {
                    return [.. doc.RootElement.GetProperty("value").EnumerateArray().Select(x => x.GetGuid())];
                }
            });
        }

        GraphArrayOperation<Guid[]> CheckMemberObjectsImplAsync(IAzureTenant tenant, string type, string id, ICollection<Guid> ids, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/checkMemberObjects");

            var data = new JsonObject
            {
                ["ids"] = new JsonArray(ids.Select(x => JsonValue.Create(x)).ToArray())
            };

            return new(this, tenant, HttpMethod.Post, nextLink, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc =>
            {
                using (doc)
                {
                    return [.. doc.RootElement.GetProperty("value").EnumerateArray().Select(x => x.GetGuid())];
                }
            });
        }

        GraphArrayOperation<Guid[]> GetMemberObjectsImplAsync(IAzureTenant tenant, string type, string id, bool securityEnabledOnly, InvokeRequestOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var nextLink = BuildLink(options, $"{type}/{id}/getMemberObjects");

            var data = new JsonObject
            {
               { "securityEnabledOnly", securityEnabledOnly }
            };

            return new(this, tenant, HttpMethod.Post, nextLink, options, JsonSerializer.SerializeToUtf8Bytes(data), static doc =>
            {
                using (doc)
                {
                    return [.. doc.RootElement.GetProperty("value").EnumerateArray().Select(x => x.GetGuid())];
                }
            });
        }
    }
}