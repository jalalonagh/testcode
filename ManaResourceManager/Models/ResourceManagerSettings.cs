using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaResourceManager.Models
{
    public class ResourceManagerSettings
    {
        public IEnumerable<ManaResourceLanguage> Languages { get; set; }
        public string DefaultLanguageCode { get; set; }
        public string RootDirectoryName { get; set; }

        public ResourceManagerSettings(bool defaultSettings)
        {
            Languages = new List<ManaResourceLanguage>();
            Languages = Languages.Append(new ManaResourceLanguage() { Code = "fa-IR", Name = "Persian", Title = "فارسی" });
            Languages = Languages.Append(new ManaResourceLanguage() { Code = "en-US", Name = "English", Title = "انگلیسی" });
            Languages = Languages.Append(new ManaResourceLanguage() { Code = "ar-AE", Name = "Arabic", Title = "عربی" });
            Languages = Languages.Append(new ManaResourceLanguage() { Code = "tr-TR", Name = "Turkish", Title = "ترکی" });
            Languages = Languages.Append(new ManaResourceLanguage() { Code = "ru-RU", Name = "Russian", Title = "روسی" });
            DefaultLanguageCode = "fa-IR";
            RootDirectoryName = "LanguageResources";
        }

        public ResourceManagerSettings(List<ManaResourceLanguage> languages, string defaultLanguage = "fa-IR")
        {
            Languages = languages;
            DefaultLanguageCode = defaultLanguage;
            RootDirectoryName = "LanguageResources";
        }

        public ResourceManagerSettings()
        {

        }
    }
}
