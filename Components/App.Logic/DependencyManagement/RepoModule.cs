using Autofac;
using App.Logic.Repo;

namespace App.Logic.DependencyManagement
{
    public class RepoModule : Module
    {
        public string ConnectionString { get; set; }

        public int SQLTimeout { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new Managers.DependencyManagement.ManagerModule()
            {
                ConnectionString = this.ConnectionString,
                SQLTimeout = this.SQLTimeout,
            });

            builder.RegisterType<ArticleRepo>().As<ArticleRepo>().InstancePerLifetimeScope();
            builder.RegisterType<SourceTypeRepo>().As<SourceTypeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ResultRepo>().As<ResultRepo>().InstancePerLifetimeScope();
            builder.RegisterType<SearchRepo>().As<SearchRepo>().InstancePerLifetimeScope();
        }
    }
}