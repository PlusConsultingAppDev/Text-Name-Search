using System;
using Microsoft.Extensions.Configuration;
using Autofac;
using App.Api.Validators;
using App.Membership;
using Serilog;

namespace App.Api
{
    public class ServiceConfiguration
    {
        public static ContainerBuilder Register(
            Action<ContainerBuilder> additionalRegistration,
            IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IdentityHelper>().As<IdentityHelper>().InstancePerLifetimeScope();
            builder.RegisterType<CreateAccountModel_Validator>().As<CreateAccountModel_Validator>().InstancePerLifetimeScope();
            builder.RegisterType<LoginModel_Validator>().As<LoginModel_Validator>().InstancePerLifetimeScope();

            builder
                .Register<ILogger>((c, p) =>
                {
                    return new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                .CreateLogger();
                }).SingleInstance();

            var platformConnectionString = configuration.GetConnectionString("App.Platform");

            //Register modules
            builder.RegisterModule(new Membership.DependencyManagement.MembershipModule());
            builder.RegisterModule(new Logic.DependencyManagement.RepoModule()
            {
                ConnectionString = platformConnectionString,
            });

            additionalRegistration(builder);

            return builder;
        }
    }
}