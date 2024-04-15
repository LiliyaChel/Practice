using kidstrWebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace kidstrWebApi
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "workstation id=kidstrWebApiDB.mssql.somee.com;packet size=4096;user id=chellil;pwd=onushelnarassvete;data source=kidstrWebApiDB.mssql.somee.com;persist security info=False;initial catalog=kidstrWebApiDB";
            services.AddDbContext<KidstrContext>(options => options.UseSqlServer(connectionString));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
