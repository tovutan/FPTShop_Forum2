using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace FPTShop_Forum2.Models
{
    [Serializable]
    public class ImageURLModel
    {
        public AvatarImageUrlModel AvataImage { get; set; }
        public IList<string> ImageList { get; set; }
    }
}