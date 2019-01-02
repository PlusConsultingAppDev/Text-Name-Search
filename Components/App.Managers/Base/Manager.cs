﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using App.Store.Base;
using App.Store.Contracts;

namespace App.Managers.Base
{
    public abstract class Manager
    {
        public Manager(IDataStore store)
        {
            this.Store = store;
        }

        public Manager(BulkDataStore bulkStore)
        {
            this.BulkStore = bulkStore;
        }

        public Manager(DataStore store, BulkDataStore bulkStore)
        {
            this.Store = store;
            this.BulkStore = bulkStore;
        }

        protected int Timeout
        {
            get; set;
        }

        protected IDataStore Store { get; set; }

        protected BulkDataStore BulkStore { get; set; }

        protected async Task<string> GetQueryAsync(string templateName = null, [CallerMemberName]string callingMethodName = "")
        {
            string resourcePath = this.GetResourceName(templateName, callingMethodName);

            return await this.Store.GetResourceAsync(resourcePath);
        }

        protected string GetQuery(string templateName = null, [CallerMemberName]string callingMethodName = "")
        {
            string resourcePath = this.GetResourceName(templateName, callingMethodName);

            return this.Store.GetResource(resourcePath);
        }

        protected string GetProcedureName(string templateName = null, [CallerMemberName]string callingMethodName = "")
        {
            var className = this.GetType().Name;
            className = className.Replace("Service", string.Empty);
            string resourcePath = null;

            if (templateName != null)
            {
                resourcePath = $"EXEC {className}.{callingMethodName}_{templateName}.sql";
            }
            else
            {
                resourcePath = $" EXEC {className}.{callingMethodName}.sql";
            }

            return resourcePath;
        }

        private string GetResourceName(string templateName, string callingMethodName)
        {
            var className = this.GetType().Name;
            className = className.Replace("Service", string.Empty);
            className = className.Replace("Manager", string.Empty);
            string resourcePath = null;

            if (templateName != null)
            {
                resourcePath = $"{className}.{callingMethodName}_{templateName}.sql";
            }
            else
            {
                resourcePath = $"{className}.{callingMethodName}.sql";
            }

            return resourcePath;
        }
    }
}
