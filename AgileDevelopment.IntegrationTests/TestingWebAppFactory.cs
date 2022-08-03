using System;
using System.Collections.Generic;
using System.Linq;
using AgileDevelopment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AgileDevelopment.IntegrationTests;
public class TestingWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                typeof(DbContextOptions<ApplicationContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryAgileDevelopmentTest");
            });
            //antiforgery
            services.AddAntiforgery(t =>
            {
                t.Cookie.Name = AntiForgeryTokenExtractor.Cookie;
                t.FormFieldName = AntiForgeryTokenExtractor.Field;
            });

            var sp = services.BuildServiceProvider();
            using(var scope = sp.CreateScope())
                using(var appContext = scope.ServiceProvider.GetService<ApplicationContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch
                {
                    throw;
                }
            }

        });

    }
}
