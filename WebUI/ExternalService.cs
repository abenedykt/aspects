using System.Collections.Generic;
using System.Threading;
using WebUI.Controllers;

namespace WebUI
{
	public class ExternalService : IExternalService
	{
		public IEnumerable<ISomeObject> GetSomeData()
		{
			Thread.Sleep(100);
			yield return new SomeObject
			{
				Caption = "Hello",
				Description = "This is a hello world"

			};
		}
	}
}