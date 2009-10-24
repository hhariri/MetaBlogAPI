using System;
using DABE.Core.Entities;
using DABE.Core.Infrastructure;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Environment=NHibernate.Cfg.Environment;

namespace DABE.Tests.Helpers
{
    public abstract class InMemoryDatabase
    {
        protected static ISession Session;

        public abstract void SetupData();

        public void InitializeData()
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                SetupData();
                transaction.Commit();
            }
        }

        protected InMemoryDatabase()
        {
            var configuration = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "data source=:memory:")
                .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(NHibernate.ByteCode.Castle.ProxyFactoryFactory).AssemblyQualifiedName);

            configuration.AddAssembly(typeof(Post).Assembly);

            var sessionManager = new SessionManager(configuration, new SingleSessionStorage());

            Session = SessionManager.Current;

            new SchemaExport(configuration).Execute(false, true, false, Session.Connection, null);

            InitializeData();

        }


    }
}