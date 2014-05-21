using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WebUI.Aspects;
using WebUI.Services;

namespace WebUI
{
	public static class AutofacConfig
	{
		public static void RegisterComponents()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(typeof(Global).Assembly);

			builder.RegisterType<ExternalService>().As<IExternalService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingAspect));
			builder.RegisterInstance(new LoggingAspect());
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			var container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}