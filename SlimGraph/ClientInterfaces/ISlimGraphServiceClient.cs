namespace SlimGraph
{
    public interface ISlimGraphClient
    {
        ISlimGraphOrgContactsClient OrgContacts { get; }
        ISlimGraphDevicesClient Devices { get; }
        ISlimGraphManagedDevicesClient ManagedDevices { get; }
        ISlimGraphGroupsClient Groups { get; }
        ISlimGraphServicePrincipalsClient ServicePrincipals { get; }
        ISlimGraphSubscribedSkusClient SubscribedSkus { get; }
        ISlimGraphUsersClient Users { get; }
    }
}