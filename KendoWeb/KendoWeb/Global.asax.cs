using Mindscape.LightSpeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KendoWeb.Model;
using Mindscape.LightSpeed.Logging;

namespace KendoWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static readonly LightSpeedContext<KendoWebUnitOfWork> LightSpeedDataContext = new LightSpeedContext<KendoWebUnitOfWork>("ConnDB");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

#if DEBUG
            LightSpeedDataContext.Logger = new TraceLogger();
#endif
        }
    }
}
