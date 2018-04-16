using FPTShop_Forum2.Models;
using FPTShop_Forum2.Models.Tag;
using FPTShop_Forum2.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models.Post
{
    [Serializable]
    public class PostItemModel
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string UrlSlug { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string SEOTitle { get; set; }

        public string SEOKeyword { get; set; }

        public string SEODescription { get; set; }

        public string RelateProducts { get; set; }

        public int? Like { get; set; }

        public int? Dislike { get; set; }

        public int? PostTypeID { get; set; }

        public int? CategoryID { get; set; }

        public int? UserID { get; set; }

        public int? Viewed { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateModified { get; set; }

        public string LastPostUserName { get; set; }

        public string LastPostUserID { get; set; }
        public UserItemModel LastPostUser { get; set; }

        public string LastUserModifiedID { get; set; }

        public UserItemModel LastUserModified { get; set; }

        public DateTime? LastPostDate { get; set; }

        public int? TotalPost { get; set; }

        public int? OrderDisplay { get; set; }

        [DefaultValue(false)]
        public bool IsHot { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        [DefaultValue(true)]
        public bool IsShow { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        public CategoryItemModel Category { get; set; }
        public  ICollection<TagItemModel> Tags { get; set; }
    }
}