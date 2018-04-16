using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{

    public class Category
    {
       
        public Category()
        {
            Posts = new HashSet<Post>();
            ChildCategory = new HashSet<Category>();
        }

        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string  Name { get; set; }

        public string UrlSlug { get; set; }

        public string  Image { get; set; }

        public string Description { get; set; }

        public string SEOTitle { get; set; }

        public string SEOKeyword { get; set; }

        public string SEODescription { get; set; }

        public int? Quantity { get; set; }

        #region Category Parent-Child
        public virtual int? ParentID { get; set; }

        public virtual  Category ParentCategory { get; set; }

        public virtual ICollection<Category> ChildCategory { get; set; }
        #endregion


        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }


        public virtual string ModifiedBy { get; set; }
        public User ModifiedUser { get; set; }

        public int? OrderDisplay { get; set; }

        [DefaultValue(true)]
        public bool IsShow { get; set; }

        [DefaultValue(false)]
        public bool IsDelete { get; set; }

        [DefaultValue(false)]
        public bool? IsPublic { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
     
    }
}
