using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversitasIndonesia.Areas.Identity.Data;
using UniversitasIndonesia.Data;

[assembly: HostingStartup(typeof(UniversitasIndonesia.Areas.Identity.IdentityHostingStartup))]
namespace UniversitasIndonesia.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UniversitasIndonesiaDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UniversitasIndonesiaDbContextConnection")));

                services.AddDefaultIdentity<UniversitasIndonesiaUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                     .AddEntityFrameworkStores<UniversitasIndonesiaDbContext>();

            });
            
            
        }
    }
}