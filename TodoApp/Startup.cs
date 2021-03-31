using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Context;

namespace TodoApp
{
    /* DB First Script:
     * Scaffold-dbContext "Server=LAPTOP-8OE5D2AL\SQLEXPRESS;Initial Catalog=TodoApp;User ID=xlogunit;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir Context -Context TodoAppContext -t  Countries, Users, UserDetails, ContactDetails, AddressDetails -f
     * Set ENV Variable:
     * $env:ASPNETCORE_ENVIRONMENT='Development'
     */
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["ConnectionString:value"];
        }

        public IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoAppContext>(opts => opts.UseSqlServer(ConnectionString));

            // Class Bindings
            // Services

            // Repositories

            // Context
            services.AddScoped<ITodoAppContext, TodoAppContext>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
