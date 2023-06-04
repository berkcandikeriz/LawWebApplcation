using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LawWebSite
{
    public class Global : HttpApplication
    {
        public static Models.Language GlobalLanguage = new Models.Language();
        CommonController commonController = new CommonController();
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            commonController.SetLanguage();
        }
    }
}