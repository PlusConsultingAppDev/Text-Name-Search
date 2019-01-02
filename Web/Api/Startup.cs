﻿using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using App.Membership.Models;
using App.Api.Extensions;
using App.Membership.Data;
using Microsoft.EntityFrameworkCore;
using App.Membership.Filters;
using Serilog;

namespace App.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        public Startup(
            IHostingEnvironment env,
            IConfiguration config)
        {
            this.env = env;
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Machine);
            var appParentDirectory = new DirectoryInfo(this.env.ContentRootPath).Parent.FullName;

            // Lets not take their word for it and use the environment variable and our own convention
            // var environmentName = this.env.EnvironmentName ?? "Development";
            var environmentName = environment ?? "Development";
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(
            IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(this.Configuration)
                .CreateLogger();

            services.AddLogging(x => x.AddSerilog(dispose: true));

            try
            {
                Log.Information("API Started");

                services.AddSingleton(this.Configuration);

                var jwt = this.Configuration.GetSection("Jwt").Get<Jwt>();
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwt.Issuer,
                            ValidAudience = jwt.Issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                        };
                        options.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                // Add the access_token as a claim, as we may actually need it
                                if (context.SecurityToken is JwtSecurityToken accessToken)
                                {
                                    if (context.Principal.Identity is ClaimsIdentity identity)
                                    {
                                        identity.AddClaim(new Claim("access_token", accessToken.RawData));
                                    }
                                }

                                return Task.CompletedTask;
                            },
                        };
                    });

                services
                    .AddMvc(o =>
                    {
                        o.Conventions.Add(new AddAuthorizeFiltersControllerConvention());
                    })
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

                services
                    .AddAuthorization(o =>
                    {
                        o.AddPolicy(
                            "securepolicy",
                            b =>
                            {
                                b.RequireAuthenticatedUser();
                                b.AuthenticationSchemes = new List<string> { JwtBearerDefaults.AuthenticationScheme };
                            });
                    });

                var membershipConnectionString = this.Configuration.GetConnectionString("App.Membership");

                var containerBuilder = ServiceConfiguration.Register(
                    this.AddWebServices,
                    this.Configuration);

                services.AddEntityFrameworkSqlServer().AddDbContext<UserDbContext>(options =>
                {
                    options.UseSqlServer(membershipConnectionString);
                });

                services.AddSwaggerDocumentation();
                services.AddHttpContextAccessor();

                containerBuilder.Populate(services);
                var container = containerBuilder.Build();
                return new AutofacServiceProvider(container);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            return null;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            //app.UseMiddleware<UserContextMiddleware>();
            app.UseAuthentication();
            app.UseMvc();
        }

        private void AddWebServices(ContainerBuilder builder)
        {
        }
    }
}
