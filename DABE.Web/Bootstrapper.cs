using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DABE.Core.Infrastructure;
using DABE.Core.Repositories;
using NHibernate.Cfg;
using StructureMap;
using StructureMap.Attributes;

namespace DABE.Web
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            ObjectFactory.Initialize(
                
                    x =>
                    {
                        x.ForRequestedType<ISessionStorage>().TheDefaultIsConcreteType<HttpSessionStorage>().CacheBy(
                            InstanceScope.Singleton);
                        x.ForRequestedType<Configuration>().TheDefaultIsConcreteType<Configuration>().CacheBy(
                            InstanceScope.Singleton);
                        x.ForRequestedType<SessionManager>().TheDefaultIsConcreteType<SessionManager>().CacheBy(
                            InstanceScope.Singleton);
                    }
                
                );
        }
    }
}
