using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.ViewModels;

namespace MvcTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepo _countryRepo;

        private readonly ILogger<CountryController> logger;
        public CountryController(ICountryRepo countryRepo, ILogger<CountryController> logger)
        {
            _countryRepo = countryRepo;
             this.logger = logger;
        }


        [HttpGet,Route("GetString")]
        public IEnumerable<string> GetString()
        {

            logger.LogInformation("GetString() started");
            try
            {
                throw new Exception("Exception Raised");
             
              return new[] { "v1", "v2" };
            } catch(Exception ex)
            {
                logger.LogInformation(ex.StackTrace);
                return null;
            }
            finally
            {
                logger.LogInformation("Method Ends");
            }
        }

        [HttpGet,Route("GetObject")]
        public Object GetObject()
        {
            var result = new { test = 1 ,test1 = "123" };
            return result;
           // return Ok(result);
        }

        [HttpGet,Route("GeCountries")]
        public async Task<IActionResult> GeCountries()
        {
            try
            {
                //ResponseViewModel ResObj = await _countryRepo.GeCountries();
                //if (ResObj.Status == false && ResObj.Messege == "Something Went Wrong !")
                //{
                //    return BadRequest(ResObj);

                //}
                //else
                //{
                //    return Ok(ResObj);
                //}

                var result = await _countryRepo.GeCountries();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}