using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using FFCG.Utsikt.Web.Business;

namespace FFCG.Utsikt.Web.Util.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string), UIHint = SiteUiHints.DateOnly)]

    public class DateEditorDescriptor : EditorDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DateEditorDescriptor()
        {
            //The default editing class that will be used in forms editing mode.
            ClientEditingClass = "dijit.form.DateTextBox";
        }

        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            base.ModifyMetadata(metadata, attributes);
            //Define what kind of editor we want to have, in this case we want to create an inline editor. This is used
            //when the user is in "on page editing" mode.
            metadata.CustomEditorSettings["uiWrapperType"] = "inline";
            //Specify the class for a custom editor responsible for the actual editing.
            //If not defined the default (forms) editor will be used.
            metadata.CustomEditorSettings["uiType"] = "dijit.form.DateTextBox";

        }
    }
}