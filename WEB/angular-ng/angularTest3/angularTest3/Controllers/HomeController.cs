using SportsClub.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angularTest3.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult Index()
        {
            return View("Index");

        }
        public ActionResult directives()
        {
            return View();

        }

        public ActionResult ng_factory()
        {
            return View();

        }
        public ActionResult ng_promise()
        {
            return View();

        }
        /// <summary>
        /// https://carlosazaustre.es/blog/uso-de-promesas-en-angularjs/
        /// </summary>
        /// <returns></returns>
        public ActionResult ng_service()
        {
            return View();

        }
        public ActionResult test()
        {
            return View();
        }

        public ActionResult ng_validations()
        {
            return View();
        }
     
        public JsonResult GetAll()
        {
            var list = PersonDAC.SearchByParam_sp("", "", "", true);

            return Json(list, JsonRequestBehavior.AllowGet);
            
        }
    }
}