namespace GP.Test.Apis.Controllers
{
    using Gp.Test.Api.DTO;
    using Gp.Test.Interface.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<PersonasDTO>? GetAll()
        {
            return null;
        } 
    }
}
