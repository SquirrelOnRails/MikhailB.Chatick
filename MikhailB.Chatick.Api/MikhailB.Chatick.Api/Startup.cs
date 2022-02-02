using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using MikhailB.Chatick.DataAccess.Chat;
using System;
using Serilog;
using Microsoft.Extensions.Logging;
using MikhailB.Chatick.BusinesLogic.Hubs;
using MikhailB.Chatick.Contracts.Interfaces;
using MikhailB.Chatick.DataAccess.Chat.Repositories;
using MikhailB.Chatick.BusinesLogic.Services;
using MikhailB.Chatick.Api.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace MikhailB.Chatick.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // JWT
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false
                };
            });

            // IDENTITY
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<ChatContext>();

            // ASP.NET
            services.AddControllersWithViews();
            services.AddSignalR();

            // DB
            services.AddDbContext<ChatContext>(
                options => options
                    .UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(Log.Logger.Information, LogLevel.Information)
                    .LogTo(Log.Logger.Error, LogLevel.Error)
                );

            // REPOSITORIES
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // SERVICES
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();

            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MikhailB.Chatick.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // DB testing
                using (var scope = app.ApplicationServices.CreateScope())
                    using (var context = scope.ServiceProvider.GetService<ChatContext>())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }
                
                // SWAGGER
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MikhailB.Chatick.Api v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chathub");
            });
        }
    }
}
