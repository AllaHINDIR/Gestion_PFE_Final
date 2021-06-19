using System;
using Gestion_PFE.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Gestion_PFE.Areas.Identity.IdentityHostingStartup))]
namespace Gestion_PFE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                
                services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddDefaultUI()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();
                services.AddControllersWithViews();
                services.AddRazorPages();
                services.AddAuthorization(options => {
                    options.AddPolicy("readpolicy",
                        builder => builder.RequireRole("Admin", "Manager", "User"));
                    options.AddPolicy("writepolicy",
                        builder => builder.RequireRole("Admin", "Manager"));
                });

            });
        }
    }
}