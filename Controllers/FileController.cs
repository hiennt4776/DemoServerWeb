using System;
using System.Collections.Generic;
using System.Linq;


using System.IO;
using System.Web;
using System.Web.Mvc;


namespace DemoServerWeb.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
            }

            return View();
        }

        public FileResult Download(string fileName)
        {
            var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
            return File(path, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public ActionResult Log()
        {
            try
            {
                string content = string.Empty;
                using (var stream = new StreamReader(Server.MapPath("~/uploads/version.txt")))
                {
                    content = stream.ReadToEnd();
                }
                return Content(content);
            }
            catch (Exception ex)
            {
                return Content("Something ");
            }
        }

        //[HttpGet]
        //public ActionResult Demo()
        //{
        //    try
        //    {
        //        string content = string.Empty;
        //        using (var stream = new StreamReader(Server.MapPath("~/uploads/Demo.zip")))
        //        {
        //            content = stream.ReadToEnd();
        //        }
        //        return Content(content);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content("Something ");
        //    }
        //}
    }
}