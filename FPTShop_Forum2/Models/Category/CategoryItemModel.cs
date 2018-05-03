using FPTShop_Forum2.Models.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FPTShop_Forum2.Models
{
    [Serializable]
    public class CategoryItemModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string SEOTitle { get; set; }

        public string SEOKeyword { get; set; }

        public string SEODescription { get; set; }

        public int? Quantity { get; set; }

        #region CategoryItemModel Parent-Child
        public virtual int? ParentID { get; set; }

        public virtual CategoryItemModel ParentCategory { get; set; }

        public virtual ICollection<CategoryItemModel> ChildCategory { get; set; }
        #endregion


        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int? OrderDisplay { get; set; }

        [DefaultValue(true)]
        public bool IsShow { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        [DefaultValue(false)]
        public bool? IsPublic { get; set; }

        public virtual ICollection<PostItemModel> Posts { get; set; }
    }
}