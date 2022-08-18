using Microsoft.AspNetCore.Mvc;
using CodingChallenges.Services;

namespace CodingChallenges.Controllers
{
    public class ExternalComponentController : Controller
    {  
        [HttpGet("GetStuffFromExternalComponent")]
        public IActionResult Get()
        {
            //TODO: this should be done with dependency injection
            RealExternalComponentService realExternalComponentService = new RealExternalComponentService();
            List<string> list = realExternalComponentService.GetStuff();

            try
            {
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }


    }
}
