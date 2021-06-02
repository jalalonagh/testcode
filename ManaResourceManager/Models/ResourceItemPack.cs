using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManaResourceManager.Models
{
    public class ResourceItemPack
    {
        public ResourceItem Item { get; set; }
        public IEnumerable<ResourceItem> Others { get; set; }

        public string GetMessage()
        {
            if (Item != null)
                return Item.Message;

            if (Others != null && Others.Any())
                return Others.FirstOrDefault().Message;

            return "محتوایی یافت نشد";
        }
    }
}
