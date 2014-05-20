using System.Collections.Generic;
using WebUI.Controllers;

namespace WebUI.Services
{
	public interface IExternalService
	{
		IEnumerable<ISomeObject> GetSomeData();
	}
}