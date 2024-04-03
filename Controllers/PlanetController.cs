using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebAppMVC_1.Services;

namespace WebAppMVC_1.Controllers
{
    [Route("Planet111/[Action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;
        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }
        [Route("list-of-planet.html", Name="List1" , Order =2)] // Địa chỉ tương đối ( phụ thuộc vào Controller)
        [Route("/list-of-planet.html", Order =1 )]  // -> Địa chỉ tuyệt đối ( không phụ thuộc vào Controller)
        public IActionResult Index() //-> planet/list-of-planet.html
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "Action")] // -> Name = "Action" để lấy giá trị của Action trên URL

        //[Action], [Controller], [Area]
        public string Name { get; set; }
        [HttpGet("/Mercury.html")]
        public IActionResult Mercury ()
        {
            var planet =   _planetService.Planets.Where(p => p.Name == Name).FirstOrDefault();
            return View("Mercury", planet);
        }
        [Route("sao/[Action]", Order = 2)]         //-> sao/Mercury
        [Route("sao/[Controller]/[Action]", Order = 4)]  // -> sao/Planet/Mercury
        [Route("[Controller]-[Action].html", Order = 3, Name = "PlanetInfo")]
        [Route("star/{idd:int}", Order = 1)]
        public IActionResult PlanetInfo (int idd)
        {
            var planet =  _planetService.Planets.Where(p => p.Id == idd).FirstOrDefault();
            return View(planet);
        }
    }
}
