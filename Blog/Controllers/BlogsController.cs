using Blog.Models;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Blog.Controllers
{
    public class BlogsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Catagory
        public ActionResult Index(int? page)
        {
            //new blog are shown first that are added or update blog are shown first
            var model = db.creates.OrderByDescending(x => x.UpdatedDate).ToList();
            ViewBag.addblog = model;
            // pagination 
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult blogdetails(int id)
        {
            //blog details are render using blog id
            var detail = db.creates.Where(y => y.blogid == id).FirstOrDefault();
            return View(detail);
        }

        public ActionResult addcatagory( )
        {
            return View();
        }
        public ActionResult addtag()
        {
            return View();
        }
        public ActionResult addblog()
        {
            //List<AddCategory> countryList = db.AddCategories.ToList();
            //ViewBag.Country = new SelectList(countryList, "catid", "catname");
            //in view when render addblog page dropdown list of add catagory and add tag are auto selected from data base tables of addcatagory and addtags
            var f = db.AddCategories.ToList();
            ViewBag.Catagories = f;

            var q = db.Addtags.ToList();
            ViewBag.Tagss = q;
            return View();
        }
        public ActionResult blogdetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addcatagory(AddCategory category)
        {
            //catagory are added here in database
            if (ModelState.IsValid)
            {
                db.AddCategories.Add(category);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Your catagory are successfuly added" }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult addtag(Addtag tg)
        {
            //tags are added here in database
            if (ModelState.IsValid)
            {
                db.Addtags.Add(tg);
                db.SaveChanges();
                return Json(new { success = true, responseText = "Your blog are successfuly posted!" }, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public  ActionResult addblog(Create crt)
        {

            if (crt.blogid == 0)
            {
                var allowedExtensions = new[] {
            ".jpg",".png" ,".PNG",".webp", ".jpeg"
                };

                var ext = Path.GetExtension(crt.ImageFile.FileName);
                var ext2 = Path.GetExtension(crt.pImageFile.FileName);

                try
                {
                    if (allowedExtensions.Contains(ext) && allowedExtensions.Contains(ext2))
                    {
                          
                        //blog image start
                        string filename = Path.GetFileName(crt.ImageFile.FileName);
                        string bfolder = Server.MapPath("/Content/bfilename");
                        string path = Path.Combine(bfolder, DateTime.Now.ToString("yyyy_MM_dd_mm_ss") + "_" + filename);
                        filename = Path.GetFileName(path);
                        string bspatt = "/Content/bfilename/"+ filename;
                        
                        if (!Directory.Exists(bfolder))
                        {
                            Directory.CreateDirectory(bfolder);
                        }
                        crt.ImageFile.SaveAs(path);
                        crt.bFileName = filename;
                        crt.bFilePath = bspatt;
                        //blog image end



                        //publishblog image start
                        string pfilename = Path.GetFileName(crt.pImageFile.FileName);
                        string pfolder = Server.MapPath("/Content/pfilename");
                        string ppath = Path.Combine(pfolder, DateTime.Now.ToString("yyyy_MM_dd_mm_ss") + "_" + pfilename);
                        pfilename = Path.GetFileName(ppath);
                        string pspatt = "/Content/bfilename/" + pfilename;

                        if (!Directory.Exists(pfolder))
                        {
                            Directory.CreateDirectory(pfolder);
                        }
                        crt.pImageFile.SaveAs(ppath);
                        crt.pFileName = pfilename;
                        crt.pFilePath = pspatt;
                        //publishblog image end


                        crt.CreatedDate = DateTime.Now;
                        crt.CreatedBy = User.Identity.Name;
                        crt.UpdatedDate = DateTime.Now;
                        db.creates.Add(crt);
                        db.SaveChanges();
                        crt.tags = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<int>>(crt.tagss);
                        foreach (var item in crt.tags)
                        {
                            Maptag tg = new Maptag();
                            tg.blogid = crt.blogid;
                            tg.tagid = item;
                            db.maptags.Add(tg);
                            db.SaveChanges();
                        }
                        return Json(new { success = true, responseText = "Your blog are successfuly created!" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { success = true, responseText = "something went wrong;" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {


                    return Json(new { success = true, responseText = "something went wrong;" }, JsonRequestBehavior.AllowGet);
                }
                //var yourObject = new JavaScriptSerializer().Deserialize(crt.tagss);
            }
            //if addblog section of blog start


            //else update section of blog start
            else
            {
                //match the extention of images
                var allowedExtensions = new[] {
                ".jpg",".png" ,".PNG",".webp", ".jpeg"
                };
                var ext = Path.GetExtension(crt.ImageFile.FileName);
                try
                {
                    if (allowedExtensions.Contains(ext))
                    {
                        

                        //blog image start
                        string filename = Path.GetFileName(crt.ImageFile.FileName);
                        string bfolder = Server.MapPath("/Content/bfilename");
                        string path = Path.Combine(bfolder, DateTime.Now.ToString("yyyy_MM_dd_mm_ss") + "_" + filename);
                        filename = Path.GetFileName(path);
                        string bspatt = "/Content/bfilename/" + filename;

                        if (!Directory.Exists(bfolder))
                        {
                            Directory.CreateDirectory(bfolder);
                        }
                        crt.ImageFile.SaveAs(path);
                        crt.bFileName = filename;
                        crt.bFilePath = bspatt;
                        //blog image end



                        //publishblog image start
                        string pfilename = Path.GetFileName(crt.pImageFile.FileName);
                        string pfolder = Server.MapPath("/Content/pfilename");
                        string ppath = Path.Combine(pfolder, DateTime.Now.ToString("yyyy_MM_dd_mm_ss") + "_" + pfilename);
                        pfilename = Path.GetFileName(ppath);
                        string pspatt = "/Content/pfilename/" + pfilename;

                        if (!Directory.Exists(pfolder))
                        {
                            Directory.CreateDirectory(pfolder);
                        }
                        crt.pImageFile.SaveAs(ppath);
                        crt.pFileName = pfilename;
                        crt.pFilePath = pspatt;
                        //publishblog image end

                   
                        crt.UpdatedDate = DateTime.Now;
                        crt.UpdatedBy = User.Identity.Name;





                        db.creates.Attach(crt);
                        db.Entry(crt).State = EntityState.Modified;
                        db.SaveChanges();

                        var mapstag = db.maptags.Where(c => c.blogid == crt.blogid).ToList();
                        foreach (var tagsss in mapstag)
                        {
                            var previoustag = db.maptags.Find(tagsss.maptagid);
                            if (previoustag != null)
                            {
                                db.maptags.Remove(previoustag);
                                db.SaveChanges();
                            }
                            
                        }

                        crt.tags = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<int>>(crt.tagss);
                        foreach (var item in crt.tags)
                        {
                            Maptag tg = new Maptag();
                            tg.blogid = crt.blogid;
                            tg.tagid = item;
                            db.maptags.Add(tg);
                            db.SaveChanges();
                        }
                        return Json(new { success = true, responseText = "Your blog are successfuly updated!" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { success = true, responseText = "something went wrong;" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {

                    return Json(new { success = true, responseText = "something went wrong;" }, JsonRequestBehavior.AllowGet);
                }
            }
            //else update section of blog end
        }

    }
}