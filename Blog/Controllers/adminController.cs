using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class adminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: admin
        [Authorize]
        public ActionResult Index()
        {
            var diaplay = db.creates.ToList();   
            return View(diaplay);
        }

        public ActionResult edit(int id)
        {
            var detail = db.creates.Where(y => y.blogid == id).FirstOrDefault();

            var f = db.AddCategories.ToList();
            foreach (var items in f)
            {
               
                if (detail.AddCategory.catid==items.catid)
                {
                    items.isSelect = true;
                }
            }
            ViewBag.Catagories = f;

            var q = db.Addtags.ToList();
            foreach (var item in q)
            {
                var b = detail.Maptags.Where(x => x.tagid == item.tagid).FirstOrDefault();
                if (b != null)
                {
                    item.isSelected = true;

                }

            }
            ViewBag.Tagss = q;
            return View(detail);
        }




        public ActionResult delete(int id)
        {
            var detail = db.creates.Where(y => y.blogid == id).FirstOrDefault();
            var f = db.AddCategories.ToList();
            foreach (var items in f)
            {

                if (detail.AddCategory.catid == items.catid)
                {
                    items.isSelect = true;
                }
            }
            ViewBag.Catagories = f;


            var q = db.Addtags.ToList();
            foreach (var item in q)
            {
                var b = detail.Maptags.Where(x => x.tagid == item.tagid).FirstOrDefault();
                if (b != null)
                {
                    item.isSelected = true;

                }

            }
            ViewBag.Tagss = q;
            return View(detail);
        }
        [HttpPost]
        public ActionResult deleteblog(int? id)
        {
            var delblog = db.creates.Where(x => x.blogid == id).FirstOrDefault();
            if (delblog != null)
            {
                db.creates.Remove(delblog);
                db.SaveChanges();
                return Json(new { success = true, responseText = "blog are deleted successfully;" }, JsonRequestBehavior.AllowGet);

            }
            else {
                return Json(new { success = true, responseText = "blog already deleted;" }, JsonRequestBehavior.AllowGet);

            }

        }




    }
}