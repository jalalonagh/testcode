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
        public static async Task<string> AutoSaveAsync(this IFormFile file, FileInputModel inputModel)
        {
            if (file.Length > 0)
            {
                var filePath = CreateFilePath(inputModel, file);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                    filePath = filePath.Remove(0, filePath.IndexOf("uploads") + 8).Replace("\\", "/");

                    return filePath;
                }
            }

            return null;
        }

        public static async Task<string> AutoSaveThumbnailAsync(this IFormFile file, FileInputModel inputModel)
        {
            if (file.Length > 0)
            {
                var filePath = CreateFilePath(inputModel, file);

                using (var stream = file.OpenReadStream())
                {
                    Image image = Image.FromStream(stream);

                    var temp = RoundImageToCreateThumbnail(image);

                    Image thumb = temp.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);

                    thumb.Save(filePath);

                    filePath = filePath.Remove(0, filePath.IndexOf("uploads") + 8).Replace("\\", "/");

                    return filePath;
                }
            }

            return null;
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
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }

            return files;
        }

        public static string CreateFilePath(FileInputModel inputModel, IFormFile file)
        {
            var todayFolder = DateTime.Now.ToPersianDateFolderName();
            var filePath = !string.IsNullOrEmpty(inputModel.Path) ? inputModel.Path : "";
            filePath = !string.IsNullOrEmpty(inputModel.UserId) ? Path.Combine(filePath, inputModel.UserId.Replace("-", "_")) : filePath;
            filePath = Path.Combine(filePath, todayFolder);
            filePath = !string.IsNullOrEmpty(inputModel.Folder) ? Path.Combine(filePath, inputModel.Folder) : filePath;
            filePath = !string.IsNullOrEmpty(inputModel.Series) ? Path.Combine(filePath, inputModel.Series) : filePath;
            filePath = !string.IsNullOrEmpty(inputModel.Filename) ? Path.Combine(filePath, inputModel.Filename) : Path.Combine(filePath, Path.GetRandomFileName() + Path.GetExtension(file.FileName));

            CreateFolder(inputModel.Path, inputModel.UserId);
            CreateFolder(Path.Combine(inputModel.Path, inputModel.UserId.Replace("-", "_").Replace(" ", "_")), todayFolder);
            CreateFolder(Path.Combine(inputModel.Path, inputModel.UserId.Replace("-", "_").Replace(" ", "_"), todayFolder), inputModel.Folder);

            if (!string.IsNullOrEmpty(inputModel.Series))
            {
                CreateFolder(Path.Combine(inputModel.Path, inputModel.UserId.Replace("-", "_").Replace(" ", "_"), todayFolder, inputModel.Folder), inputModel.Series);
            }

            return filePath;
        }

        private static Image RoundImageToCreateThumbnail(Image image)
        {
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

            return temp;
        }
    }
}
