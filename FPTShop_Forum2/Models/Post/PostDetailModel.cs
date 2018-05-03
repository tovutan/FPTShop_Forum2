using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models.Post
{
    public class PostDetailModel
    {
        public PostItemModel Post { get; set; }
        public List<PostItemModel> PostAuthor { get; set; }
        public List<PostItemModel> PostRelated { get; set; }
    }
}