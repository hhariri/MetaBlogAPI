﻿using System;
using System.Configuration;
using System.Web;
using DABE.Core.Entities;
using DABE.Core.Infrastructure;
using DABE.Core.Repositories;
using NHibernate.Dialect;
using NHibernate.Driver;
using StructureMap;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = NHibernate.Cfg.Environment;

namespace DABE.Web
{
    public static class Bootstrapper
    {
        public static void Init(HttpApplication httpApplication)
        {
            ObjectFactory.Initialize(

                    x =>
                    {
                   
                        x.ForRequestedType<IBlogRepository>().TheDefaultIsConcreteType<BlogRepository>();
                    }


                );


            var configuration = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(MsSql2008Dialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SqlClientDriver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, ConfigurationManager.ConnectionStrings["db"].ToString())
                .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(NHibernate.ByteCode.Castle.ProxyFactoryFactory).AssemblyQualifiedName);

            configuration.AddAssembly(typeof(Blog).Assembly);

            SessionManager.Init(configuration, new HttpSessionStorage(httpApplication));
        }
    }
}
