﻿// TP01 - Sérgio Wu (CB3025691) / Leonardo de Lima (CB3026655)

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01.Controller;

namespace TP01
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            var builder = new RouteBuilder(app);

            var controller = new BookController();

            builder.MapRoute("livro/nome", controller.GetNameBook);
            builder.MapRoute("livro", controller.GetBook);
            builder.MapRoute("livro/autores", controller.GetAuthorsBook);
            builder.MapRoute("livro/ApresentarLivro", controller.GetHtmlBook);

            var routes = builder.Build();

            app.UseRouter(routes);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
    }
}
