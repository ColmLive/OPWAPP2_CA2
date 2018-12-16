using System.Web.Http;
using WebActivatorEx;
using OPWAPP2;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace OPWAPP2
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
             .EnableSwagger(c =>
             {
                 c.SingleApiVersion("v1", "OPWAPP2");
                 c.IncludeXmlComments(string.Format(@"{0}\bin\OPWAPP2.XML",
                           System.AppDomain.CurrentDomain.BaseDirectory));
                 c.DescribeAllEnumsAsStrings();
             })
             .EnableSwaggerUi();

        }
    }
}

