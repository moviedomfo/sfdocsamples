using System;
using System.Collections.Generic;
using System.Net;
using keepcon.api.common;
using keepcon.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepcon.api.service;
using Fwk.Exceptions;

namespace keepcon.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class keepconController : ControllerBase
    {
        private readonly IkeepconService service;

        public keepconController(IkeepconService service)
        {
            this.service = service;

        }


        [HttpPost("[action]")]
        public IActionResult ReciveAction(ReciveActionReq req)
        {
            try
            {
                service.ReciveAction(req);

                return Ok();
            }
            catch (Exception ex)
            {
                apiLogServices.LogError_asynk(ex);
                return BadRequest(ex.Message);
            }
        }

   



    }
}