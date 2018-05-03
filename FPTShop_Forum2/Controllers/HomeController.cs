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
    [RequireHttps]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        private CategoryServices _cs = CategoryServices.GetInstance();
        private PostServices _ps = PostServices.GetInstance();
        // GET: Category

        private int HOME_HOT_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeHotPostNumInPage"]);//14 //HomeHotPostNumInPage
        private int HOME_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["HomeListPostNumInPage"]); // 6 //HomeHotPostNumInPage
        private int CATEGORY_LIST_POST_NUM_IN_PAGE => int.Parse(ConfigurationManager.AppSettings["CategoryListPostNumInPage"]); //8

        private const string CACHE_KEY_HOME = "home-category";
        private const string CACHE_KEY_POST_HOME = "home-post";



        public ActionResult Index()
        {
            // var ListPostsNum=Request.Browser.IsMobileDevice?
            PostListModel model = new PostListModel();
            model = this.CacheGetOrSet<PostListModel>("Home-Post", CacheRegion.Post, () =>
                {
                    var homepost = new PostListModel();
                    var post = _ps.GetListPost(HOME_LIST_POST_NUM_IN_PAGE, hotPostNum: 0);// ko có LastPostUserName
                    homepost.Posts = post.Convert(withFullDesc: true);
                    return homepost;
                });
            if (model == null)
                return HttpNotFound();
            return View(model);
        }
        
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
            ViewBag.catChild = Session["catChild"];
            ViewBag.grandCat = Session["grandCat"];
            //Session["catChild"] = null;
           // Session["grandCat"] = null;
            return PartialView(model);
        }

        //public ActionResult ListChildCategory(string catChildURL)
        //{
        //    var catChild = _cs.GetList().ToList();
        //    return PartialView(catChild);
        //}

        public ActionResult ListPostCategory(string  catURL)
        {
            var grandchild = (List<CategoryItemModel>)Session["catChild"];

            if (grandchild!=null)
            {
                int cat1 = 0;
                foreach (var item in grandchild.Select(c => c.UrlSlug))
                {
                    if (item.Contains(catURL))
                    {
                        cat1++;
                    }
                }
                //// kiểm tra bấm vào cat con thứ 1.               
                var grand = _cs.GetListChild(catURL);
                if (grand.Count() > 0)
                {
                    List<CategoryItemModel> chat = new List<CategoryItemModel>();
                    var kq = grand.ToList();
                    //var haha= grand.FirstOrDefault(x=>x.id)
                    chat = ConvertModel.Convert(kq, withFullDesc: true, withParner: true, withSEO: true);
                    //Session["grandCat"] = chat;
                    Session["grandCat"] = chat;
                }
               
                var Catgrand = (List<CategoryItemModel>)Session["grandCat"];
                int cat2 = 0;
                if (Catgrand != null)
                {
                    foreach (var item in Catgrand.Select(c => c.UrlSlug))
                    {
                        if (item.Contains(catURL))
                        {
                            cat2++;
                        }
                    }
                }
              
                // kiểm tra khi bấm vào con thứ 2
                
                if(cat2==0 && cat1==0)
                {
                    Session["grandCat"] = null;
                    Session["catChild"] = null;
                }
                          
                // mặc định nó sẽ lưu Session của hai cái đầu tiên , nhiệm vụ của mình là sẽ so sánh cái URL mình truyền vào nó
                // có thuộc thuộc vào chính nó hoặc con của nó không, nếu không thì xóa Session.

                // Nếu như bấm vào Cái GrandChild thì nó sẽ ra URL =0.
                // Nếu như vậy nó sẽ xóa hết cat đã show => làm sao khi bấm vào đó nó vẫn giữ trạng thái.
            }
                       
            if (Session["grandCat"] == null && Session["catChild"]==null)
            {
                List<CategoryItemModel> catmodel = new List<CategoryItemModel>();
                var catChild = _cs.GetListChild(catURL);
                catmodel = ConvertModel.Convert(catChild, withFullDesc: true, withParner: true, withSEO: true);
                
                Session["catChild"] = catmodel;
            }
            
            string layout = "Layout/";
            PostListModel model;
            try
            {
               
                model = this.CacheGetOrSet($"{catURL}-p1", CacheRegion.Category, () =>
                {
                    var postCat = new PostListModel();
                    int hotNum=0;
                    postCat.category = _cs.GetCategory(url: catURL, haveParner: true).Convert(withSEO: true);

                    var hotPosts = _ps.GetListPostAll(hotNum, categoryID: postCat.category.ID, isHot: true);

                    var Posts = _ps.GetListPost(CATEGORY_LIST_POST_NUM_IN_PAGE, categoryID: postCat.category.ID, hotPostNum: hotNum);

                    var LastPostUserName = _ps.GetListPostLastUserName(CATEGORY_LIST_POST_NUM_IN_PAGE, categoryID: postCat.category.ID, hotPostNum: hotNum);

                    postCat.HostPosts = hotPosts.Convert(withUser: true,withFullDesc:true,withTag:true);
                                  
                    postCat.Posts = ConvertModel.Convert(Posts,withFullDesc:true,withTag:true);
                    postCat.PostLastUserName = ConvertModel.Convert(LastPostUserName,withFullDesc:true, LastPostUserName: true);
                   
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


        #region Ajax
     
        [HttpGet]
        public PartialViewResult LoadPostHome(int page)
        {
           // PostListModel model = new PostListModel();
           var  model = this.CacheGetOrSet<IList<PostItemModel>>($"{CACHE_KEY_POST_HOME}-{page}", CacheRegion.Home, () =>
            {
                // var morePost = new IList<PostItemModel>();
                int Start = ((page - 2) * HOME_LIST_POST_NUM_IN_PAGE) + HOME_LIST_POST_NUM_IN_PAGE;
                var posts = _ps.GetListPost(HOME_LIST_POST_NUM_IN_PAGE,start:Start,hotPostNum:0);
                var postMore = posts.Convert(withFullDesc: true,withTag:true);
                return postMore;
            });
            if (model == null)
                return null;

            return PartialView("ListPostBox",model);
        }

        [HttpGet]
        public PartialViewResult LoadPostNotNameCategory(int page, string catURL)
        {
           
                var model = this.CacheGetOrSet<IList<PostItemModel>>($"{catURL}-{page}", CacheRegion.Category, () =>
                {              
                    //postcat.category = _cs.GetCategory(catURL, haveParner: true).Convert(withSEO: true);

                    int start = ((page - 2) * CATEGORY_LIST_POST_NUM_IN_PAGE) + CATEGORY_LIST_POST_NUM_IN_PAGE;

                    var posts = _ps.GetListPost(CATEGORY_LIST_POST_NUM_IN_PAGE, start: start, categoryUrl: catURL, hotPostNum: 0);
                                                       
                    var postnotUserName = posts.Convert(withFullDesc: true, withUser: true, withTag: true);
               
                    return postnotUserName;
                });
                if (model == null)
                    return null;
                return PartialView("ListPostBox", model);      
        }

        [HttpGet]
        public PartialViewResult LoadPostNameCategory(int size, string categoryUrl)
        {
            var kq = _cs.GetList().ToList();
            var kt = _ps.GetListPostLastUserName(32,categoryUrl: categoryUrl);
            int Start = ((size - 2) * CATEGORY_LIST_POST_NUM_IN_PAGE) + CATEGORY_LIST_POST_NUM_IN_PAGE;
            var model = this.CacheGetOrSet<IList<PostItemModel>>($"{size}-{categoryUrl}", CacheRegion.ChildCategory, () =>
            {
                //var category = _cs.GetCategory(categoryUrl, haveParner: true).Convert(withFullDesc: true, withSEO: true);
                //int start = ((size - 2) * CATEGORY_LIST_POST_NUM_IN_PAGE) + CATEGORY_LIST_POST_NUM_IN_PAGE;
                var LastPostUserName = _ps.GetListPostLastUserName(CATEGORY_LIST_POST_NUM_IN_PAGE, start: Start, categoryUrl: categoryUrl, hotPostNum: 0);

                return ConvertModel.Convert(LastPostUserName, withFullDesc: true, LastPostUserName: true);

            });

            if (model == null)
                return null;

            return PartialView("ListPostNameBox",model);
        }

        #endregion

        //[HttpPost]
        //public ActionResult UpdateUserInfo(Customer customer)
        //{
        //    var cus = db.Customers.FirstOrDefault(c => c.Email == customer.Email);
        //    if (cus != null)
        //    {
        //        Session["khachhang"] = cus;
        //        return RedirectToAction("Insex", "Home");           
        //    }
        //    else
        //    {
        //        customer = new Customer()
        //        {
        //            ID = customer.ID,
        //            Username=customer.Username,
        //            FullName = customer.FullName,
        //            Email = customer.Email,
        //            Image = customer.Image
        //        };
        //        Session["khachhang"] = customer;
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //        RedirectToAction("Index", "Home");
        //    }

        //    return Json(customer,JsonRequestBehavior.AllowGet);

        //}
        //Lấy Category


    }
}