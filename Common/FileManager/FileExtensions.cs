using Common.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FileManager
{
    public static class FileExtensions
    {
        private static IEnumerable<string> CodeFileExtensions = new string[] { ".cs", ".cshtml", ".css", ".js", ".json", ".sql", ".dart", ".html" };

        public static async Task<string> AutoSaveAsync(this IFormFile file, string path = "", string filename = "", string folder = "", string userId = "", string series = "")
        {
            if (file.Length > 0)
            {
                var todayFolder = DateTime.Now.ToPersianDateFolderName();
                var filePath = !string.IsNullOrEmpty(path) ? path : "";
                filePath = !string.IsNullOrEmpty(userId) ? Path.Combine(filePath, userId.Replace("-", "_")) : filePath;
                filePath = Path.Combine(filePath, todayFolder);
                filePath = !string.IsNullOrEmpty(folder) ? Path.Combine(filePath, folder) : filePath;
                filePath = !string.IsNullOrEmpty(series) ? Path.Combine(filePath, series) : filePath;
                filePath = !string.IsNullOrEmpty(filename) ? Path.Combine(filePath, filename) : Path.Combine(filePath, Path.GetRandomFileName() + Path.GetExtension(file.FileName));

                CreateFolder(path, userId);
                CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_")), todayFolder);
                CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_"), todayFolder), folder);
                if (!string.IsNullOrEmpty(series))
                {
                    CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_"), todayFolder, folder), series);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    filePath = filePath.Remove(0, filePath.IndexOf("uploads") + 8).Replace("\\", "/");

                    return filePath;
                }
            }

            return null;
        }

        public static async Task<string> AutoSaveThumbnailAsync(this IFormFile file, string path = "", string filename = "", string folder = "", string userId = "", string series = "")
        {
            if (file.Length > 0)
            {
                var todayFolder = DateTime.Now.ToPersianDateFolderName();
                var filePath = !string.IsNullOrEmpty(path) ? path : "";

                filePath = !string.IsNullOrEmpty(userId) ? Path.Combine(filePath, userId.Replace("-", "_")) : filePath;
                filePath = Path.Combine(filePath, todayFolder);
                filePath = !string.IsNullOrEmpty(folder) ? Path.Combine(filePath, folder) : filePath;
                filePath = !string.IsNullOrEmpty(series) ? Path.Combine(filePath, series) : filePath;
                filePath = !string.IsNullOrEmpty(filename) ? Path.Combine(filePath, filename) : Path.Combine(filePath, Path.GetRandomFileName() + Path.GetExtension(file.FileName));

                CreateFolder(path, userId);
                CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_")), todayFolder);
                CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_"), todayFolder), folder);

                if (!string.IsNullOrEmpty(series))
                {
                    CreateFolder(Path.Combine(path, userId.Replace("-", "_").Replace(" ", "_"), todayFolder, folder), series);
                }

                using (var stream = file.OpenReadStream())
                {
                    Image image = Image.FromStream(stream);

                    var pixel = image.Width > image.Height ? image.Height : image.Width;
                    var diff = image.Width > image.Height ? (int)((image.Width - image.Height) / 2) : (int)((image.Height - image.Width) / 2);
                    var height = image.Width > image.Height ? false : true;

                    var x = !height ? diff : 0;
                    var y = height ? diff : 0;

                    Rectangle rect = new Rectangle(x, y, pixel, pixel);
                    Bitmap OriginalImage = new Bitmap(image, image.Width, image.Height);
                    Bitmap temp = new Bitmap(pixel, pixel);
                    Graphics g = Graphics.FromImage(temp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);

                    //Image temp = image.GetThumbnailImage(pixel, pixel, null, IntPtr.Zero);

                    Image thumb = temp.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);

                    thumb.Save(filePath);

                    filePath = filePath.Remove(0, filePath.IndexOf("uploads") + 8).Replace("\\", "/");

                    return filePath;
                }
            }

            return null;
        }

        public static bool IsCodeFile(this IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            return CodeFileExtensions.Where(w => w == ext).FirstOrDefault() != null ? true : false;
        }

        private static void CreateFolder(string basePath, string folder)
        {
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(Path.Combine(basePath, folder)))
            {
                Directory.CreateDirectory(Path.Combine(basePath, folder));
            }
        }

        public static string GetRandomName(this IFormFile file)
        {
            return DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
        }

        public static IEnumerable<string> DirSearch(this string sDir)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
            }

            return files;
        }
    }
}
