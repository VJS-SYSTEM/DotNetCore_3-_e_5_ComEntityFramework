using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Pedidos.Repository;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.OpenApi.Models;

namespace Pedidos.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public DbConnection DbConnection => new NpgsqlConnection(Configuration.GetConnectionString("Pedidos"));
       public DbConnection DbConnection1 => new SqlConnection(Configuration.GetConnectionString("Pedidos1"));

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public  void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api com Entity Framework", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(
                    DbConnection,
                    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).FullName));
                //options.UseSqlServer(
                //    DbConnection1,
                //    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).FullName));

            });
            DependencyInjection.Register(services);  //criado uma classe concreta
            services.AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling
             = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api com Entity Framework"));
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
