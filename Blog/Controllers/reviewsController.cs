using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class reviewsController : Controller
    {
        // GET: reviews
        public ActionResult Index()
        {
            return View();
        }
    }
}