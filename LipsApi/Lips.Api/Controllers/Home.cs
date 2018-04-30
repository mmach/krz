using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lips.Api.Controllers
{
    
//@*"https://stackoverflow.com/questions/6031412/detect-android-phone-via-javascript-jquery"*@
    public class HomeController : Controller
    {
        public ActionResult Index(string url)
        {
         //   if (!String.IsNullOrEmpty(url))
         //   {
         // /      ViewBag.url = url;
         //
         //   }
         //   else
         // /  {
         //       ViewBag.url = "wasapp://";
          //  }
            return View();
        }
        public ActionResult Successed()
        {
            
            return View();
        }
        public ActionResult Rejected()
        {

            return View();
        }
        public ActionResult Cancelled()
        {

            return View();
        }

        public ActionResult Failured()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}