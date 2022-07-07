using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_GerenciadorDeConteudo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapRoute(
                "Arquivos",
                "Arquivos",
                new { Controller = "Arquivos", Action = "Index" }
             );

            routes.MapRoute(
              "arquivos_criar",
              "arquivos/criar",
              new { Controller = "Arquivos", Action = "criar" }
           );
            routes.MapRoute(
               "arquivos_exluir",
               "arquivos/{id}/excluir",
               new { Controller = "Arquivos", Action = "Excluir", id = 0 }
            );

            routes.MapRoute(
               "paginas_alterar",
               "arquivos/{id}/alterar",
               new { Controller = "Arquivos", Action = "Alterar", id = 0 }
            );
            routes.MapRoute(
               "arquivos_editar",
               "arquivos/{id}/editar",
               new { Controller = "Arquivos", Action = "Editar", id = 0 }
            );

            routes.MapRoute(
               "paginas_novo",
               "paginas/novo",
               new { Controller = "Arquivos", Action = "Novo" }
            );


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Arquivos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}