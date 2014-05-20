using System.Collections.Generic;
using System.Threading;

namespace WebUI.Services
{
	public class ExternalService : IExternalService
	{
		public IEnumerable<ISomeObject> GetSomeData()
		{
			Thread.Sleep(1000);

			return new[]
			{
				new SomeObject
				{
					Caption = "Hello",
					Description = "This is a hello world"
				}
			};
		}
	}
}