using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace PontoDeAjuda.Localization
{
    public static class PontoDeAjudaLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PontoDeAjudaConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PontoDeAjudaLocalizationConfigurer).GetAssembly(),
                        "PontoDeAjuda.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
