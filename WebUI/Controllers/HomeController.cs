using System.Web.Mvc;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
	    private readonly IExternalService _service;

	    public HomeController(IExternalService service)
	    {
		    _service = service;
	    }

	    public ActionResult Index()
	    {
		    var data = _service.GetSomeData();
            return View(data);
        }
	}
}