using System;
using System.Collections.Generic;
using System.Net;
using pelsoft.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pelsoft.api.service;
using Fwk.Exceptions;
using fwk.template.api.common;

namespace pelsoft.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PelsoftController : ControllerBase
    {
        private readonly IpelsoftService _service;
        private readonly IApiLogServices _logService;


        public PelsoftController(IpelsoftService service, IApiLogServices logService)
        {
            _service = service;
            _logService = logService;
        }  


        [HttpPost("[action]")]
        public IActionResult ReciveAction(ReciveActionReq req)
        {
            //try
            //{
                _service.ReciveAction(req);

                return Ok("Se ejecuto correctamente ReciveAction (post)");
            //}
            //catch (Exception ex)
            //{
            //   // _logService.LogError_asynk(ex);
            //    return BadRequest(ex.Message);
            //}
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
                var apiErrRes = new ApiErrorResponse(null, ex);
                return StatusCode((int)apiErrRes.StatusEnum, apiErrRes);
            }
        }



    }
}