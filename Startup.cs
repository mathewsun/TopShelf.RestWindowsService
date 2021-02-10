using Owin;
using System.Linq;
using System.Web.Http;

namespace TopShelf.RestWindowsService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = ConfigureApi();
            app.UseWebApi(config);
        }

        private HttpConfiguration ConfigureApi()
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{action}",
                new { id = RouteParameter.Optional });

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            return config;
        }
    }
}
