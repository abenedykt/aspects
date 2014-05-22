using System.Web.Mvc;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IExternalService _demoService;

	    public HomeController(IExternalService demoService)
	    {
		    _demoService = demoService;
	    }

	    public ActionResult Index()
	    {
		    var data = _demoService.GetExampleData();
            return View(data);
        }
	}
}