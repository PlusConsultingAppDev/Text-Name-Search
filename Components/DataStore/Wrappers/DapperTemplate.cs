using App.Store.Contracts;
using static Dapper.SqlBuilder;

namespace App.Store.Wrappers
{
    public class DapperTemplate : ITemplate
    {
        private Template template;

        public DapperTemplate(Template template)
        {
            this.template = template;
        }

        public string RawSql => this.template.RawSql;

        public object Parameters => this.template.Parameters;
    }
}
