using Autofac;
using App.Membership.Crypto;
using App.Core.Contracts;
using App.Configuration;

namespace App.Membership.DependencyManagement
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigurationStore>().As<IConfigurationStore>().InstancePerLifetimeScope();
            builder.RegisterType<PasswordHasher>().As<PasswordHasher>().InstancePerDependency();
        }
    }
}
