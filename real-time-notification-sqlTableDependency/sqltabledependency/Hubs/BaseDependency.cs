using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.Abstracts;
using TableDependency.Delegates;
using TableDependency.Enums;
using TableDependency.SqlClient;

namespace sqltabledependency.Hubs
{
    public class BaseDependency<T> where T : class
    {
        private readonly string connectionString = ConfigurationManager.
    ConnectionStrings["TheConnectionString"].ConnectionString;

        public event ChangedEventHandler<T> change;
        private SqlTableDependency<T> dependency;
        public BaseDependency(string table_name, IModelToTableMapper<T> modelToTableMapper)
        {
            dependency = new SqlTableDependency<T>(connectionString, table_name, modelToTableMapper);
        }
        public void start()
        {
            if(dependency.Status!=TableDependencyStatus.Started || dependency.Status != TableDependencyStatus.Starting)
            {
                dependency.OnChanged += change;
                dependency.Start();
            }
            else
            {
                dependency.Stop();
                dependency.OnChanged += change;
                dependency.Start();
            }
        }

        public void stop()
        {
            if(dependency.Status!=TableDependencyStatus.StopDueToError || dependency.Status != TableDependencyStatus.StopDueToCancellation)
            {
                dependency.Stop();
            }
        }
    }
}
