using System.Collections.Generic;
using WebUI.Controllers;

namespace WebUI
{
	public class ExternalService : IExternalService
	{
		public IEnumerable<ISomeObject> GetSomeData()
		{
			yield return new SomeObject
			{
				Caption = "Hello",
				Description = "This is a hello world"

			};
		}
	}
}