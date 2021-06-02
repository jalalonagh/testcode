using ManaResourceManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaResourceManager
{
    public class ResourceFileManager
    {
        private string dir { get; set; }

        public ResourceFileManager()
        {
            dir = Directory.GetCurrentDirectory();
        }

        public void GenerateFoldersAndFiles(IEnumerable<ManaResourceLanguage> languages, string root)
        {
            CreateFolder(dir, root);
            if (languages != null && languages.Any())
                foreach (var item in languages)
                {
                    CreateFolder(dir, root, item.Name);
                    CreateFileWithTemplate(Path.Combine(dir, root, item.Name), item.Name);
                }
        }
        public IEnumerable<ResourceItem> GetAllResources(IEnumerable<ManaResourceLanguage> languages, string root)
        {
            List<ResourceItem> items = new List<ResourceItem>();
            if(!string.IsNullOrEmpty(root) && languages != null && languages.Any())
            {
                var files = FindLanguageFiles(languages, root);
                if(files != null && files.Any())
                    foreach (var file in files)
                    {
                        string text = "";
                        using (StreamReader sr = file.OpenText())
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                text += s;
                            }
                        }
                        items.AddRange(TextToResources(text));
                    }
            }
            return items;
        }
        private List<ResourceItem> TextToResources(string jsonText)
        {
            if (!string.IsNullOrEmpty(jsonText))
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResourceItem>>(jsonText);

            return new List<ResourceItem>();
        }
        private void CreateFolder(params string[] parts)
        {
            if(parts != null && parts.Any())
            {
                var path = Path.Combine(parts);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// ایجاد فایل معانی
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fileName">نام فایل بدون پسوند</param>
        private void CreateFileWithTemplate(string path, string fileName)
        {
            if(!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(fileName))
            {
                var pathFile = Path.Combine(path, fileName + ".json");

                if (!File.Exists(pathFile))
                {
                    File.Create(pathFile);

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(new List<ResourceItem>() { new ResourceItem(){
                        Category = "base",
                        Language = "fa-IR",
                        Message = "به سیستم مدیریت پیغام های ما خوش آمدید",
                        Name = "WELLCOME",
                        Title = "خوش آمد گویی"
                    }});

                    File.WriteAllText(pathFile, json);
                }
            }
        }
        private IEnumerable<FileInfo> FindLanguageFiles(IEnumerable<ManaResourceLanguage> languages, string root)
        {
            IEnumerable<FileInfo> files = new List<FileInfo>();
            if(!string.IsNullOrEmpty(root) && languages != null && languages.Any())
            {
                foreach (var item in languages)
                    files = files.Append(new FileInfo(Path.Combine(dir, root, item.Name, item.Name + ".json")));
            }

            return files;
        }
        public void UpdateResource(ManaResourceLanguage language, IEnumerable<ResourceItem> items, string root)
        {
            if (language != null && items != null && items.Any() && !string.IsNullOrEmpty(root))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(items);

                File.WriteAllText(Path.Combine(dir, root, language.Name, language.Name + ".json"), json);
            }
        }
    }
}
