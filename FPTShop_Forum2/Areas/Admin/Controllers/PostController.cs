﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTShop_Forum2.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }
    }
}