using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SportsClub.Common;
using SportsClub.Common.BE;

using System.Text;
using System.IO;
using SportsClub.DAC;
using AngularWebApiGrid.Controllers;
using System.Web.Http;

namespace SportsClub.Controllers
{
    

    /// <summary>
    /// JavaScript Promises https://carlosazaustre.es/blog/uso-de-promesas-en-angularjs/
    /// $q                  https://docs.angularjs.org/api/ng/service/$q
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");

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