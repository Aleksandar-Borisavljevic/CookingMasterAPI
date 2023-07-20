using Microsoft.AspNetCore.Mvc;

namespace CookingMasterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public int ID { get; set; }

        [HttpGet("RandomNumber/{ID}")]
        public int ReturnRandomNumber()
        {
            ID = 5;
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        [HttpGet("RandomNumber")]
        public int VratiRandomBroj()
        {            
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }

        [HttpPost]

        public int SumirajDvaBroja(int x, int y)
        {
            return x + y;
        }

        [HttpGet("RandomNumberWithQuery")]
        public int VratiRandomBroj(int x, int y)
        {
            Random rnd = new Random();
            return rnd.Next(x, y);
        }

        [HttpGet("RandomNumberWithQueryV2")]
        public int VratiRandomBrojV2(int x, int y)
        {
            Random rnd = new Random();
            return rnd.Next(x, y);
        }
    }
}
