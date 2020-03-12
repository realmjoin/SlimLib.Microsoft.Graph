namespace SlimGraph
{
    public static class SlimGraphDirectoryRoleTemplates
    {
        // Source: https://docs.microsoft.com/en-us/azure/active-directory/users-groups-roles/directory-assign-admin-roles
        // Formula: =CONCAT("public const string ",SUBSTITUTE(A2," ",""),"ID = '",LOWER(C2),"';",CHAR(13),CHAR(10),"public static SlimGraphDirectoryRoleTemplate ",SUBSTITUTE(A2," ","")," { get; } = new SlimGraphDirectoryRoleTemplate(",SUBSTITUTE(A2," ",""),"ID, '",TRIM(A2),"', '",TRIM(B2),"');",CHAR(13),CHAR(10))

        public const string ApplicationAdministratorID = "9b895d92-2cd3-44c7-9d02-a6ac2d5ea5c3";
        public static SlimGraphDirectoryRoleTemplate ApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ApplicationAdministratorID, "Application Administrator", "Application administrator");

        public const string ApplicationDeveloperID = "cf1c38e5-3621-4004-a7cb-879624dced7c";
        public static SlimGraphDirectoryRoleTemplate ApplicationDeveloper { get; } = new SlimGraphDirectoryRoleTemplate(ApplicationDeveloperID, "Application Developer", "Application developer");

        public const string AuthenticationAdministratorID = "c4e39bd9-1100-46d3-8c65-fb160da0071f";
        public static SlimGraphDirectoryRoleTemplate AuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AuthenticationAdministratorID, "Authentication Administrator", "Authentication administrator");

        public const string AzureDevOpsAdministratorID = "e3973bdf-4987-49ae-837a-ba8e231c7286";
        public static SlimGraphDirectoryRoleTemplate AzureDevOpsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AzureDevOpsAdministratorID, "Azure DevOps Administrator", "Azure DevOps administrator");

        public const string AzureInformationProtectionAdministratorID = "7495fdc4-34c4-4d15-a289-98788ce399fd";
        public static SlimGraphDirectoryRoleTemplate AzureInformationProtectionAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(AzureInformationProtectionAdministratorID, "Azure Information Protection Administrator", "Azure Information Protection administrator");

        public const string B2CUserflowAdministratorID = "6e591065-9bad-43ed-90f3-e9424366d2f0";
        public static SlimGraphDirectoryRoleTemplate B2CUserflowAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CUserflowAdministratorID, "B2C User flow Administrator", "B2C User flow Administrator");

        public const string B2CUserFlowAttributeAdministratorID = "0f971eea-41eb-4569-a71e-57bb8a3eff1e";
        public static SlimGraphDirectoryRoleTemplate B2CUserFlowAttributeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CUserFlowAttributeAdministratorID, "B2C User Flow Attribute Administrator", "B2C User Flow Attribute Administrator");

        public const string B2CIEFKeysetAdministratorID = "aaf43236-0c0d-4d5f-883a-6955382ac081";
        public static SlimGraphDirectoryRoleTemplate B2CIEFKeysetAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CIEFKeysetAdministratorID, "B2C IEF Keyset Administrator", "B2C IEF Keyset Administrator");

        public const string B2CIEFPolicyAdministratorID = "3edaf663-341e-4475-9f94-5c398ef6c070";
        public static SlimGraphDirectoryRoleTemplate B2CIEFPolicyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(B2CIEFPolicyAdministratorID, "B2C IEF Policy Administrator", "B2C IEF Policy Administrator");

        public const string BillingAdministratorID = "b0f54661-2d74-4c50-afa3-1ec803f12efe";
        public static SlimGraphDirectoryRoleTemplate BillingAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(BillingAdministratorID, "Billing Administrator", "Billing administrator");

        public const string CloudApplicationAdministratorID = "158c047a-c907-4556-b7ef-446551a6b5f7";
        public static SlimGraphDirectoryRoleTemplate CloudApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CloudApplicationAdministratorID, "Cloud Application Administrator", "Cloud application administrator");

        public const string CloudDeviceAdministratorID = "7698a772-787b-4ac8-901f-60d6b08affd2";
        public static SlimGraphDirectoryRoleTemplate CloudDeviceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CloudDeviceAdministratorID, "Cloud Device Administrator", "Cloud device administrator");

        public const string CompanyAdministratorID = "62e90394-69f5-4237-9190-012177145e10";
        public static SlimGraphDirectoryRoleTemplate CompanyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CompanyAdministratorID, "Company Administrator", "Global administrator");

        public const string ComplianceAdministratorID = "17315797-102d-40b4-93e0-432062caca18";
        public static SlimGraphDirectoryRoleTemplate ComplianceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ComplianceAdministratorID, "Compliance Administrator", "Compliance administrator");

        public const string ComplianceDataAdministratorID = "e6d1a23a-da11-4be4-9570-befc86d067a7";
        public static SlimGraphDirectoryRoleTemplate ComplianceDataAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ComplianceDataAdministratorID, "Compliance Data Administrator", "Compliance data administrator");

        public const string ConditionalAccessAdministratorID = "b1be1c3e-b65d-4f19-8427-f6fa0d97feb9";
        public static SlimGraphDirectoryRoleTemplate ConditionalAccessAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ConditionalAccessAdministratorID, "Conditional Access Administrator", "Conditional Access administrator");

        public const string CRMServiceAdministratorID = "44367163-eba1-44c3-98af-f5787879f96a";
        public static SlimGraphDirectoryRoleTemplate CRMServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(CRMServiceAdministratorID, "CRM Service Administrator", "Dynamics 365 administrator");

        public const string CustomerLockBoxAccessApproverID = "5c4f9dcd-47dc-4cf7-8c9a-9e4207cbfc91";
        public static SlimGraphDirectoryRoleTemplate CustomerLockBoxAccessApprover { get; } = new SlimGraphDirectoryRoleTemplate(CustomerLockBoxAccessApproverID, "Customer LockBox Access Approver", "Customer Lockbox access approver");

        public const string DesktopAnalyticsAdministratorID = "38a96431-2bdf-4b4c-8b6e-5d3d8abac1a4";
        public static SlimGraphDirectoryRoleTemplate DesktopAnalyticsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(DesktopAnalyticsAdministratorID, "Desktop Analytics Administrator", "Desktop Analytics Administrator");

        public const string DeviceAdministratorsID = "9f06204d-73c1-4d4c-880a-6edb90606fd8";
        public static SlimGraphDirectoryRoleTemplate DeviceAdministrators { get; } = new SlimGraphDirectoryRoleTemplate(DeviceAdministratorsID, "Device Administrators", "Device administrators");

        public const string DeviceJoinID = "9c094953-4995-41c8-84c8-3ebb9b32c93f";
        public static SlimGraphDirectoryRoleTemplate DeviceJoin { get; } = new SlimGraphDirectoryRoleTemplate(DeviceJoinID, "Device Join", "Device join");

        public const string DeviceManagersID = "2b499bcd-da44-4968-8aec-78e1674fa64d";
        public static SlimGraphDirectoryRoleTemplate DeviceManagers { get; } = new SlimGraphDirectoryRoleTemplate(DeviceManagersID, "Device Managers", "Device managers");

        public const string DeviceUsersID = "d405c6df-0af8-4e3b-95e4-4d06e542189e";
        public static SlimGraphDirectoryRoleTemplate DeviceUsers { get; } = new SlimGraphDirectoryRoleTemplate(DeviceUsersID, "Device Users", "Device users");

        public const string DirectoryReadersID = "88d8e3e3-8f55-4a1e-953a-9b9898b8876b";
        public static SlimGraphDirectoryRoleTemplate DirectoryReaders { get; } = new SlimGraphDirectoryRoleTemplate(DirectoryReadersID, "Directory Readers", "Directory readers");

        public const string DirectorySynchronizationAccountsID = "d29b2b05-8046-44ba-8758-1e26182fcf32";
        public static SlimGraphDirectoryRoleTemplate DirectorySynchronizationAccounts { get; } = new SlimGraphDirectoryRoleTemplate(DirectorySynchronizationAccountsID, "Directory Synchronization Accounts", "Directory synchronization accounts");

        public const string DirectoryWritersID = "9360feb5-f418-4baa-8175-e2a00bac4301";
        public static SlimGraphDirectoryRoleTemplate DirectoryWriters { get; } = new SlimGraphDirectoryRoleTemplate(DirectoryWritersID, "Directory Writers", "Directory writers");

        public const string ExchangeServiceAdministratorID = "29232cdf-9323-42fd-ade2-1d097af3e4de";
        public static SlimGraphDirectoryRoleTemplate ExchangeServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExchangeServiceAdministratorID, "Exchange Service Administrator", "Exchange administrator");

        public const string ExternalIdentityProviderAdministratorID = "be2f45a1-457d-42af-a067-6ec1fa63bc45";
        public static SlimGraphDirectoryRoleTemplate ExternalIdentityProviderAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ExternalIdentityProviderAdministratorID, "External Identity Provider Administrator", "External Identity Provider Administrator");

        public const string GlobalReaderID = "f2ef992c-3afb-46b9-b7cf-a126ee74c451";
        public static SlimGraphDirectoryRoleTemplate GlobalReader { get; } = new SlimGraphDirectoryRoleTemplate(GlobalReaderID, "Global Reader", "Global reader");

        public const string GroupsAdministratorID = "fdd7a751-b60b-444a-984c-02652fe8fa1c";
        public static SlimGraphDirectoryRoleTemplate GroupsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(GroupsAdministratorID, "Groups Administrator", "Groups administrator");

        public const string GuestInviterID = "95e79109-95c0-4d8e-aee3-d01accf2d47b";
        public static SlimGraphDirectoryRoleTemplate GuestInviter { get; } = new SlimGraphDirectoryRoleTemplate(GuestInviterID, "Guest Inviter", "Guest inviter");

        public const string HelpdeskAdministratorID = "729827e3-9c14-49f7-bb1b-9608f156bbb8";
        public static SlimGraphDirectoryRoleTemplate HelpdeskAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(HelpdeskAdministratorID, "Helpdesk Administrator", "Helpdesk administrator");

        public const string IntuneServiceAdministratorID = "3a2c62db-5318-420d-8d74-23affee5d9d5";
        public static SlimGraphDirectoryRoleTemplate IntuneServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(IntuneServiceAdministratorID, "Intune Service Administrator", "Intune administrator");

        public const string KaizalaAdministratorID = "74ef975b-6605-40af-a5d2-b9539d836353";
        public static SlimGraphDirectoryRoleTemplate KaizalaAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(KaizalaAdministratorID, "Kaizala Administrator", "Kaizala administrator");

        public const string LicenseAdministratorID = "4d6ac14f-3453-41d0-bef9-a3e0c569773a";
        public static SlimGraphDirectoryRoleTemplate LicenseAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(LicenseAdministratorID, "License Administrator", "License administrator");

        public const string LyncServiceAdministratorID = "75941009-915a-4869-abe7-691bff18279e";
        public static SlimGraphDirectoryRoleTemplate LyncServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(LyncServiceAdministratorID, "Lync Service Administrator", "Skype for Business administrator");

        public const string MessageCenterPrivacyReaderID = "ac16e43d-7b2d-40e0-ac05-243ff356ab5b";
        public static SlimGraphDirectoryRoleTemplate MessageCenterPrivacyReader { get; } = new SlimGraphDirectoryRoleTemplate(MessageCenterPrivacyReaderID, "Message Center Privacy Reader", "Message center privacy reader");

        public const string MessageCenterReaderID = "790c1fb9-7f7d-4f88-86a1-ef1f95c05c1b";
        public static SlimGraphDirectoryRoleTemplate MessageCenterReader { get; } = new SlimGraphDirectoryRoleTemplate(MessageCenterReaderID, "Message Center Reader", "Message center reader");

        public const string OfficeAppsAdministratorID = "2b745bdf-0803-4d80-aa65-822c4493daac";
        public static SlimGraphDirectoryRoleTemplate OfficeAppsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(OfficeAppsAdministratorID, "Office Apps Administrator", "Office apps administrator");

        public const string PartnerTier1SupportID = "4ba39ca4-527c-499a-b93d-d9b492c50246";
        public static SlimGraphDirectoryRoleTemplate PartnerTier1Support { get; } = new SlimGraphDirectoryRoleTemplate(PartnerTier1SupportID, "Partner Tier1 Support", "Partner tier1 support");

        public const string PartnerTier2SupportID = "e00e864a-17c5-4a4b-9c06-f5b95a8d5bd8";
        public static SlimGraphDirectoryRoleTemplate PartnerTier2Support { get; } = new SlimGraphDirectoryRoleTemplate(PartnerTier2SupportID, "Partner Tier2 Support", "Partner tier2 support");

        public const string PasswordAdministratorID = "966707d0-3269-4727-9be2-8c3a10f19b9d";
        public static SlimGraphDirectoryRoleTemplate PasswordAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PasswordAdministratorID, "Password Administrator", "Password administrator");

        public const string PowerBIServiceAdministratorID = "a9ea8996-122f-4c74-9520-8edcd192826c";
        public static SlimGraphDirectoryRoleTemplate PowerBIServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PowerBIServiceAdministratorID, "Power BI Service Administrator", "Power BI administrator");

        public const string PowerPlatformAdministratorID = "11648597-926c-4cf3-9c36-bcebb0ba8dcc";
        public static SlimGraphDirectoryRoleTemplate PowerPlatformAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PowerPlatformAdministratorID, "Power Platform Administrator", "Power platform administrator");

        public const string PrivilegedAuthenticationAdministratorID = "7be44c8a-adaf-4e2a-84d6-ab2649e08a13";
        public static SlimGraphDirectoryRoleTemplate PrivilegedAuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PrivilegedAuthenticationAdministratorID, "Privileged Authentication Administrator", "Privileged authentication administrator");

        public const string PrivilegedRoleAdministratorID = "e8611ab8-c189-46e8-94e1-60213ab1f814";
        public static SlimGraphDirectoryRoleTemplate PrivilegedRoleAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(PrivilegedRoleAdministratorID, "Privileged Role Administrator", "Privileged role administrator");

        public const string ReportsReaderID = "4a5d8f65-41da-4de4-8968-e035b65339cf";
        public static SlimGraphDirectoryRoleTemplate ReportsReader { get; } = new SlimGraphDirectoryRoleTemplate(ReportsReaderID, "Reports Reader", "Reports reader");

        public const string SearchAdministratorID = "0964bb5e-9bdb-4d7b-ac29-58e794862a40";
        public static SlimGraphDirectoryRoleTemplate SearchAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SearchAdministratorID, "Search Administrator", "Search administrator");

        public const string SearchEditorID = "8835291a-918c-4fd7-a9ce-faa49f0cf7d9";
        public static SlimGraphDirectoryRoleTemplate SearchEditor { get; } = new SlimGraphDirectoryRoleTemplate(SearchEditorID, "Search Editor", "Search editor");

        public const string SecurityAdministratorID = "194ae4cb-b126-40b2-bd5b-6091b380977d";
        public static SlimGraphDirectoryRoleTemplate SecurityAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SecurityAdministratorID, "Security Administrator", "Security administrator");

        public const string SecurityOperatorID = "5f2222b1-57c3-48ba-8ad5-d4759f1fde6f";
        public static SlimGraphDirectoryRoleTemplate SecurityOperator { get; } = new SlimGraphDirectoryRoleTemplate(SecurityOperatorID, "Security Operator", "Security operator");

        public const string SecurityReaderID = "5d6b6bb7-de71-4623-b4af-96380a352509";
        public static SlimGraphDirectoryRoleTemplate SecurityReader { get; } = new SlimGraphDirectoryRoleTemplate(SecurityReaderID, "Security Reader", "Security reader");

        public const string ServiceSupportAdministratorID = "f023fd81-a637-4b56-95fd-791ac0226033";
        public static SlimGraphDirectoryRoleTemplate ServiceSupportAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(ServiceSupportAdministratorID, "Service Support Administrator", "Service support administrator");

        public const string SharePointServiceAdministratorID = "f28a1f50-f6e7-4571-818b-6a12f2af6b6c";
        public static SlimGraphDirectoryRoleTemplate SharePointServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(SharePointServiceAdministratorID, "SharePoint Service Administrator", "SharePoint administrator");

        public const string TeamsCommunicationsAdministratorID = "baf37b3a-610e-45da-9e62-d9d1e5e8914b";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsAdministratorID, "Teams Communications Administrator", "Teams Communications Administrator");

        public const string TeamsCommunicationsSupportEngineerID = "f70938a0-fc10-4177-9e90-2178f8765737";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportEngineer { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsSupportEngineerID, "Teams Communications Support Engineer", "Teams Communications Support Engineer");

        public const string TeamsCommunicationsSupportSpecialistID = "fcf91098-03e3-41a9-b5ba-6f0ec8188a12";
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportSpecialist { get; } = new SlimGraphDirectoryRoleTemplate(TeamsCommunicationsSupportSpecialistID, "Teams Communications Support Specialist", "Teams Communications Support Specialist");

        public const string TeamsServiceAdministratorID = "69091246-20e8-4a56-aa4d-066075b2a7a8";
        public static SlimGraphDirectoryRoleTemplate TeamsServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(TeamsServiceAdministratorID, "Teams Service Administrator", "Teams Service Administrator");

        public const string UserID = "a0b1b346-4d3e-4e8b-98f8-753987be4970";
        public static SlimGraphDirectoryRoleTemplate User { get; } = new SlimGraphDirectoryRoleTemplate(UserID, "User", "User");

        public const string UserAccountAdministratorID = "fe930be7-5e62-47db-91af-98c3a49a38b1";
        public static SlimGraphDirectoryRoleTemplate UserAccountAdministrator { get; } = new SlimGraphDirectoryRoleTemplate(UserAccountAdministratorID, "User Account Administrator", "User administrator");

        public const string WorkplaceDeviceJoinID = "c34f683f-4d5a-4403-affd-6615e00e3a7f";
        public static SlimGraphDirectoryRoleTemplate WorkplaceDeviceJoin { get; } = new SlimGraphDirectoryRoleTemplate(WorkplaceDeviceJoinID, "Workplace Device Join", "Workplace device join");
    }
}
