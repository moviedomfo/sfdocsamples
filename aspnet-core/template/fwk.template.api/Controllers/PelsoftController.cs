using System;
using System.Collections.Generic;
using System.Net;
using pelsoft.api.common;
using pelsoft.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pelsoft.api.service;
using Fwk.Exceptions;

namespace pelsoft.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PelsoftController : ControllerBase
    {
        private readonly IpelsoftService service;

        public PelsoftController(IpelsoftService service)
        {
            this.service = service;

        }


        [HttpPost("[action]")]
        public IActionResult ReciveAction(ReciveActionReq req)
        {
            try
            {
                //service.ReciveAction(req);

                return Ok("Se ejecuto correctamente ReciveAction (post)");
            }
            catch (Exception ex)
            {
                apiLogServices.LogError_asynk(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            try
            {

                return Ok("Se ejecuto correctamente Get");
            }
            catch (Exception ex)
            {
                apiLogServices.LogError_asynk(ex);
                return BadRequest(ex.Message);
            }
        }



    }
}