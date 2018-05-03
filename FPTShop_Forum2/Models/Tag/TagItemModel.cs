using FPTShop_Forum2.Models.Post;
using FPTShop_Forum2.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models.Tag
{
    [Serializable]
    public class TagItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string ImageURL { get; set; }

        public string Link { get; set; }

        [DefaultValue(false)]
        public bool? IsDeleted { get; set; }

        [DefaultValue(true)]
        public bool? IsShow { get; set; }

        [DefaultValue(false)]
        public bool? PinInSearch { get; set; }

        #region SEO
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        #endregion

        #region Log
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public  string CreateBy { get; set; }
        public  UserItemModel CreateUser { get; set; }

        public  string UpdateBy { get; set; }
        public  UserItemModel UpdateUser { get; set; }
        #endregion  

        public  ICollection<PostItemModel> Posts { get; set; }
    }
}