using Microsoft.AspNetCore.Mvc;

namespace PresidioAcademy.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CacheController:ControllerBase
{
    [HttpGet]
    public ActionResult getTime()
    {
        
        return Ok(DateTime.Now.Second);
    }
}