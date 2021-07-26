using System;

namespace SlimLib.Microsoft.Graph
{
    public class SlimGraphDirectoryRoleTemplate
    {
        public SlimGraphDirectoryRoleTemplate(string templateIDString, string graphDisplayName, string portalDisplayName)
        {
            TemplateID = new Guid(templateIDString);
            TemplateIDString = templateIDString;
            GraphDisplayName = graphDisplayName ?? throw new ArgumentNullException(nameof(graphDisplayName));
            PortalDisplayName = portalDisplayName ?? throw new ArgumentNullException(nameof(portalDisplayName));
        }

        public Guid TemplateID { get; set; }
        public string TemplateIDString { get; set; }
        public string GraphDisplayName { get; set; }
        public string PortalDisplayName { get; set; }

        public static implicit operator Guid(SlimGraphDirectoryRoleTemplate self) => self.TemplateID;
    }
}
