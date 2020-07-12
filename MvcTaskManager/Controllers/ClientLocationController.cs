using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Repositories.Contracts;
using MvcTaskManager.ViewModels;

namespace MvcTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientLocationController : ControllerBase
    {
        private readonly IClientLocationRepo _clientLocationRepo;
        public ClientLocationController(IClientLocationRepo clientLocationRepo)
        {
            _clientLocationRepo = clientLocationRepo;
        }

        [HttpGet,Route("GetClientLocations")]
        public async Task<IActionResult> GetClientLocations()
        {
            try
            {

                ResponseViewModel ResObj = await _clientLocationRepo.GetClientLocations();
                if (ResObj.Status == false && ResObj.Messege == "Something went wrong !")
                {
                    
                    return BadRequest(ResObj);
                }
                else
                {
                    return Ok(ResObj);
                }
            }
            catch (Exception ex)
            {
                return null;

            }

        }
    }
}