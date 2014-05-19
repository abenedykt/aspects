using System;
using System.Diagnostics;
using Castle.DynamicProxy;

namespace WebUI
{
	internal class LoggingAspect : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			try
			{
				Trace.WriteLine("Starting");
				var start = DateTime.Now;
				invocation.Proceed();
				var end = DateTime.Now;
				Trace.WriteLine("Ended");
				Trace.WriteLine("    time : " + end.Subtract(start).Milliseconds + "ms");
			}
			catch (Exception ex)
			{
				Trace.TraceError(ex.Message);
			}

		}
	}
}