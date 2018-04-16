using Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   
    public class Tag
    {
        public Tag()
        {
            Posts = new HashSet<Post>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string ImageURL { get; set; }

        public string Link { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [DefaultValue(true)]
        public bool IsShow { get; set; }

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

        public virtual string CreateBy { get; set; }
        public virtual User CreateUser { get; set; }

        public virtual string UpdateBy { get; set; }
        public virtual User UpdateUser { get; set; }
        #endregion  

        public virtual ICollection<Post> Posts { get; set; }
    }
}
