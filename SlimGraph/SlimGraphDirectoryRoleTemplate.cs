using System;

namespace SlimGraph
{
    public class SlimGraphDirectoryRoleTemplate
    {
        public SlimGraphDirectoryRoleTemplate(Guid templateID, string graphDisplayName, string portalDisplayName)
        {
            TemplateID = templateID;
            GraphDisplayName = graphDisplayName ?? throw new ArgumentNullException(nameof(graphDisplayName));
            PortalDisplayName = portalDisplayName ?? throw new ArgumentNullException(nameof(portalDisplayName));
        }

        public Guid TemplateID { get; set; }
        public string GraphDisplayName { get; set; }
        public string PortalDisplayName { get; set; }

        public static implicit operator Guid(SlimGraphDirectoryRoleTemplate self) => self.TemplateID;
    }
}
