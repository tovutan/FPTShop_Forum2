using FPTShop_Forum2.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models.Post
{
    [Serializable]
    public class PostListModel
    {
        public IList<PostItemModel> HostPosts { get; set; }
        public IList<PostItemModel> Posts { get; set; }
        public IList<PostItemModel> PostLastUserName { get; set; }
        public CategoryItemModel category { get; set; }
        public TagItemModel Tag { get; set; }
    }
}