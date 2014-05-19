using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WebUI.Controllers;

namespace WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
	        BuildApplication();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

	    private void BuildApplication()
	    {
		    var builder = new ContainerBuilder();
		    builder.RegisterControllers(typeof (Global).Assembly);

			builder.RegisterType<ExternalService>().As<IExternalService>().EnableInterfaceInterceptors().InterceptedBy(typeof(LoggingAspect));
		    builder.RegisterInstance(new LoggingAspect());
		    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
		    var container = builder.Build();

			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
	    }
    }
}