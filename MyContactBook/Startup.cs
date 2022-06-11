using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyContactBook.Database;
using MyContactBook.Database.Repository;
using MyContactBook.Models;
using System;

namespace MyContactBook
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);

            services.AddTransient<IRepository, Repository>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            try
            {
                var connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));

                services.AddDbContext<AppDbContext>(builder => builder.UseSqlite(connection));
                var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options;
                var context = new AppDbContext(options);

                context.Database.OpenConnection();

                context.Database.EnsureCreated();

                Person person1 = new Person { Name = "Milan", Surname = "Les", PhoneNumber = 321365639, Email = "milan@les.com" };
                Person person2 = new Person { Name = "Jana", Surname = "Zelena", PhoneNumber = 123123321, Email = "jana@zelena.com" };
                Person person3 = new Person { Name = "Zuzana", Surname = "Fialova", PhoneNumber = 147258369, Email = "zuzana@fialova.com" };

                context.Contacts.Add(person1);
                context.Contacts.Add(person2);
                context.Contacts.Add(person3);

                context.SaveChanges();
            }
            catch (SqliteException sqle)
            {
                sqle.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
