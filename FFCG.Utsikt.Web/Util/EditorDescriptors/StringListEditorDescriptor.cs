using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Util.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(String[]), UIHint = SiteUiHints.StringList)]
    public class StringListEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "alloy/editors/StringList";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}