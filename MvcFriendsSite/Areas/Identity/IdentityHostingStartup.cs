using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcFriendsSite.Areas.Identity.Data;
using MvcFriendsSite.Data;

[assembly: HostingStartup(typeof(MvcFriendsSite.Areas.Identity.IdentityHostingStartup))]
namespace MvcFriendsSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BlogPostContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BlogPostContextConnection")));

                services.AddDefaultIdentity<BlogPostUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<BlogPostContext>();
            });
        }
    }
}