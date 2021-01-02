using System;
using System.Collections.Generic;
using System.Net;
using pelsoft.api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pelsoft.api.service;
using Fwk.Exceptions;
using fwk.template.api.common;
using Microsoft.Extensions.Logging;
using pelsoft.api.common;

namespace pelsoft.api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PelsoftController : ControllerBase
    {
        private readonly IpelsoftService _service;
        private readonly IApiLogServices _logService;
        CustomLogger myLogger;
        

        public PelsoftController(IpelsoftService service, IApiLogServices logService)
        {
            _service = service;
            _logService = logService;
            myLogger = CustomLogger.GetInstance();
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

        [HttpPost("[action]")]
        //[Authorize]
        public IActionResult log(consoleReq req)
        {
            try
            {
                //_logger.LogInformation(100,"info");
                //_logger.LogInformation("info");
                //_logger.LogWarning(" Warning");
                //_logger.LogCritical("LogCritical");
                //_logger.LogError("LogError");

                myLogger.Info("info");

                myLogger.Warning(" Warning " + req.message);

                myLogger.Error("LogError " + req.message);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiErrorResponse(null, ex));
            }
        }

    }
    public class consoleReq
    {

        public string message { get; set; }

    }
}