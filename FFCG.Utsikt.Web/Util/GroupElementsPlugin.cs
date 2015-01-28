using EPiServer.Editor.TinyMCE;

namespace FFCG.Utsikt.Web.Util
{
    [TinyMCEPluginButton(
        PlugInName = "GroupElementsPlugin", // Internal name and also name of the plugin folder where rest of files must be placed
        Description = "Inserts three different tables of choice",
        DisplayName = "GroupElementsPlugin",
        ButtonName = "btnGroupElements", // Name of button that the user will press in UI (will be explained later)
        GroupName = "table", // Where the button will be grouped
        IconUrl = "Editor/tinymce/plugins/GroupElementsPlugin/img/GroupElements.png")]
    public class GroupElementsPlugin
    {
    }
}