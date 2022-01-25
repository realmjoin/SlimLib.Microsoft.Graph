namespace SlimLib.Microsoft.Graph
{
    public static class SlimGraphDirectoryRoleTemplates
    {
        // Source: https://docs.microsoft.com/en-us/answers/questions/678108/what-34b79fbf4d-3ef9-4689-8143-76b194e8550934-in-w.html
        public const string OrdinaryUserID = "b79fbf4d-3ef9-4689-8143-76b194e85509";
        public static SlimGraphDirectoryRoleTemplate OrdinaryUser { get; } = new SlimGraphDirectoryRoleTemplate(OrdinaryUserID, "Ordinary User", "");

        // Source: https://docs.microsoft.com/en-us/azure/active-directory/users-groups-roles/directory-assign-admin-roles
        // Rough formula for turning the table into code:
        // =CONCAT("public const string ",SUBSTITUTE(A1," ",""),"ID = '",LOWER(C1),"';",CHAR(13),CHAR(10),"public static SlimGraphDirectoryRoleTemplate ",SUBSTITUTE(A1," ","")," { get; } = new SlimGraphDirectoryRoleTemplate(",SUBSTITUTE(A1," ",""),"ID, '",TRIM(A1),"', '",TRIM(B1),"');",CHAR(13),CHAR(10))

        public const string ApplicationAdministratorID = "9b895d92-2cd3-44c7-9d02-a6ac2d5ea5c3";
        public static SlimGraphDirectoryRoleTemplate ApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ApplicationAdministratorID, "Application Administrator", "Can create and manage all aspects of app registrations and enterprise apps.");

        public const string ApplicationDeveloperID = "cf1c38e5-3621-4004-a7cb-879624dced7c";
        public static SlimGraphDirectoryRoleTemplate ApplicationDeveloper { get; } = new SlimGraphDirectoryRoleTemplate(ApplicationDeveloperID, "Application Developer", "Can create application registrations independent of the \"Users can register applications\" setting.");

        public const string AttackPayloadAuthorID = "9c6df0f2-1e7c-4dc3-b195-66dfbd24aa8f";
        public static SlimGraphDirectoryRoleTemplate AttackPayloadAuthor { get; } = new SlimGraphDirectoryRoleTemplate(AttackPayloadAuthorID, "Attack Payload Author", "Can create attack payloads that an administrator can initiate later.");

        public const string AttackSimulationAdministratorID = "c430b396-e693-46cc-96f3-db01bf8bb62a";
        public static SlimGraphDirectoryRoleTemplate AttackSimulationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AttackSimulationAdministratorID, "Attack Simulation Administrator", "Can create and manage all aspects of attack simulation campaigns.");

        public const string AttributeAssignmentAdministratorID = "58a13ea3-c632-46ae-9ee0-9c0d43cd7f3d";
        public static SlimGraphDirectoryRoleTemplate AttributeAssignmentAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AttributeAssignmentAdministratorID, "Attribute Assignment Administrator", "Assign custom security attribute keys and values to supported Azure AD objects.");

        public const string AttributeAssignmentReaderID = "ffd52fa5-98dc-465c-991d-fc073eb59f8f";
        public static SlimGraphDirectoryRoleTemplate AttributeAssignmentReader { get; } = new SlimGraphDirectoryRoleTemplate(AttributeAssignmentReaderID, "Attribute Assignment Reader", "Read custom security attribute keys and values for supported Azure AD objects.");

        public const string AttributeDefinitionAdministratorID = "8424c6f0-a189-499e-bbd0-26c1753c96d4";
        public static SlimGraphDirectoryRoleTemplate AttributeDefinitionAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AttributeDefinitionAdministratorID, "Attribute Definition Administrator", "Define and manage the definition of custom security attributes.");

        public const string AttributeDefinitionReaderID = "1d336d2c-4ae8-42ef-9711-b3604ce3fc2c";
        public static SlimGraphDirectoryRoleTemplate AttributeDefinitionReader { get; } = new SlimGraphDirectoryRoleTemplate(AttributeDefinitionReaderID, "Attribute Definition Reader", "Read the definition of custom security attributes.");

        public const string AuthenticationAdministratorID = "c4e39bd9-1100-46d3-8c65-fb160da0071f";
        public static SlimGraphDirectoryRoleTemplate AuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AuthenticationAdministratorID, "Authentication Administrator", "Can access to view, set and reset authentication method information for any non-admin user.");

        public const string AuthenticationPolicyAdministratorID = "0526716b-113d-4c15-b2c8-68e3c22b9f80";
        public static SlimGraphDirectoryRoleTemplate AuthenticationPolicyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AuthenticationPolicyAdministratorID, "Authentication Policy Administrator", "Can create and manage the authentication methods policy, tenant-wide MFA settings, password protection policy, and verifiable credentials.");

        public const string AzureADJoinedDeviceLocalAdministratorID = "9f06204d-73c1-4d4c-880a-6edb90606fd8";
        public static SlimGraphDirectoryRoleTemplate AzureADJoinedDeviceLocalAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AzureADJoinedDeviceLocalAdministratorID, "Azure AD Joined Device Local Administrator", "Users assigned to this role are added to the local administrators group on Azure AD-joined devices.");

        public const string AzureDevOpsAdministratorID = "e3973bdf-4987-49ae-837a-ba8e231c7286";
        public static SlimGraphDirectoryRoleTemplate AzureDevOpsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AzureDevOpsAdministratorID, "Azure DevOps Administrator", "Can manage Azure DevOps policies and settings.");

        public const string AzureInformationProtectionAdministratorID = "7495fdc4-34c4-4d15-a289-98788ce399fd";
        public static SlimGraphDirectoryRoleTemplate AzureInformationProtectionAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AzureInformationProtectionAdministratorID, "Azure Information Protection Administrator", "Can manage all aspects of the Azure Information Protection product.");

        public const string B2CIEFKeysetAdministratorID = "aaf43236-0c0d-4d5f-883a-6955382ac081";
        public static SlimGraphDirectoryRoleTemplate B2CIEFKeysetAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CIEFKeysetAdministratorID, "B2C IEF Keyset Administrator", "Can manage secrets for federation and encryption in the Identity Experience Framework (IEF).");

        public const string B2CIEFPolicyAdministratorID = "3edaf663-341e-4475-9f94-5c398ef6c070";
        public static SlimGraphDirectoryRoleTemplate B2CIEFPolicyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CIEFPolicyAdministratorID, "B2C IEF Policy Administrator", "Can create and manage trust framework policies in the Identity Experience Framework (IEF).");

        public const string BillingAdministratorID = "b0f54661-2d74-4c50-afa3-1ec803f12efe";
        public static SlimGraphDirectoryRoleTemplate BillingAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(BillingAdministratorID, "Billing Administrator", "Can perform common billing related tasks like updating payment information.");

        public const string CloudAppSecurityAdministratorID = "892c5842-a9a6-463a-8041-72aa08ca3cf6";
        public static SlimGraphDirectoryRoleTemplate CloudAppSecurityAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CloudAppSecurityAdministratorID, "Cloud App Security Administrator", "Can manage all aspects of the Cloud App Security product.");

        public const string CloudApplicationAdministratorID = "158c047a-c907-4556-b7ef-446551a6b5f7";
        public static SlimGraphDirectoryRoleTemplate CloudApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CloudApplicationAdministratorID, "Cloud Application Administrator", "Can create and manage all aspects of app registrations and enterprise apps except App Proxy.");

        public const string CloudDeviceAdministratorID = "7698a772-787b-4ac8-901f-60d6b08affd2";
        public static SlimGraphDirectoryRoleTemplate CloudDeviceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CloudDeviceAdministratorID, "Cloud Device Administrator", "Limited access to manage devices in Azure AD.");

        public const string ComplianceAdministratorID = "17315797-102d-40b4-93e0-432062caca18";
        public static SlimGraphDirectoryRoleTemplate ComplianceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ComplianceAdministratorID, "Compliance Administrator", "Can read and manage compliance configuration and reports in Azure AD and Microsoft 365.");

        public const string ComplianceDataAdministratorID = "e6d1a23a-da11-4be4-9570-befc86d067a7";
        public static SlimGraphDirectoryRoleTemplate ComplianceDataAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ComplianceDataAdministratorID, "Compliance Data Administrator", "Creates and manages compliance content.");

        public const string ConditionalAccessAdministratorID = "b1be1c3e-b65d-4f19-8427-f6fa0d97feb9";
        public static SlimGraphDirectoryRoleTemplate ConditionalAccessAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ConditionalAccessAdministratorID, "Conditional Access Administrator", "Can manage Conditional Access capabilities.");

        public const string CustomerLockBoxAccessApproverID = "5c4f9dcd-47dc-4cf7-8c9a-9e4207cbfc91";
        public static SlimGraphDirectoryRoleTemplate CustomerLockBoxAccessApprover { get; } = new SlimGraphDirectoryRoleTemplate(CustomerLockBoxAccessApproverID, "Customer LockBox Access Approver", "Can approve Microsoft support requests to access customer organizational data.");

        public const string DesktopAnalyticsAdministratorID = "38a96431-2bdf-4b4c-8b6e-5d3d8abac1a4";
        public static SlimGraphDirectoryRoleTemplate DesktopAnalyticsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(DesktopAnalyticsAdministratorID, "Desktop Analytics Administrator", "Can access and manage Desktop management tools and services.");

        public const string DirectoryReadersID = "88d8e3e3-8f55-4a1e-953a-9b9898b8876b";
        public static SlimGraphDirectoryRoleTemplate DirectoryReaders { get; } = new SlimGraphDirectoryRoleTemplate(DirectoryReadersID, "Directory Readers", "Can read basic directory information. Commonly used to grant directory read access to applications and guests.");

        public const string DirectorySynchronizationAccountsID = "d29b2b05-8046-44ba-8758-1e26182fcf32";
        public static SlimGraphDirectoryRoleTemplate DirectorySynchronizationAccounts { get; } = new SlimGraphDirectoryRoleTemplate(DirectorySynchronizationAccountsID, "Directory Synchronization Accounts", "Only used by Azure AD Connect service.");

        public const string DirectoryWritersID = "9360feb5-f418-4baa-8175-e2a00bac4301";
        public static SlimGraphDirectoryRoleTemplate DirectoryWriters { get; } = new SlimGraphDirectoryRoleTemplate(DirectoryWritersID, "Directory Writers", "Can read and write basic directory information. For granting access to applications, not intended for users.");

        public const string DomainNameAdministratorID = "8329153b-31d0-4727-b945-745eb3bc5f31";
        public static SlimGraphDirectoryRoleTemplate DomainNameAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(DomainNameAdministratorID, "Domain Name Administrator", "Can manage domain names in cloud and on-premises.");

        public const string Dynamics365AdministratorID = "44367163-eba1-44c3-98af-f5787879f96a";
        public static SlimGraphDirectoryRoleTemplate Dynamics365Administrator { get; } = new SlimGraphDirectoryRoleTemplate(Dynamics365AdministratorID, "Dynamics 365 Administrator", "Can manage all aspects of the Dynamics 365 product.");

        public const string EdgeAdministratorID = "3f1acade-1e04-4fbc-9b69-f0302cd84aef";
        public static SlimGraphDirectoryRoleTemplate EdgeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(EdgeAdministratorID, "Edge Administrator", "Manage all aspects of Microsoft Edge.");

        public const string ExchangeAdministratorID = "29232cdf-9323-42fd-ade2-1d097af3e4de";
        public static SlimGraphDirectoryRoleTemplate ExchangeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExchangeAdministratorID, "Exchange Administrator", "Can manage all aspects of the Exchange product.");

        public const string ExchangeRecipientAdministratorID = "31392ffb-586c-42d1-9346-e59415a2cc4e";
        public static SlimGraphDirectoryRoleTemplate ExchangeRecipientAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExchangeRecipientAdministratorID, "Exchange Recipient Administrator", "Can create or update Exchange Online recipients within the Exchange Online organization.");

        public const string ExternalIDUserFlowAdministratorID = "6e591065-9bad-43ed-90f3-e9424366d2f0";
        public static SlimGraphDirectoryRoleTemplate ExternalIDUserFlowAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExternalIDUserFlowAdministratorID, "External ID User Flow Administrator", "Can create and manage all aspects of user flows.");

        public const string ExternalIDUserFlowAttributeAdministratorID = "0f971eea-41eb-4569-a71e-57bb8a3eff1e";
        public static SlimGraphDirectoryRoleTemplate ExternalIDUserFlowAttributeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExternalIDUserFlowAttributeAdministratorID, "External ID User Flow Attribute Administrator", "Can create and manage the attribute schema available to all user flows.");

        public const string ExternalIdentityProviderAdministratorID = "be2f45a1-457d-42af-a067-6ec1fa63bc45";
        public static SlimGraphDirectoryRoleTemplate ExternalIdentityProviderAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExternalIdentityProviderAdministratorID, "External Identity Provider Administrator", "Can configure identity providers for use in direct federation.");

        public const string GlobalAdministratorID = "62e90394-69f5-4237-9190-012177145e10";
        public static SlimGraphDirectoryRoleTemplate GlobalAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(GlobalAdministratorID, "Global Administrator", "Can manage all aspects of Azure AD and Microsoft services that use Azure AD identities.");

        public const string GlobalReaderID = "f2ef992c-3afb-46b9-b7cf-a126ee74c451";
        public static SlimGraphDirectoryRoleTemplate GlobalReader { get; } = new SlimGraphDirectoryRoleTemplate(GlobalReaderID, "Global Reader", "Can read everything that a Global Administrator can, but not update anything.");

        public const string GroupsAdministratorID = "fdd7a751-b60b-444a-984c-02652fe8fa1c";
        public static SlimGraphDirectoryRoleTemplate GroupsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(GroupsAdministratorID, "Groups Administrator", "Members of this role can create/manage groups, create/manage groups settings like naming and expiration policies, and view groups activity and audit reports.");

        public const string GuestInviterID = "95e79109-95c0-4d8e-aee3-d01accf2d47b";
        public static SlimGraphDirectoryRoleTemplate GuestInviter { get; } = new SlimGraphDirectoryRoleTemplate(GuestInviterID, "Guest Inviter", "Can invite guest users independent of the \"members can invite guests\" setting.");

        public const string HelpdeskAdministratorID = "729827e3-9c14-49f7-bb1b-9608f156bbb8";
        public static SlimGraphDirectoryRoleTemplate HelpdeskAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(HelpdeskAdministratorID, "Helpdesk Administrator", "Can reset passwords for non-administrators and Helpdesk Administrators.");

        public const string HybridIdentityAdministratorID = "8ac3fc64-6eca-42ea-9e69-59f4c7b60eb2";
        public static SlimGraphDirectoryRoleTemplate HybridIdentityAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(HybridIdentityAdministratorID, "Hybrid Identity Administrator", "Can manage AD to Azure AD cloud provisioning, Azure AD Connect, and federation settings.");

        public const string IdentityGovernanceAdministratorID = "45d8d3c5-c802-45c6-b32a-1d70b5e1e86e";
        public static SlimGraphDirectoryRoleTemplate IdentityGovernanceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(IdentityGovernanceAdministratorID, "Identity Governance Administrator", "Manage access using Azure AD for identity governance scenarios.");

        public const string InsightsAdministratorID = "eb1f4a8d-243a-41f0-9fbd-c7cdf6c5ef7c";
        public static SlimGraphDirectoryRoleTemplate InsightsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(InsightsAdministratorID, "Insights Administrator", "Has administrative access in the Microsoft 365 Insights app.");

        public const string InsightsBusinessLeaderID = "31e939ad-9672-4796-9c2e-873181342d2d";
        public static SlimGraphDirectoryRoleTemplate InsightsBusinessLeader { get; } = new SlimGraphDirectoryRoleTemplate(InsightsBusinessLeaderID, "Insights Business Leader", "Can view and share dashboards and insights via the Microsoft 365 Insights app.");

        public const string IntuneAdministratorID = "3a2c62db-5318-420d-8d74-23affee5d9d5";
        public static SlimGraphDirectoryRoleTemplate IntuneAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(IntuneAdministratorID, "Intune Administrator", "Can manage all aspects of the Intune product.");

        public const string KaizalaAdministratorID = "74ef975b-6605-40af-a5d2-b9539d836353";
        public static SlimGraphDirectoryRoleTemplate KaizalaAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(KaizalaAdministratorID, "Kaizala Administrator", "Can manage settings for Microsoft Kaizala.");

        public const string KnowledgeAdministratorID = "b5a8dcf3-09d5-43a9-a639-8e29ef291470";
        public static SlimGraphDirectoryRoleTemplate KnowledgeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(KnowledgeAdministratorID, "Knowledge Administrator", "Can configure knowledge, learning, and other intelligent features.");

        public const string KnowledgeManagerID = "744ec460-397e-42ad-a462-8b3f9747a02c";
        public static SlimGraphDirectoryRoleTemplate KnowledgeManager { get; } = new SlimGraphDirectoryRoleTemplate(KnowledgeManagerID, "Knowledge Manager", "Can organize, create, manage, and promote topics and knowledge.");

        public const string LicenseAdministratorID = "4d6ac14f-3453-41d0-bef9-a3e0c569773a";
        public static SlimGraphDirectoryRoleTemplate LicenseAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(LicenseAdministratorID, "License Administrator", "Can manage product licenses on users and groups.");

        public const string MessageCenterPrivacyReaderID = "ac16e43d-7b2d-40e0-ac05-243ff356ab5b";
        public static SlimGraphDirectoryRoleTemplate MessageCenterPrivacyReader { get; } = new SlimGraphDirectoryRoleTemplate(MessageCenterPrivacyReaderID, "Message Center Privacy Reader", "Can read security messages and updates in Office 365 Message Center only.");

        public const string MessageCenterReaderID = "790c1fb9-7f7d-4f88-86a1-ef1f95c05c1b";
        public static SlimGraphDirectoryRoleTemplate MessageCenterReader { get; } = new SlimGraphDirectoryRoleTemplate(MessageCenterReaderID, "Message Center Reader", "Can read messages and updates for their organization in Office 365 Message Center only.");

        public const string ModernCommerceUserID = "d24aef57-1500-4070-84db-2666f29cf966";
        public static SlimGraphDirectoryRoleTemplate ModernCommerceUser { get; } = new SlimGraphDirectoryRoleTemplate(ModernCommerceUserID, "Modern Commerce User", "Can manage commercial purchases for a company, department or team.");

        public const string NetworkAdministratorID = "d37c8bed-0711-4417-ba38-b4abe66ce4c2";
        public static SlimGraphDirectoryRoleTemplate NetworkAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(NetworkAdministratorID, "Network Administrator", "Can manage network locations and review enterprise network design insights for Microsoft 365 Software as a Service applications.");

        public const string OfficeAppsAdministratorID = "2b745bdf-0803-4d80-aa65-822c4493daac";
        public static SlimGraphDirectoryRoleTemplate OfficeAppsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(OfficeAppsAdministratorID, "Office Apps Administrator", "Can manage Office apps cloud services, including policy and settings management, and manage the ability to select, unselect and publish \"what's new\" feature content to end - user's devices.");

        public const string PartnerTier1SupportID = "4ba39ca4-527c-499a-b93d-d9b492c50246";
        public static SlimGraphDirectoryRoleTemplate PartnerTier1Support { get; } = new SlimGraphDirectoryRoleTemplate(PartnerTier1SupportID, "Partner Tier1 Support", "Do not use - not intended for general use.");

        public const string PartnerTier2SupportID = "e00e864a-17c5-4a4b-9c06-f5b95a8d5bd8";
        public static SlimGraphDirectoryRoleTemplate PartnerTier2Support { get; } = new SlimGraphDirectoryRoleTemplate(PartnerTier2SupportID, "Partner Tier2 Support", "Do not use - not intended for general use.");

        public const string PasswordAdministratorID = "966707d0-3269-4727-9be2-8c3a10f19b9d";
        public static SlimGraphDirectoryRoleTemplate PasswordAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PasswordAdministratorID, "Password Administrator", "Can reset passwords for non-administrators and Password Administrators.");

        public const string PowerBIAdministratorID = "a9ea8996-122f-4c74-9520-8edcd192826c";
        public static SlimGraphDirectoryRoleTemplate PowerBIAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PowerBIAdministratorID, "Power BI Administrator", "Can manage all aspects of the Power BI product.");

        public const string PowerPlatformAdministratorID = "11648597-926c-4cf3-9c36-bcebb0ba8dcc";
        public static SlimGraphDirectoryRoleTemplate PowerPlatformAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PowerPlatformAdministratorID, "Power Platform Administrator", "Can create and manage all aspects of Microsoft Dynamics 365, Power Apps and Power Automate.");

        public const string PrinterAdministratorID = "644ef478-e28f-4e28-b9dc-3fdde9aa0b1f";
        public static SlimGraphDirectoryRoleTemplate PrinterAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PrinterAdministratorID, "Printer Administrator", "Can manage all aspects of printers and printer connectors.");

        public const string PrinterTechnicianID = "e8cef6f1-e4bd-4ea8-bc07-4b8d950f4477";
        public static SlimGraphDirectoryRoleTemplate PrinterTechnician { get; } = new SlimGraphDirectoryRoleTemplate(PrinterTechnicianID, "Printer Technician", "Can register and unregister printers and update printer status.");

        public const string PrivilegedAuthenticationAdministratorID = "7be44c8a-adaf-4e2a-84d6-ab2649e08a13";
        public static SlimGraphDirectoryRoleTemplate PrivilegedAuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PrivilegedAuthenticationAdministratorID, "Privileged Authentication Administrator", "Can access to view, set and reset authentication method information for any user (admin or non-admin).");

        public const string PrivilegedRoleAdministratorID = "e8611ab8-c189-46e8-94e1-60213ab1f814";
        public static SlimGraphDirectoryRoleTemplate PrivilegedRoleAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PrivilegedRoleAdministratorID, "Privileged Role Administrator", "Can manage role assignments in Azure AD, and all aspects of Privileged Identity Management.");

        public const string ReportsReaderID = "4a5d8f65-41da-4de4-8968-e035b65339cf";
        public static SlimGraphDirectoryRoleTemplate ReportsReader { get; } = new SlimGraphDirectoryRoleTemplate(ReportsReaderID, "Reports Reader", "Can read sign-in and audit reports.");

        public const string SearchAdministratorID = "0964bb5e-9bdb-4d7b-ac29-58e794862a40";
        public static SlimGraphDirectoryRoleTemplate SearchAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SearchAdministratorID, "Search Administrator", "Can create and manage all aspects of Microsoft Search settings.");

        public const string SearchEditorID = "8835291a-918c-4fd7-a9ce-faa49f0cf7d9";
        public static SlimGraphDirectoryRoleTemplate SearchEditor { get; } = new SlimGraphDirectoryRoleTemplate(SearchEditorID, "Search Editor", "Can create and manage the editorial content such as bookmarks, Q and As, locations, floorplan.");

        public const string SecurityAdministratorID = "194ae4cb-b126-40b2-bd5b-6091b380977d";
        public static SlimGraphDirectoryRoleTemplate SecurityAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SecurityAdministratorID, "Security Administrator", "Can read security information and reports, and manage configuration in Azure AD and Office 365.");

        public const string SecurityOperatorID = "5f2222b1-57c3-48ba-8ad5-d4759f1fde6f";
        public static SlimGraphDirectoryRoleTemplate SecurityOperator { get; } = new SlimGraphDirectoryRoleTemplate(SecurityOperatorID, "Security Operator", "Creates and manages security events.");

        public const string SecurityReaderID = "5d6b6bb7-de71-4623-b4af-96380a352509";
        public static SlimGraphDirectoryRoleTemplate SecurityReader { get; } = new SlimGraphDirectoryRoleTemplate(SecurityReaderID, "Security Reader", "Can read security information and reports in Azure AD and Office 365.");

        public const string ServiceSupportAdministratorID = "f023fd81-a637-4b56-95fd-791ac0226033";
        public static SlimGraphDirectoryRoleTemplate ServiceSupportAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ServiceSupportAdministratorID, "Service Support Administrator", "Can read service health information and manage support tickets.");

        public const string SharePointAdministratorID = "f28a1f50-f6e7-4571-818b-6a12f2af6b6c";
        public static SlimGraphDirectoryRoleTemplate SharePointAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SharePointAdministratorID, "SharePoint Administrator", "Can manage all aspects of the SharePoint service.");

        public const string SkypeforBusinessAdministratorID = "75941009-915a-4869-abe7-691bff18279e";
        public static SlimGraphDirectoryRoleTemplate SkypeforBusinessAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SkypeforBusinessAdministratorID, "Skype for Business Administrator", "Can manage all aspects of the Skype for Business product.");

        public const string TeamsAdministratorID = "69091246-20e8-4a56-aa4d-066075b2a7a8";
        public static SlimGraphDirectoryRoleTemplate TeamsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(TeamsAdministratorID, "Teams Administrator", "Can manage the Microsoft Teams service.");

        public const string TeamsCommunicationsAdministratorID = "baf37b3a-610e-45da-9e62-d9d1e5e8914b";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsAdministratorID, "Teams Communications Administrator", "Can manage calling and meetings features within the Microsoft Teams service.");

        public const string TeamsCommunicationsSupportEngineerID = "f70938a0-fc10-4177-9e90-2178f8765737";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportEngineer { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsSupportEngineerID, "Teams Communications Support Engineer", "Can troubleshoot communications issues within Teams using advanced tools.");

        public const string TeamsCommunicationsSupportSpecialistID = "fcf91098-03e3-41a9-b5ba-6f0ec8188a12";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportSpecialist { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsSupportSpecialistID, "Teams Communications Support Specialist", "Can troubleshoot communications issues within Teams using basic tools.");

        public const string TeamsDevicesAdministratorID = "3d762c5a-1b6c-493f-843e-55a3b42923d4";
        public static SlimGraphDirectoryRoleTemplate TeamsDevicesAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(TeamsDevicesAdministratorID, "Teams Devices Administrator", "Can perform management related tasks on Teams certified devices.");

        public const string UsageSummaryReportsReaderID = "75934031-6c7e-415a-99d7-48dbd49e875e";
        public static SlimGraphDirectoryRoleTemplate UsageSummaryReportsReader { get; } = new SlimGraphDirectoryRoleTemplate(UsageSummaryReportsReaderID, "Usage Summary Reports Reader", "Can see only tenant level aggregates in Microsoft 365 Usage Analytics and Productivity Score.");

        public const string UserAdministratorID = "fe930be7-5e62-47db-91af-98c3a49a38b1";
        public static SlimGraphDirectoryRoleTemplate UserAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(UserAdministratorID, "User Administrator", "Can manage all aspects of users and groups, including resetting passwords for limited admins.");

        public const string Windows365AdministratorID = "11451d60-acb2-45eb-a7d6-43d0f0125c13";
        public static SlimGraphDirectoryRoleTemplate Windows365Administrator { get; } = new SlimGraphDirectoryRoleTemplate(Windows365AdministratorID, "Windows 365 Administrator", "Can provision and manage all aspects of Cloud PCs.");

        public const string WindowsUpdateDeploymentAdministratorID = "32696413-001a-46ae-978c-ce0f6b3620d2";
        public static SlimGraphDirectoryRoleTemplate WindowsUpdateDeploymentAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(WindowsUpdateDeploymentAdministratorID, "Windows Update Deployment Administrator", "Can create and manage all aspects of Windows Update deployments through the Windows Update for Business deployment service.");



    }
}
