using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.Localization;
using EPiServer.Framework.Localization.XmlResources;

namespace FFCG.Utsikt.Web.Infrastructure
{
    [InitializableModule]
    [ModuleDependency(typeof(FrameworkInitialization))]
    public class CustomLanguageProviderInitializationWithPhysicalPath : IInitializableModule
    {
        private ProviderBasedLocalizationService _localizationService;
        private string ModelsFolder {
            get { return string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, "/Models"); }
        }

        private string ComponentsFolder
        {
            get { return string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, "/Components"); }
        }

        public void Initialize(InitializationEngine context)
        {
            //Casts the current LocalizationService to a ProviderBasedLocalizationService to get access to the current list of providers
            _localizationService = context.Locate.Advanced.GetInstance<LocalizationService>() as ProviderBasedLocalizationService;
            if (_localizationService != null)
            {
                ProcessDirectory(ModelsFolder, AddLocalizationPath);
                ProcessDirectory(ComponentsFolder, AddLocalizationPath);
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Casts the current LocalizationService to a ProviderBasedLocalizationService to get access to the current list of providers
            _localizationService = context.Locate.Advanced.GetInstance<LocalizationService>() as ProviderBasedLocalizationService;
            if (_localizationService != null)
            {
                ProcessDirectory(ModelsFolder, RemoveLocalizationProvider);
                ProcessDirectory(ComponentsFolder, RemoveLocalizationProvider);
            }
        }

        public void ProcessDirectory(string targetDirectory,Action<string> action)
        {

            // Recurse into subdirectories of this directory. 
            action(targetDirectory);
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessSubDirectory(subdirectory, action);
        }

        private void ProcessSubDirectory(string subdirectory, Action<string> action)
        {
            // Recurse into subdirectories of this directory. 
            action(subdirectory);
            string[] subdirectoryEntries = Directory.GetDirectories(subdirectory);
            foreach (string langFolder in subdirectoryEntries)
                action(langFolder);
        }

        private void  AddLocalizationPath(string langFolder)
        {
            if (Directory.Exists(langFolder))
            {
                NameValueCollection configValues = new NameValueCollection();
                //This config value tells the provider where to find XML language documents.
                configValues.Add(FileXmlLocalizationProvider.PhysicalPathKey, langFolder);
                FileXmlLocalizationProvider localizationProvider = new FileXmlLocalizationProvider();
                //Instanciates the provider
                localizationProvider.Initialize(GetProviderName(langFolder), configValues);
                //Adds it at the end of the list of providers.
                _localizationService.Providers.Add(localizationProvider);
            }
        }

        private void RemoveLocalizationProvider(string langFolder)
        {
                //Gets any provider that has the same name as the one initialized.
                LocalizationProvider localizationProvider = _localizationService.Providers.FirstOrDefault(p => p.Name.Equals(GetProviderName(langFolder), StringComparison.Ordinal));
                if (localizationProvider != null)
                {
                    //If found, remove it.
                    _localizationService.Providers.Remove(localizationProvider);
                }
        }

        public string GetProviderName(string langFolder)
        {
            return langFolder.Split('/').Last();
        }

        public void Preload(string[] parameters) { }
    }
}