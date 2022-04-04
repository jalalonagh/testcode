using ManaResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManaResourceManager
{
    public sealed class ResourceManagerSingleton
    {
        private static ResourceManagerSettings settings;
        private static IEnumerable<ResourceItem> book;
        private static ResourceManagerSingleton instance;
        private static object _myLock = new object();

        private ResourceManagerSingleton()
        {
            settings = new ResourceManagerSettings();
            ResourceFileManager manager = new ResourceFileManager();
            manager.GenerateFoldersAndFiles(settings.Languages, settings.RootDirectoryName);
            book = manager.GetAllResources(settings.Languages, settings.RootDirectoryName);
        }

        public ResourceItemPack FetchResource(string name)
        {
            var language = settings.DefaultLanguageCode;
            ResourceItemPack pack = new ResourceItemPack();
            if (book != null && book.Any())
            {
                var resources = book.Where(w => w.Name == name).ToList();
                pack.Item = resources.Where(w => w.Language == language).FirstOrDefault();
                pack.Others = resources.Where(w => w.Language != language).ToList();
                if (pack.Item != null)
                    return pack;
            }
            CreateSource(name, language);
            ResourceFileManager manager = new ResourceFileManager();
            book = manager.GetAllResources(settings.Languages, settings.RootDirectoryName);
            return FetchResource(name);
        }

        public ResourceItemPack FetchResource(string name, string language)
        {
            if (!string.IsNullOrEmpty(language))
                language = settings.DefaultLanguageCode;
            ResourceItemPack pack = new ResourceItemPack();
            if (book != null && book.Any())
            {
                var resources = book.Where(w => w.Name == name).ToList();
                pack.Item = resources.Where(w => w.Language == language).FirstOrDefault();
                pack.Others = resources.Where(w => w.Language != language).ToList();
                return pack;
            }
            CreateSource(name, language);
            ResourceFileManager manager = new ResourceFileManager();
            book = manager.GetAllResources(settings.Languages, settings.RootDirectoryName);
            return pack;
        }
        private void CreateSource(string name, string language)
        {
            IEnumerable<ResourceItem> languageResources = book.Where(w => w.Language == language).ToList();
            languageResources = languageResources.Append(new ResourceItem()
            {
                Name = name,
                Language = language,
                Message = $"new {name} resource created",
                Title = name
            });
            ResourceFileManager manager = new ResourceFileManager();
            manager.UpdateResource(settings.Languages.Where(w => w.Code == language).FirstOrDefault(), languageResources, settings.RootDirectoryName);
        }

        public static ResourceManagerSingleton GetInstance()
        {
            if (instance is null)
            {
                lock (_myLock)
                {
                    if (instance is null)
                        instance = new ResourceManagerSingleton();
                }
            }
            return instance;
        }
    }
}
