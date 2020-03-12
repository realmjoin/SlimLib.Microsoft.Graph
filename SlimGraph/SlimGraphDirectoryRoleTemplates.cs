using System;

namespace SlimGraph
{
    public static class SlimGraphDirectoryRoleTemplates
    {
        // Source: https://docs.microsoft.com/en-us/azure/active-directory/users-groups-roles/directory-assign-admin-roles
        // Formula: =CONCAT("public static SlimGraphDirectoryRoleTemplate ", SUBSTITUTE(A2, " ", ""), " { get; } = new SlimGraphDirectoryRoleTemplate(""",LOWER(C2),""", """,A2,""", """,B2,""");")
        public static SlimGraphDirectoryRoleTemplate ApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("9b895d92-2cd3-44c7-9d02-a6ac2d5ea5c3", "Application Administrator ", "Application administrator ");
        public static SlimGraphDirectoryRoleTemplate ApplicationDeveloper { get; } = new SlimGraphDirectoryRoleTemplate("cf1c38e5-3621-4004-a7cb-879624dced7c", "Application Developer ", "Application developer ");
        public static SlimGraphDirectoryRoleTemplate AuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("c4e39bd9-1100-46d3-8c65-fb160da0071f", "Authentication Administrator ", "Authentication administrator ");
        public static SlimGraphDirectoryRoleTemplate AzureDevOpsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("e3973bdf-4987-49ae-837a-ba8e231c7286", "Azure DevOps Administrator ", "Azure DevOps administrator ");
        public static SlimGraphDirectoryRoleTemplate AzureInformationProtectionAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("7495fdc4-34c4-4d15-a289-98788ce399fd", "Azure Information Protection Administrator ", "Azure Information Protection administrator ");
        public static SlimGraphDirectoryRoleTemplate B2CUserflowAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("6e591065-9bad-43ed-90f3-e9424366d2f0", "B2C User flow Administrator ", "B2C User flow Administrator ");
        public static SlimGraphDirectoryRoleTemplate B2CUserFlowAttributeAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("0f971eea-41eb-4569-a71e-57bb8a3eff1e", "B2C User Flow Attribute Administrator ", "B2C User Flow Attribute Administrator ");
        public static SlimGraphDirectoryRoleTemplate B2CIEFKeysetAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("aaf43236-0c0d-4d5f-883a-6955382ac081", "B2C IEF Keyset Administrator ", "B2C IEF Keyset Administrator ");
        public static SlimGraphDirectoryRoleTemplate B2CIEFPolicyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("3edaf663-341e-4475-9f94-5c398ef6c070", "B2C IEF Policy Administrator ", "B2C IEF Policy Administrator ");
        public static SlimGraphDirectoryRoleTemplate BillingAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("b0f54661-2d74-4c50-afa3-1ec803f12efe", "Billing Administrator ", "Billing administrator ");
        public static SlimGraphDirectoryRoleTemplate CloudApplicationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("158c047a-c907-4556-b7ef-446551a6b5f7", "Cloud Application Administrator ", "Cloud application administrator ");
        public static SlimGraphDirectoryRoleTemplate CloudDeviceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("7698a772-787b-4ac8-901f-60d6b08affd2", "Cloud Device Administrator ", "Cloud device administrator ");
        public static SlimGraphDirectoryRoleTemplate CompanyAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("62e90394-69f5-4237-9190-012177145e10", "Company Administrator ", "Global administrator ");
        public static SlimGraphDirectoryRoleTemplate ComplianceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("17315797-102d-40b4-93e0-432062caca18", "Compliance Administrator ", "Compliance administrator ");
        public static SlimGraphDirectoryRoleTemplate ComplianceDataAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("e6d1a23a-da11-4be4-9570-befc86d067a7", "Compliance Data Administrator ", "Compliance data administrator ");
        public static SlimGraphDirectoryRoleTemplate ConditionalAccessAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("b1be1c3e-b65d-4f19-8427-f6fa0d97feb9", "Conditional Access Administrator ", "Conditional Access administrator ");
        public static SlimGraphDirectoryRoleTemplate CRMServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("44367163-eba1-44c3-98af-f5787879f96a", "CRM Service Administrator ", "Dynamics 365 administrator ");
        public static SlimGraphDirectoryRoleTemplate CustomerLockBoxAccessApprover { get; } = new SlimGraphDirectoryRoleTemplate("5c4f9dcd-47dc-4cf7-8c9a-9e4207cbfc91", "Customer LockBox Access Approver ", "Customer Lockbox access approver ");
        public static SlimGraphDirectoryRoleTemplate DesktopAnalyticsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("38a96431-2bdf-4b4c-8b6e-5d3d8abac1a4", "Desktop Analytics Administrator ", "Desktop Analytics Administrator ");
        public static SlimGraphDirectoryRoleTemplate DeviceAdministrators { get; } = new SlimGraphDirectoryRoleTemplate("9f06204d-73c1-4d4c-880a-6edb90606fd8", "Device Administrators ", "Device administrators ");
        public static SlimGraphDirectoryRoleTemplate DeviceJoin { get; } = new SlimGraphDirectoryRoleTemplate("9c094953-4995-41c8-84c8-3ebb9b32c93f", "Device Join ", "Device join ");
        public static SlimGraphDirectoryRoleTemplate DeviceManagers { get; } = new SlimGraphDirectoryRoleTemplate("2b499bcd-da44-4968-8aec-78e1674fa64d", "Device Managers ", "Device managers ");
        public static SlimGraphDirectoryRoleTemplate DeviceUsers { get; } = new SlimGraphDirectoryRoleTemplate("d405c6df-0af8-4e3b-95e4-4d06e542189e", "Device Users ", "Device users ");
        public static SlimGraphDirectoryRoleTemplate DirectoryReaders { get; } = new SlimGraphDirectoryRoleTemplate("88d8e3e3-8f55-4a1e-953a-9b9898b8876b", "Directory Readers ", "Directory readers ");
        public static SlimGraphDirectoryRoleTemplate DirectorySynchronizationAccounts { get; } = new SlimGraphDirectoryRoleTemplate("d29b2b05-8046-44ba-8758-1e26182fcf32", "Directory Synchronization Accounts ", "Directory synchronization accounts ");
        public static SlimGraphDirectoryRoleTemplate DirectoryWriters { get; } = new SlimGraphDirectoryRoleTemplate("9360feb5-f418-4baa-8175-e2a00bac4301", "Directory Writers ", "Directory writers ");
        public static SlimGraphDirectoryRoleTemplate ExchangeServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("29232cdf-9323-42fd-ade2-1d097af3e4de", "Exchange Service Administrator ", "Exchange administrator ");
        public static SlimGraphDirectoryRoleTemplate ExternalIdentityProviderAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("be2f45a1-457d-42af-a067-6ec1fa63bc45", "External Identity Provider Administrator ", "External Identity Provider Administrator ");
        public static SlimGraphDirectoryRoleTemplate GlobalReader { get; } = new SlimGraphDirectoryRoleTemplate("f2ef992c-3afb-46b9-b7cf-a126ee74c451", "Global Reader ", "Global reader ");
        public static SlimGraphDirectoryRoleTemplate GroupsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("fdd7a751-b60b-444a-984c-02652fe8fa1c", "Groups Administrator ", "Groups administrator ");
        public static SlimGraphDirectoryRoleTemplate GuestInviter { get; } = new SlimGraphDirectoryRoleTemplate("95e79109-95c0-4d8e-aee3-d01accf2d47b", "Guest Inviter ", "Guest inviter ");
        public static SlimGraphDirectoryRoleTemplate HelpdeskAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("729827e3-9c14-49f7-bb1b-9608f156bbb8", "Helpdesk Administrator ", "Helpdesk administrator ");
        public static SlimGraphDirectoryRoleTemplate IntuneServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("3a2c62db-5318-420d-8d74-23affee5d9d5", "Intune Service Administrator ", "Intune administrator ");
        public static SlimGraphDirectoryRoleTemplate KaizalaAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("74ef975b-6605-40af-a5d2-b9539d836353", "Kaizala Administrator ", "Kaizala administrator ");
        public static SlimGraphDirectoryRoleTemplate LicenseAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("4d6ac14f-3453-41d0-bef9-a3e0c569773a", "License Administrator ", "License administrator ");
        public static SlimGraphDirectoryRoleTemplate LyncServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("75941009-915a-4869-abe7-691bff18279e", "Lync Service Administrator ", "Skype for Business administrator ");
        public static SlimGraphDirectoryRoleTemplate MessageCenterPrivacyReader { get; } = new SlimGraphDirectoryRoleTemplate("ac16e43d-7b2d-40e0-ac05-243ff356ab5b", "Message Center Privacy Reader ", "Message center privacy reader ");
        public static SlimGraphDirectoryRoleTemplate MessageCenterReader { get; } = new SlimGraphDirectoryRoleTemplate("790c1fb9-7f7d-4f88-86a1-ef1f95c05c1b", "Message Center Reader ", "Message center reader ");
        public static SlimGraphDirectoryRoleTemplate OfficeAppsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("2b745bdf-0803-4d80-aa65-822c4493daac", "Office Apps Administrator ", "Office apps administrator ");
        public static SlimGraphDirectoryRoleTemplate PartnerTier1Support { get; } = new SlimGraphDirectoryRoleTemplate("4ba39ca4-527c-499a-b93d-d9b492c50246", "Partner Tier1 Support ", "Partner tier1 support ");
        public static SlimGraphDirectoryRoleTemplate PartnerTier2Support { get; } = new SlimGraphDirectoryRoleTemplate("e00e864a-17c5-4a4b-9c06-f5b95a8d5bd8", "Partner Tier2 Support ", "Partner tier2 support ");
        public static SlimGraphDirectoryRoleTemplate PasswordAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("966707d0-3269-4727-9be2-8c3a10f19b9d", "Password Administrator ", "Password administrator ");
        public static SlimGraphDirectoryRoleTemplate PowerBIServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("a9ea8996-122f-4c74-9520-8edcd192826c", "Power BI Service Administrator ", "Power BI administrator ");
        public static SlimGraphDirectoryRoleTemplate PowerPlatformAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("11648597-926c-4cf3-9c36-bcebb0ba8dcc", "Power Platform Administrator ", "Power platform administrator ");
        public static SlimGraphDirectoryRoleTemplate PrivilegedAuthenticationAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("7be44c8a-adaf-4e2a-84d6-ab2649e08a13", "Privileged Authentication Administrator ", "Privileged authentication administrator ");
        public static SlimGraphDirectoryRoleTemplate PrivilegedRoleAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("e8611ab8-c189-46e8-94e1-60213ab1f814", "Privileged Role Administrator ", "Privileged role administrator ");
        public static SlimGraphDirectoryRoleTemplate ReportsReader { get; } = new SlimGraphDirectoryRoleTemplate("4a5d8f65-41da-4de4-8968-e035b65339cf", "Reports Reader ", "Reports reader ");
        public static SlimGraphDirectoryRoleTemplate SearchAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("0964bb5e-9bdb-4d7b-ac29-58e794862a40", "Search Administrator ", "Search administrator ");
        public static SlimGraphDirectoryRoleTemplate SearchEditor { get; } = new SlimGraphDirectoryRoleTemplate("8835291a-918c-4fd7-a9ce-faa49f0cf7d9", "Search Editor ", "Search editor ");
        public static SlimGraphDirectoryRoleTemplate SecurityAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("194ae4cb-b126-40b2-bd5b-6091b380977d", "Security Administrator ", "Security administrator ");
        public static SlimGraphDirectoryRoleTemplate SecurityOperator { get; } = new SlimGraphDirectoryRoleTemplate("5f2222b1-57c3-48ba-8ad5-d4759f1fde6f", "Security Operator ", "Security operator ");
        public static SlimGraphDirectoryRoleTemplate SecurityReader { get; } = new SlimGraphDirectoryRoleTemplate("5d6b6bb7-de71-4623-b4af-96380a352509", "Security Reader ", "Security reader ");
        public static SlimGraphDirectoryRoleTemplate ServiceSupportAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("f023fd81-a637-4b56-95fd-791ac0226033", "Service Support Administrator ", "Service support administrator ");
        public static SlimGraphDirectoryRoleTemplate SharePointServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("f28a1f50-f6e7-4571-818b-6a12f2af6b6c", "SharePoint Service Administrator ", "SharePoint administrator ");
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("baf37b3a-610e-45da-9e62-d9d1e5e8914b", "Teams Communications Administrator ", "Teams Communications Administrator ");
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportEngineer { get; } = new SlimGraphDirectoryRoleTemplate("f70938a0-fc10-4177-9e90-2178f8765737", "Teams Communications Support Engineer ", "Teams Communications Support Engineer ");
        public static SlimGraphDirectoryRoleTemplate TeamsCommunicationsSupportSpecialist { get; } = new SlimGraphDirectoryRoleTemplate("fcf91098-03e3-41a9-b5ba-6f0ec8188a12", "Teams Communications Support Specialist ", "Teams Communications Support Specialist ");
        public static SlimGraphDirectoryRoleTemplate TeamsServiceAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("69091246-20e8-4a56-aa4d-066075b2a7a8", "Teams Service Administrator ", "Teams Service Administrator ");
        public static SlimGraphDirectoryRoleTemplate User { get; } = new SlimGraphDirectoryRoleTemplate("a0b1b346-4d3e-4e8b-98f8-753987be4970", "User ", "User ");
        public static SlimGraphDirectoryRoleTemplate UserAccountAdministrator { get; } = new SlimGraphDirectoryRoleTemplate("fe930be7-5e62-47db-91af-98c3a49a38b1", "User Account Administrator ", "User administrator ");
        public static SlimGraphDirectoryRoleTemplate WorkplaceDeviceJoin { get; } = new SlimGraphDirectoryRoleTemplate("c34f683f-4d5a-4403-affd-6615e00e3a7f", "Workplace Device Join ", "Workplace device join ");

    }
}
