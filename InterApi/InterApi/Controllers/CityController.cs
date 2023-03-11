using Microsoft.AspNetCore.Mvc;
using N11CityServiceConnection;

namespace InterApi.Controllers
{

    [ApiController]
    [Route("interapi/v1.0/[controller]")]
    public class CityController : ControllerBase
    {
        public CityController()
        {

        }



        [HttpGet]
        public async Task<string> GetAsync()
        {
            CityServicePortClient service = new();
            GetCitiesRequest request = new();
            request.auth = new Authentication();
            request.auth.appSecret = "";
            request.auth.appKey = "";
            var response = await service.GetCitiesAsync(request);
            if (response.GetCitiesResponse.result.status != "success")
            {     }
            return string.Empty;
        }


    }


}