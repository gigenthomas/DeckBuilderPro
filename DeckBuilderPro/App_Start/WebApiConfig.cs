using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DeckBuilderPro
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "VsSystemDeck",
                routeTemplate: "api/VsSystem/Deck/{id}",
                defaults: new { Controller = "VsSystemDecks", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "VsSystemDeckCard",
                routeTemplate: "api/VsSystem/DeckCard/{id}",
                defaults: new { Controller = "VsSystemDeckCards", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "VsSystemCollection",
                routeTemplate: "api/VsSystem/Collection/{id}",
                defaults: new { Controller = "VsSystemCollections", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
