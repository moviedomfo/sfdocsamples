using System;
using System.Collections.Generic;
using System.Net;
using Fwk.Database;
using pelsoft.api.common;
using pelsoft.api.helpers;
using pelsoft.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace pelsoft.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaestrosController : ControllerBase
    {
   


        

        [HttpGet("[action]")]
        public IActionResult vista_Ubicacion()
        {
            try
            {
                var c = ColaboradorDAC.vista_Ubicacion();
                if (c == null)
                {
                    return BadRequest(string.Format("No se encontraron datos de {0}", "Ubicacion"));
                }

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]")]
        public IActionResult vista_Sociedad()
        {
            try
            {
                var c = ColaboradorDAC.Vista_Sociedad();
                if (c == null)
                {
                    return BadRequest(string.Format("No se encontraron datos de {0}", "Sociedad"));
                }

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public IActionResult vista_CuentaSubAreaServicio()
        {
            try
            {
                var c = ColaboradorDAC.vista_CuentaSubAreaServicio();
                if (c == null)
                {
                    return BadRequest(string.Format("No se encontraron datos de {0}", "CuentaSubAreaServicio"));
                }

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]")]
        public IActionResult vista_Sucursal()
        {
            try
            {
                var c = ColaboradorDAC.Vista_Sucursal();
                if (c == null)
                {
                    return BadRequest(string.Format("No se encontraron datos de {0}", "Sucursal"));
                }

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Retorna informacion del servidor de pelsoft bot web-api
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult GetServerInfo()
        {
            try
            {

                ApiServerInfo info = new ApiServerInfo();
                info.cnnStrings = new List<ConnectionStringInfo>();
                apiAppSettings.connectionStrings.ForEach(cnn =>
                {
                    var sql = CommonHelpers.Get_SqlConnectionStringBuilder(CommonHelpers.CnnStringNameMeucci);
                    var c = new ConnectionStringInfo();
                    c.name = cnn.name;
                    c.server = sql.DataSource;
                    c.database = sql.InitialCatalog;
                    //c.cnnString = cnn.name = "Coneccion :" + CommonHelpers.CnnStringNameMeucci + " Sql Server = " + sql.DataSource + " BD " + sql.InitialCatalog;

                });


                
                //sql = Common.Get_SqlConnectionStringBuilder(Common.CnnStringNameAD);
                //info.SQLServeramazon = "Coneccion :" + Common.CnnStringNameAD + " Sql Server = " + sql.DataSource + " BD " + sql.InitialCatalog;
                //info.api_bootApiHoock = apiAppSettings.serverSettings.apiConfig.api_bootApiHoock;
                info.Ip = CommonHelpers.Get_IPAddress();
                info.HostName = Dns.GetHostName();

                return Ok(new ApiOkResponse(info));

            }
            catch (Exception ex)
            {
                var msg = apiHelper.getMessageException(ex);
                return BadRequest(new ApiErrorResponse(HttpStatusCode.InternalServerError, msg)); ;
            }
        }


        /// <summary>
        /// Metodo solo para test.
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IActionResult ping()
        {
            return Ok(new ApiOkResponse(string.Format("El servicio Api Epiron host= {0}  e IP = {0}  funciona correctamente",
            Dns.GetHostName(),
            CommonHelpers.Get_IPAddress())));

        }


    }
}