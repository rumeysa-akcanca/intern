using Microsoft.AspNetCore.Mvc;


namespace InterApi;

[ApiController]
[Route("interapi/v1.0/[controller]/[action]")]
public class GenericBaseApiController : ControllerBase
{
    [HttpGet]
    public string HeartBeat()
    {
        return DateTime.UtcNow.ToLongDateString();
    }
}
