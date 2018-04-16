using ASPSnippets.GoogleAPI;
using Facebook;
using Model.Entities;
//using FPTShop_Forum.Models;
using Model.Entities.Identity;
using Model.Services;
using Model.Services.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static FPTShop_Forum2.Models.ProfileAccount;

namespace FPTShop_Forum2.Controllers
{
    [RequireHttps]
    public class LoginSocialController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        CustomerServices _customerServices = CustomerServices.GetInstance();
        // GET: LoginSocial
        public ActionResult Index()
        {
            return View();          
        }

        private Uri RedirectUri
        {
            get {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;
            }
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var access_token = result.access_token;
            if (!string.IsNullOrEmpty(access_token))
            {
                fb.AccessToken = access_token;
                // Get user Information
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email,birthday");
                string id = me.id;
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                DateTime? birthday = me.birthday;
              //  int age = me.age;
                string Id = me.id;


                var user = new Customer();
                user.ID = id;
                user.Email = email;
                user.Username = email;
                user.FullName = firstname + " " + middlename + " " + lastname;

                var cus = _customerServices.InsertForFacebook(user);
                if (cus>0)
                {                   
                    Session["khachhang"] = user;                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["khachhang"] = user;
                    return RedirectToAction("Index", "Home");
                }
                   
            }
            //else
            //{

            //}
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginWithGooglePlus(FormCollection form)
        {
            if (form["provider"] == "Google")
            {
                GoogleConnect.ClientId = "896622894562-eams8dj01aesjt83rq08v7n7qlr42esv.apps.googleusercontent.com";
                GoogleConnect.ClientSecret = "25WEHFLJlTP1136mJx7X4sQb";
                GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
                // GoogleConnect.RedirectUri = "http://localhost:51442/LoginSocial/LoginWithGooglePlus";
                GoogleConnect.Authorize("profile", "email");
                return RedirectToAction("LoginWithGooglePlusConfirmed");
            }
            else if (form["provider"] == "Facebook")
            {
                var fb = new FacebookClient();
                var loginUrl = fb.GetLoginUrl(new
                {
                    client_id = ConfigurationManager.AppSettings["FbAppId"],
                    client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    response_type = "code",
                    scope = "email"
                });
                 return Redirect(loginUrl.AbsoluteUri);
            }
            return RedirectToAction("LoginWithGooglePlusConfirmed");

        }

        [ActionName("LoginWithGooglePlus")]
        public ActionResult LoginWithGooglePlusConfirmed()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                string code = Request.QueryString["code"];
                string json = GoogleConnect.Fetch("me", code);
                GoogleProfile profile = new JavaScriptSerializer().Deserialize<GoogleProfile>(json);


                var cus = db.Customers.Find(profile.Id);
                if (cus != null)
                {
                    Session["khachhang"] = cus;
                    return RedirectToAction("Index", "Home");
                }
                Customer customer = new Customer()
                {
                    ID = profile.Id,
                    FullName = profile.DisplayName,
                    Email = profile.Emails.Find(email => email.Type == "account").Value
                };
                Session["khachhang"] = customer;
                db.Customers.Add(customer);
                db.SaveChanges();
                
            }
            if (Request.QueryString["error"] == "access_denied")
            {
                return Content("access_denied");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Session["khachhang"] = (Customer)Session["khachhang"];
            Session["khachhang"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}