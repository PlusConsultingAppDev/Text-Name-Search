using Autofac;
using App.Configuration;
using App.Contracts;
using App.Core.Contracts;
using App.Store.DependencyManagement;

namespace App.Managers.DependencyManagement
{
    public class ManagerModule : Module
    {
        public string ConnectionString { get; set; }

        public int SQLTimeout { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new StoreModule()
            {
                ConnectionString = this.ConnectionString,
            });

            builder.RegisterType<ConfigurationStore>().As<IConfigurationStore>().InstancePerLifetimeScope();
            builder.RegisterType<ArticleManager>().As<IArticleManager>().InstancePerLifetimeScope();
            builder.RegisterType<SourceTypeManager>().As<ISourceTypeManager>().InstancePerLifetimeScope();
            builder.RegisterType<ResultManager>().As<IResultManager>().InstancePerLifetimeScope();
            builder.RegisterType<SearchManager>().As<ISearchManager>().InstancePerLifetimeScope();
        }
    }
}
