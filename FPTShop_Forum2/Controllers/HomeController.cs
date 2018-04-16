using FPTShop_Forum2.Helper;
using FPTShop_Forum2.Helper.Web;
using FPTShop_Forum2.Models;
using FPTShop_Forum2.Models.Post;
using Model.Entities;
using Model.Services;
using Model.Services.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTShop_Forum2.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private CategoryServices _cs = CategoryServices.GetInstance();
        private PostServices _ps = PostServices.GetInstance();
        // GET: Category

        private int CATEGORY_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["CategoryListPostNumInPage"]); //8
        private const string CACHE_KEY_HOME = "home-category";

        // Lấy danh sách Category của trang chủ
        [ChildActionOnly]
        public ActionResult ListCategory()
        {
            var model = this.CacheGetOrSet<List<CategoryItemModel>>(CACHE_KEY_HOME, CacheRegion.Widget, () =>
                {
                    List<Category> cat = new List<Category>();
                    cat =_cs.GetList().ToList();
                    var catdto = ConvertModel.Convert(cat,withFullDesc:true,withParner:true,withSEO:true);
                    return catdto;
                });
            if (model == null)
            {
                return HttpNotFound();
            }
          //var kq = _cs.GetList().ToList();
            
            return PartialView(model);
        }

        public ActionResult ListChildCategory(string catChildURL)
        {
            var catChild = _cs.GetList().ToList();
            return View(catChild);
        }

        public ActionResult ListPostCategory(string  catURL)
        {
            string layout = "Layout/";
            PostListModel model;
            try
            {
                model = this.CacheGetOrSet($"{catURL}-p1", CacheRegion.Category, () =>
                {
                    var postCat = new PostListModel();
                    int hotNum=0;
                    postCat.category = _cs.GetCategory(url: catURL, haveParner: true).Convert(withSEO: true);
                    var hotPosts = _ps.GetListPost(hotNum, categoryID: postCat.category.ID, isHot: true);
                    var Posts = _ps.GetListPost(CATEGORY_LIST_POST_NUM_IN_PAGE, categoryID: postCat.category.ID, hotPostNum: hotNum);

                    postCat.HostPosts = hotPosts.Convert(withUser: true);
                    var t = postCat.HostPosts;

                    //postCat.Posts = Posts.Convert(withUser: true);
                    postCat.Posts = Posts.Convert();

                    var y = postCat.Posts;
                    return postCat;
                });
            }         
            catch (Exception ex)
            {
                return HttpNotFound();
            }
            // Lấy ra những bài Post khi bấm vào mục Category

            return View("Layout/Default",model);
        }

        public ActionResult ListPostHome()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //Lấy Category


    }
}