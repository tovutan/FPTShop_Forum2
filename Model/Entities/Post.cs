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

    public class Post
    {
        public Post()
        {
            //Categories = new HashSet<Category>();
            Tags = new HashSet<Tag>();
        }


        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }

        public string UrlSlug { get; set; }

        public string  Content { get; set; }

        public string Image { get; set; }

        public string SEOTitle { get; set; }

        public string SEOKeyword { get; set; }

        public string SEODescription { get; set; }

        public string RelateProducts { get; set; }

        public int? Like { get; set; }

        public int? Dislike { get; set; }

        public int? PostTypeID { get; set; }

        public int CategoryID { get; set; }

        public int? UserID { get; set; }

        public int? Viewed { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateModified { get; set; }


        public string LastPostUserName { get; set; }
      
        public virtual string LastPostUserID { get; set; }

        public virtual User LastPostUser { get; set; }

        public virtual string LastUserModifiedID { get; set; }

        public virtual User LastModifiedUser { get; set; }

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

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }

}
