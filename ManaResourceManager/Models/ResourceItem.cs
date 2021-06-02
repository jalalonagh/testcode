using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaResourceManager.Models
{
    public class ResourceItem
    {
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Name = value.ToUpper();
                }
            }
        }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }
}
