using System.Collections.Generic;
using System.Web.Mvc;

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

	public interface IExternalService
	{
		IEnumerable<ISomeObject> GetSomeData();
	}

	public interface ISomeObject
	{
		string Caption { get; set; }
		string Description { get; set; }
	}

	public class SomeObject : ISomeObject
	{
		public string Caption { get; set; }
		public string Description { get; set; }
	}
}