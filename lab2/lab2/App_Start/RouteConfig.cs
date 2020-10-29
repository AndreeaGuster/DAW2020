using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lab2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "SearchSequenceRoute",
                url: "Exercises/Ex1/{word}/{sentence}",
                defaults: new { controller = "Exercises", action = "SearchSequence", word = UrlParameter.Optional, sentence = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SearchSequenceOptionalRoute",
                url: "Exercises/Ex2/{word}/{sentence}",
                defaults: new { controller = "Exercises", action = "SearchSequenceOptional", word = UrlParameter.Optional, sentence = UrlParameter.Optional }
            );

            /*routes.MapRoute(
                name: "RegexParserRoute",
                url: "Exercises/Ex3/{number}",
                defaults: new { controller = "Exercises", action = "NumberRegexParser", number = UrlParameter.Optional},
                //constraints: new { number = @"^[1-9](\d{1,5})[02468]$"}
               constraints: new { number = @"^\d{2,6}[02468]$"}
            );*/

            /*routes.MapRoute(
                name: "RegexParser",
                url: "Parser/Ex4/{input}",
                defaults: new { controller = "Exercises", action = "RegexParser", input = UrlParameter.Optional },
                constraints: new { input = @"^((ab)+)$" }
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
