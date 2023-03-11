using Microsoft.AspNetCore.Mvc;

namespace InterApi;


[NonController]
[ApiController]
[Route("interapi/v1.0/[controller]/[action]")]
public class GenericBaseApiTestController : GenericBaseApiController
{
    public GenericBaseApiTestController()
    {
       
    }


    [HttpGet]
    public string Get(string id)
    {
        return $"Generic  {id}";
    }
}
