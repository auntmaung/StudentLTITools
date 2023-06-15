using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NUS.StudentIntegrity.Localization
{
    public static class StudentIntegrityLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(StudentIntegrityConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(StudentIntegrityLocalizationConfigurer).GetAssembly(),
                        "NUS.StudentIntegrity.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
