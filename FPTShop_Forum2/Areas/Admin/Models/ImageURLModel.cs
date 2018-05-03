using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Areas.Admin.Models
{
    [Serializable] //dùng nó để sau này sẽ dùng Serializeable
    public class ImageURLModel
    {
        public AvatarImageUrlModel AvataImage { get; set; }
        public IList<string> ImageList { get; set; }
    }
}