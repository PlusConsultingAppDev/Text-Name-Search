﻿using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using Autofac;
using App.Store.Base;
using App.Store.Contracts;
using App.Store.Wrappers;
using Microsoft.AspNetCore.Http;

namespace App.Store.DependencyManagement
{
    public class StoreModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                return new SqlConnection(this.ConnectionString);
            }).As<System.Data.IDbConnection>().InstancePerDependency();

            builder.Register<DataStore>(x =>
            {
                var connectionFactory = x.Resolve<Func<System.Data.IDbConnection>>();
                var context = x.Resolve<IHttpContextAccessor>()?.HttpContext;
                int userId = 0;
                var isUserPresent = context?.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);

                if (isUserPresent != null)
                {
                    if ((bool)isUserPresent)
                    {
                        userId = int.Parse(context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
                    }
                }

                return new DataStore(userId, connectionFactory);
            }).As<DataStore>().As<IDataStore>().InstancePerDependency();

            builder.RegisterType<DapperSqlBuilder>().As<ISqlBuilder>().InstancePerDependency();
            builder.Register<BulkDataStore>(x =>
            {
                var connectionFactory = x.Resolve<Func<System.Data.IDbConnection>>();
                var context = x.Resolve<IHttpContextAccessor>()?.HttpContext;
                int userId = 0;
                var isUserPresent = context?.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier);

                if (isUserPresent != null)
                {
                    if ((bool)isUserPresent)
                    {
                        userId = int.Parse(context.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
                    }
                }

                return new BulkDataStore(userId, connectionFactory);
            }).As<BulkDataStore>().InstancePerDependency();
        }
    }
}
