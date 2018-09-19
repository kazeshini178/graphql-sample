using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleQL.GraphQLTypes;

namespace SampleQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(action =>
                action.AddPolicy("dev", builder =>
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .Build()
                    )
                );


            services.AddSingleton<QLSchema>();
            services.AddSingleton<GoodReadsQuery>();
            services.AddSingleton<CommentsMutation>();
            services.AddSingleton<CommentsSubscriptions>();
            services.AddSingleton<GoodReadsService>();

            services.AddGraphQL(options =>
                {
                    options.ExposeExceptions = true;
                    options.EnableMetrics = true;
                })
                .AddWebSockets();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("dev");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets()
                .UseGraphQLWebSockets<QLSchema>()
                .UseGraphQL<QLSchema>();

            app.UseMvc();
        }
    }
}
