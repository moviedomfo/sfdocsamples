using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq.Dynamic;
using SportsClub.Common;
using SportsClub.Common.BE;

using System.Text;
using System.IO;
using SportsClub.DAC;
using AngularWebApiGrid.Controllers;


namespace SportsClub.Controllers
{

    public class PersonController : ApiController
    {
        /// <summary>
        /// http://localhost:1833/api/Person/getall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/person/getall")]
        public List<PersonFullViewBE> GetAll()
        {
            var list = PersonDAC.SearchByParam_sp("", "", "", true);

            return list;
        }

           [HttpGet]
        [Route("api/person/retorno")]
        public string retorno()
        {
       
            return "hola";
        }
        //http://localhost:51663/api/Person?pageNo=1&pageSize=10&search=&sort=%2BlastName
        //http://localhost:51663/api/customers?pageNo=1&pageSize=10&search=&sort=%2BlastName
        //public PagedResult<PersonFullViewBE> Get(int pageNo = 1, int pageSize = 50, [FromUri] string[] sort = null, string search = null)
        //{
        //    // Determine the number of records to skip
        //    int skip = (pageNo - 1) * pageSize;

        //    var list = PersonDAC.SearchByParam_sp(search, "", "", true);
            
        //    // Add the sorting
        //    //if (sort != null)
        //    //    list = list.ApplySorting(sort);
        //    //else
        //    //    list = list.OrderBy(c => c.PersonId);

            


         

        //    // Get the total number of records
        //    int totalItemCount = list.Count();

        //    // Retrieve the persons for the specified page
        //    var persons = list
        //        .Skip(skip)
        //        .Take(pageSize)
        //        .ToList();

        //    // Return the paged results
        //    return new PagedResult<PersonFullViewBE>(persons, pageNo, pageSize, totalItemCount);
        //}
        ////
        //// GET: /Members/Details/5
       
        ////public ActionResult Details(int id)
        ////{
        ////    ManageMemberModel model = new ManageMemberModel();
        ////    model.IsEdit = true;
        ////    PersonBE personBE = ServiceCalls.Member_Get(id);
        ////    if (personBE == null)//TODO: Ver manejo de error
        ////    {
        ////        model.Error = new ErrorModel();
        ////        model.Error.Message = "La actividad con el identificador " + id + " no existe";
        ////        //ModelState.AddModelError(String.Empty, model.Error.Message);
        ////        PortalErrorInfo wPortalErrorInfo = PortalErrorInfo.CreateNew(model.Error.Message);
        ////        wPortalErrorInfo.ErrorTitle = "Error al ejecutar una accion de busqueda";
        ////        wPortalErrorInfo.Redirect = "Index";
        ////        return View("Error", wPortalErrorInfo);
        ////    }

        ////    var list = ServiceCalls.RetriveParams(ParamTypeEnum.DocType, Convert.ToInt32(personBE.DocType));
        ////    ViewBag.DocTypeList = list;
        ////    list = ServiceCalls.RetriveParams(ParamTypeEnum.EstadoCivil, personBE.MaritalStatusId);
        ////    ViewBag.EstadoCivilList = list;


        ////    list = ServiceCalls.RetriveParams(ParamTypeEnum.Sex, personBE.Sex);
        ////    ViewBag.SexList = list;
        ////    list = ServiceCalls.RetriveParams(ParamTypeEnum.MemberType, personBE.FamilyGroupMemberType);

        ////    //Esta info es temporal sirve para validar cambios de grupo familiar
        ////    model.NewFamilyGroupMemberType = personBE.FamilyGroupMemberType;
        ////    model.NewFamilyGroupName = personBE.FamilyGroupName;
        ////    ViewBag.MemberTypeList = list;

        ////    List<SportsClub.Common.BE.ProvinceBE> provinces = ServiceCalls.RetriveProvinces();

        ////    list = new SelectList(provinces, "ProvinceId", "Name", personBE.ProvinceId.Value);
        ////    ViewBag.Provinces = list;

        ////    list = ServiceCalls.Retrive_Cities(personBE.ProvinceId.Value, personBE.CityId);
        ////    ViewBag.Cities = list;

        ////    list = ServiceCalls.Member_RetriveStates(personBE.MemberState);
        ////    ViewBag.MemberStates = list;

        ////    model.CurrentPerson = personBE;
        ////    model.PhotoGuid = Guid.NewGuid();
        ////    model.ContainAvatar = ServiceCalls.Member_Contain_Photo(personBE.PersonId);


        ////    list = ServiceCalls.RetriveParams(ParamTypeEnum.TipoSanguinio, null);
        ////    ViewBag.BlodType = list;
        ////    return View(model);
        ////}
     

        
        


        


    }

    public class SearchPersonParams
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }
    
   
}