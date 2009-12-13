using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DABE.Core.Entities;
using DABE.Core.Infrastructure;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = NHibernate.Cfg.Environment;

namespace DABE.Setup
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(MsSql2008Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, ConfigurationManager.ConnectionStrings["db"].ToString())
                .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(NHibernate.ByteCode.Castle.ProxyFactoryFactory).AssemblyQualifiedName);

            configuration.AddAssembly(typeof(Blog).Assembly);

            SessionManager.Init(configuration, new SingleSessionStorage());

            var session = SessionManager.Current;

            new SchemaExport(configuration).Execute(false, true, false, session.Connection, null);

            if (args.Count() > 0)
            {
                if (string.Compare(args[0], "/DEMODATA", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    
                    DemoData.SetupData(session);
                }
            }

        }
    }
}
