using ManaResourceManager.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManaResourceManager
{
    public class ResourceService
    {
        private static ResourceManagerSettings settings;
        private static IEnumerable<ResourceItem> book;

        private ResourceService(IConfiguration configuration)
        {
            settings = configuration.GetSection(nameof(ResourceManagerSettings)).Get<ResourceManagerSettings>();
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
    }
}
