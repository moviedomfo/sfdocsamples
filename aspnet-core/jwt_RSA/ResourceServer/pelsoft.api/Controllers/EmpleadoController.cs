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
    public class EmpleadoController : ControllerBase
    {
      


        [HttpGet("[action]")]
        public IActionResult get(string userName, string domainName)
        {
            try
            {
                var emp = EmpleadosDAC.Get(userName, domainName);
                if (emp == null)
                {
                    return BadRequest(string.Format("No existe registrado un empleado {0}/{1}", userName, domainName));
                }
              
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}