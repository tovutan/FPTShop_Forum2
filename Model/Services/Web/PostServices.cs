using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Web
{
    public class PostServices : BaseServices
    {
        // viết hàm để tránh xung đột khi gọi bài viết
        public static volatile PostServices _postServices = null;
        public static PostServices GetInstance()
        {
            if (_postServices == null)
            {
                lock (typeof(PostServices))
                {
                    _postServices = new PostServices();
                }
            }
            return _postServices;
        }

        private IOrderedQueryable<Post> _DefaultListPost
        {
            get
            {
                return _db.Posts.Where(p => p.IsShow && !p.IsDelete).OrderByDescending(p => p.DateCreate);
            }
        }

        //public List<Post> _List()
        //{
        //    var _return = _db.Posts.Where(p => p.IsShow && !p.IsDelete).OrderByDescending(p => p.DateCreate).ToList();
        //    return _return.ToList();
        //}


        public IList<Post> GetListPostAll(
         int num,
         int start = 0,
         bool? isHot = null,
          string categoryUrl = null,
          int? categoryID = null,
         string tagURL = null,
         int? tagID = null,
         int? PostID = null,
         int hotPostNum = 0
         )
        {
            var _return = _DefaultListPost.Where(
                p => isHot.HasValue ? p.IsHot == isHot : true
                &&              
                (string.IsNullOrEmpty(categoryUrl) ? true :
                p.Category.UrlSlug.CompareTo(categoryUrl) == 0 //|| p.Category.ParentCategory != null
                //|| (p.Category.ParentCategory.UrlSlug.CompareTo(categoryUrl) == 0)
                )

                &&
                (!categoryID.HasValue ? true :
                p.Category.ID == categoryID //|| (p.Category.ParentCategory != null || p.Category.ParentCategory.ID == categoryID)
                )
                && (string.IsNullOrEmpty(tagURL) ? true : p.Tags.Any(t => t.URL.CompareTo(tagURL) == 0))
                && (!tagID.HasValue ? true : p.Tags.Any(t => t.Id == tagID))
                && (!PostID.HasValue ? true : PostID != p.ID)
                );
            if (hotPostNum > 0)
            {
                IQueryable<Post> hotPost = _return.Where(p => p.IsHot).Take(num);
                _return = _return.Where(p => !hotPost.Any(hp => hp.ID == p.ID));
            }
            _return = _return.Skip(start).Take(num);
            return _return.ToList();
        }

        // Lấy ra danh sách theo điều kiện truyền vào với LastPostUserName==null
        public IList<Post> GetListPost(
            int num,
            int start = 0,
            bool? isHot = null,          
             string categoryUrl = null,
             int? categoryID = null,
            string tagURL = null,
            int? tagID = null,
            int? PostID = null,
            int hotPostNum = 0
            )
        {
            var _return = _DefaultListPost.Where(
                p => isHot.HasValue ? p.IsHot == isHot : true                                   
                &&
                (string.IsNullOrEmpty(p.LastPostUserName))
                &&
                (string.IsNullOrEmpty(categoryUrl)?true:
                p.Category.UrlSlug.CompareTo(categoryUrl)==0 //||p.Category.ParentCategory!=null 
                //|| (p.Category.ParentCategory.UrlSlug.CompareTo(categoryUrl)==0)
                )
                
                && 
                (!categoryID.HasValue?true:
                p.Category.ID==categoryID //|| (p.Category.ParentCategory!=null || p.Category.ParentCategory.ID==categoryID)
                )
                && (string.IsNullOrEmpty(tagURL) ? true : p.Tags.Any(t => t.URL.CompareTo(tagURL) == 0))
                && (!tagID.HasValue ? true : p.Tags.Any(t => t.Id == tagID))
                && (!PostID.HasValue ? true : PostID != p.ID)
                );
            if (hotPostNum > 0)
            {
                IQueryable<Post> hotPost = _return.Where(p => p.IsHot).Take(num);
                _return = _return.Where(p => !hotPost.Any(hp => hp.ID == p.ID));
            }
            _return = _return.Skip(start).Take(num);
            return _return.ToList();
        }

        // lấy hết danh sách có LastPostUserName
        public IList<Post> GetListPostLastUserName(
            int num,
            int start = 0,
            bool? isHot = null,
             string categoryUrl = null,
             int? categoryID = null,
            string tagURL = null,
            int? tagID = null,
            int? PostID = null,
            int hotPostNum = 0
            )
        {
            var _return = _DefaultListPost.Where(
                p => isHot.HasValue ? p.IsHot == isHot : true
                &&
                (!string.IsNullOrEmpty(p.LastPostUserName))
                &&
                (string.IsNullOrEmpty(categoryUrl) ? true :
                p.Category.UrlSlug.CompareTo(categoryUrl) == 0 //|| p.Category.ParentCategory != null
                //|| (p.Category.ParentCategory.UrlSlug.CompareTo(categoryUrl) == 0)
                )

                &&
                (!categoryID.HasValue ? true :
                p.Category.ID == categoryID //|| (p.Category.ParentCategory != null || p.Category.ParentCategory.ID == categoryID)
                )
                && (string.IsNullOrEmpty(tagURL) ? true : p.Tags.Any(t => t.URL.CompareTo(tagURL) == 0))
                && (!tagID.HasValue ? true : p.Tags.Any(t => t.Id == tagID))
                && (!PostID.HasValue ? true : PostID != p.ID)
                );
            if (hotPostNum > 0)
            {
                IQueryable<Post> hotPost = _return.Where(p => p.IsHot).Take(num);
                _return = _return.Where(p => !hotPost.Any(hp => hp.ID == p.ID));
            }
           var cat = _return.Skip(start).Take(num);
            return cat.ToList();
        }



        public IList<Post> GetRootPostList()
        {
            var _return = _db.Posts.Where(x=>x.LastPostUserName!=null).ToList();
            return _return;
        }
        public Post GetPost(string catURL, string url)
        {
            var _return = _DefaultListPost.FirstOrDefault(p => p.UrlSlug == url && p.Category.UrlSlug.CompareTo(catURL)==0);
            return _return;
        }
    }
}
