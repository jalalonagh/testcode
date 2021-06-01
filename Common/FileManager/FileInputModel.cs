using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.FileManager
{
    public abstract class FileInputModel
    {
        public string Path { get; set; } = "";
        public string Filename { get; set; } = "";
        public string Folder { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Series { get; set; } = "";
    }
}
