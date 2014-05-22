using System.Collections.Generic;

namespace WebUI.Services
{
	public interface IExternalService
	{
		IEnumerable<ISomeObject> GetExampleData();
	}
}