
using FPTShop_Forum2.Models;
using FPTShop_Forum2.Models.Post;
using FPTShop_Forum2.Models.Tag;
using FPTShop_Forum2.Models.User;
using Model.Entities;
using Model.Entities.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;
namespace FPTShop_Forum2.Helper.Web
{
    public static class ConvertModel
    {
        #region Post
        private const string IMAGE_USER_DEFAULE = @"/images/news/user.png";
        private static readonly int POST_SHORT_DESC_LIMIT=int.Parse(Utility.GetAppSettings("PageShortDescLimit"));
        public static PostItemModel Convert
            (
                this Post post,
                bool withFullDesc = true,
                bool withUser = false,
                bool withTag = false,
                bool LastPostUserName=false,
                string catURL = null
            )

        {
            var _return = new PostItemModel()
            {
                ID = post.ID,
                UrlSlug = post.UrlSlug,
                DateCreate = post.DateCreate,
                Viewed = post.Viewed,
                //LastPostUserName=post.LastPostUserName
            };
            // xử lý nếu có hình ảnh

            if (!string.IsNullOrEmpty(post.Image))
            {
                try
                {
                    //Chuyển hình ảnh về dạng 
                    // Original :
                    // Medium:
                    // Thumb:

                    //_return.Image = JsonConvert.DeserializeObject<ImageURLModel>(post.Image);
                    _return.Image = JsonConvert.DeserializeObject<ImageURLModel>(post.Image);
                    //var t = JsonConvert.DeserializeObject<ImageURLModel>(post.Image.ToString());
                }
                catch (Exception)
                {

                    
                }

            }

            if (LastPostUserName)
            {
                _return.LastPostUserName = post.LastPostUserName;
            }
            //var cat = post.Categories.FirstOrDefault(
            //    c => (string.IsNullOrEmpty(catURL) ? true : c.UrlSlug.CompareTo(catURL) == 0));

            var lt = post.Category;

            if (lt != null)
            {
                _return.Category = Convert(lt);
            }
            //if (cat != null)
            //{
            //    _return.Category = Convert(cat);
            //}
            // nếu FullDecs=true

            if (withFullDesc)
            {
                _return.Title = post.Title;
                _return.Content = post.Content;
                _return.SEOTitle = post.SEOTitle;
                _return.SEOKeyword = post.SEOKeyword;
                _return.SEODescription = post.SEODescription;
                _return.Description = post.Description;
          
            }
            else
            {
                _return.Title = post.Title;
                _return.Content = Utility.TrimLength(post.Content, POST_SHORT_DESC_LIMIT);
            }

            //if (withUser)
            //{
            //    _return.LastPostUser = Convert(post.LastPostUser, withFullDesc: true);
            //}


            if (withTag)
            {
                if (post.Tags.Any())
                {
                    _return.Tags = Convert(post.Tags.ToList());
                }
                
            }
            return _return;
        }

        public static IList<PostItemModel> Convert(
            this IList<Post> listPosst,
            bool withFullDesc = false,
            bool withTag=false,
            bool withUser = false,
            bool LastPostUserName=false,
            string catURL = null
            )
        {
            return listPosst.Where(p => p.IsShow && !p.IsDelete).Select(p =>
              Convert(p,
                withFullDesc: withFullDesc,
                withTag:withTag,
                withUser: withUser,
                LastPostUserName:LastPostUserName,
                catURL: catURL
              )).ToList();
        }
        #endregion

        // 
        #region Category
        public static CategoryItemModel Convert(
            this Category category,
            bool withFullDesc = false,
            bool withParner = false,
            bool withSEO = false
            )
        {
            var _return = new CategoryItemModel()
            {
                ID = category.ID,
                Name = category.Name,
                UrlSlug = category.UrlSlug,
                ParentID = category.ParentID,
                ChildCategory =Convert(category.ChildCategory.ToList()),
                Quantity=category.Quantity,
                DateCreated=category.DateCreated,
                DateModified=category.DateModified,
                OrderDisplay=category.OrderDisplay,
                IsShow=category.IsShow,
                IsDelete=category.IsDelete,
                IsPublic=category.IsPublic
            };
            if (withFullDesc)
            {
                _return.Description = category.Description;
            }
            if (withSEO)
            {
                _return.SEOTitle = category.SEOTitle;
                _return.SEOKeyword = category.SEOKeyword;
                _return.SEODescription = category.SEODescription;
            }
            if (withParner)
            {
                if (category.ParentCategory != null)
                {
                    _return.ParentCategory = Convert(category.ParentCategory);
                }
            }
            return _return;
        }

        public static List<CategoryItemModel> Convert(
            ICollection<Category> listCategory,
            bool withFullDesc = false,
            bool withParner=false,
            bool withSEO = false)
        {
            return listCategory.Where(c => c.IsShow && !c.IsDelete).Select(c => Convert(
                  c,
                  withFullDesc: withFullDesc,withParner:withParner,
                  withSEO: withSEO)).ToList();
        }
        #endregion


        #region Tag

        public static TagItemModel Convert(
            this Tag tag,
            bool withSeo = false)
        {
            var _return = new TagItemModel()
            {
                Id=tag.Id,
                Name=tag.Name,
                URL=tag.URL,
            };
            if (withSeo)
            {
                _return.SeoTitle = tag.SeoTitle;
                _return.SeoKeyword = tag.SeoKeyword;
                _return.SeoDescription = tag.SeoDescription;
            }

            return _return;
        }

        public static IList<TagItemModel> Convert(
            ICollection<Tag> listTag,
            bool withSEO = false
            )
        {
            return listTag.Where(t => t.IsShow && !t.IsDeleted).Select(t => Convert(t,
                 withSeo: withSEO
                 )).ToList();
           
        }
        #endregion

        #region User

        public static UserItemModel Convert(
            this User user,
            bool withFullDesc = false)
        {
            var _return = new UserItemModel()
            {
                ID = user.Id,
                Email = user.Email

            };
            _return.FullName = user.FullName;
            _return.ImageURL = string.IsNullOrEmpty(user.ImageURL) ? IMAGE_USER_DEFAULE : user.ImageURL;
            _return.AuthorName = user.AuthorName;
            if (withFullDesc)
            {
                _return.Description = user.Description;
            }
            else
            {
                _return.ImageURL = IMAGE_USER_DEFAULE;
            }
            return _return;
    }
        #endregion
    }
}