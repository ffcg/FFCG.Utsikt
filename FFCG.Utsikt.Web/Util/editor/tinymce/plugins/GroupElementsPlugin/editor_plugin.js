(function (tinymce, $) {
    tinymce.create('tinymce.plugins.GroupElementsPlugin', {
        init: function (ed, url) {
            // Register commands
            var openingTag = '<div class="lif-group-img-text">';
            var closingTag = '</div>';
            var className = 'lif-group-img-text';
            ed.addCommand('mceGroupElements', function () {
                var text = ed.selection.getContent();
                var node = ed.selection.getNode();
                if (text && text.length > 0) {
                    if (node.classList.contains(className)) {
                        node.outerHTML = node.innerHTML;
                    }
                    else{
                        ed.execCommand('mceInsertContent', false, openingTag + text + closingTag);
                    }
                }
            });

            // Register buttons
            ed.addButton('btnGroupElements',
                {
                    title: 'Group Elements',
                    cmd: 'mceGroupElements',
                    image: '/util/editor/tinymce/plugins/GroupElementsplugin/img/GroupElements.png'
                });

            // Add a node change handler, selects the button in the UI when a div is selected
            ed.onNodeChange.add(function(ed, cm, n) {

                var node = ed.selection.getNode();
                if (node.classList.contains(className)) {
                    cm.setActive('btnGroupElements', true);
                }
                else
                {
                    cm.setActive('btnGroupElements', false);
                }

            });
        },

        getInfo: function () {
            return {
                longname: 'Group Elements',
                author: 'Forefront AB',
                authorurl: 'http://www.ffcg.se',
                infourl: 'http://www.ffcg.se',
                version: tinymce.majorVersion + "." + tinymce.minorVersion
            };
        }
    });

    // Register plugin
    tinymce.PluginManager.add('GroupElementsPlugin', tinymce.plugins.GroupElementsPlugin);
})(tinymce, epiJQuery);