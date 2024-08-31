using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config) 
        {
            // Microsoft.AspNetCore.Identity.EntityFrameworkCore;
            services.AddIdentityCore<AppUser>(opt => 
            {
                opt.Password.RequireDigit = false; // Disables the requirement for at least one digit
                opt.Password.RequireLowercase = false; // Disables the requirement for at least one lowercase letter
                opt.Password.RequireNonAlphanumeric = false; // Disables the requirement for non-alphanumeric characters
                opt.Password.RequireUppercase = false; // Disables the requirement for at least one uppercase letter
                opt.Password.RequiredLength = 1; // Sets the minimum length requirement (e.g., 1 character)

            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<DataContext>();

            /////////////////////////////////////////////////////////////

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters 
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            return services;
        }
    }
}