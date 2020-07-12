using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MvcTaskManager.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<CountryController> logger;
        public ErrorController(ILogger<CountryController> logger)
        {
            this.logger = logger;
        }

        [Route("Error")]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

            logger.LogError($"The path {exceptionDetails.Path} " + $"threw an exception {exceptionDetails.Error}");

            return View("Error");
        }


        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeReuslt = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    logger.LogWarning($"404 Error Occured path {statusCodeReuslt.OriginalPath} " + $"threw an exception {statusCodeReuslt.OriginalPath}"
                        + $"and query string {statusCodeReuslt.OriginalQueryString}");
                    break;
            }

            return View("NotFound");
        }
    }
}