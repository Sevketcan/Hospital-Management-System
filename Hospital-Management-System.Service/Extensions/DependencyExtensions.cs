
using Hospital_Management_System.DataAccess.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System.DataAccess.Contexts;


namespace Hospital_Management_System.Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
               opt =>
               {
                   opt.Password.RequireNonAlphanumeric = false;
                   opt.Password.RequiredLength = 3;
                   opt.Password.RequireLowercase = false;
                   opt.Password.RequireUppercase = false;
                   opt.Password.RequireDigit = false;

                   opt.User.RequireUniqueEmail = true;  //aynı email adresinin girilmesine izin vermez.

                   //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  //Kullanıcı adı girilirken sadece bu karakterlere izin verir.

                   opt.Lockout.MaxFailedAccessAttempts = 3; //default=5
                   opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default=5
               }
           ).AddEntityFrameworkStores<HospitalDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                //opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                opt.SlidingExpiration = true; //10 dk. dolmadan kullanıcı yeniden login olursa süre baştan başlar.

                opt.Cookie = new CookieBuilder()
                {
                    Name = "Identity.App.Cookie",
                    HttpOnly = true
                };
            });

        }
    }
}


