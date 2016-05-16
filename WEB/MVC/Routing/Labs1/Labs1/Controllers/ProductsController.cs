using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Labs1.Models;
using Labs1.Providers;
using Labs1.Results;

namespace Labs1.Controllers
{
    /// <summary>
    /// Attribute Routing in ASP.NET MVC 5
    /// https://blogs.msdn.microsoft.com/webdev/2013/10/17/attribute-routing-in-asp-net-mvc-5/#why-attribute-routing
    /// Attribute Routing in ASP.NET Web API 2
    /// http://www.asp
    public class ProductsController : ApiController
    {
        /// <summary>
        /// http://localhost:2838/api/Products/1/retrivelist/
        /// http://localhost:2838/api/Products/69/retrivelist/
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Products/{type}/retrivelist")]
        public List<ProductBE> typesRetriveList(string type)
        {
            List<ProductBE> list = new List<ProductBE>();
            list.Add(new ProductBE { Name = "auto", Id = 123 });
            list.Add(new ProductBE { Name = "camion", Id = 234 });
            list.Add(new ProductBE { Name = "carreta", Id = 09 });
            list.Add(new ProductBE { Name = "auto", Id = 123 });
            list.Add(new ProductBE { Name = "camion", Id = 234 });
            list.Add(new ProductBE { Name = "carreta", Id = 09 });
            list.Add(new ProductBE { Name = "auto", Id = 123 });
            list.Add(new ProductBE { Name = "camion", Id = 234 });
            list.Add(new ProductBE { Name = "carreta", Id = 09 });
            return list;
        }

        /// <summary>
        /// http://localhost:2838/api/Products/retrivelist/88
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Products/retrivelist/{type}")]
        public List<ProductBE> RetriveList(string type)
        {
            List<ProductBE> list = new List<ProductBE>();
            list.Add(new ProductBE { Name = "auto", Id = 123 });
            list.Add(new ProductBE { Name = "camion", Id = 234 });
            list.Add(new ProductBE { Name = "carreta", Id = 09 });

            return list;
        }

        /// <summary>
        /// http://localhost:2838/api/Products/product/Beer
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Products/product/{isbn}")]
        public string SearchByParams(string isbn)
        {
            return "Se ejecuto el SearchByParams 1" + isbn;
        }

        //        [Route("api/Products/lang/{lang = en}")]
        //http://localhost:2838/api/Products/GetCliente/2
        //http://localhost:44301/api/Products/GetCliente
        [HttpGet]
        [Route("api/Products/GetCliente/{id=2}")]
        public String GetCliente(int id)
        {
            return "Se ejecuto el GetByLang 1" + id;
        }

        /// <summary>
        /// http://localhost:44301/api/Products/get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Products/Get")]
        public String Get()
        {

            return "Se ejecuto el Get 1";
        }
        [HttpGet]
        [Route("api/Products/Get2")]
        public String Get2()
        {

            return "Se ejecuto el Get2";
        }

        [HttpGet]
        [Route("api/Products/Get2/{id}")]
        public String Get2(int id)
        {
            return "Se ejecuto el Get2 con paramatro " + id.ToString();
        }

        [HttpGet]
        [Route("api/Products/Factura/{id=-1}/{clienteId= -1}")]
        public string Factura(int id, int clientId)
        {
            return "Se ejecuto el Factura con paramatro " + id.ToString() + " " + clientId.ToString();

        }

    }
    public class ProductBE
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProdTyep { get; set; }
    }
}
