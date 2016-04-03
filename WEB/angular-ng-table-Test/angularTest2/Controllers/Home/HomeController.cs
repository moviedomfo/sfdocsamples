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

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");

        }
        public ActionResult aggrid()
        {
            return View("aggrid");

        }
        public ActionResult test()
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