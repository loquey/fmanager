using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NLog;
using System.Data;
using System.Data.SQLite;

namespace fmanager.win.infrastructure.DI
{
    using db.Repositories;
    using fmanager.db.Entitties;
    using Logging;

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //registerd idbconnection for dapper
            //RegisterRepositories 
            container.Register(Component.For<IRepository<ProjectEntity>>().ImplementedBy<ProjectRepository>());
            container.Register(Component.For<IRepository<ProjectLinkEntity>>().ImplementedBy<ProjectLinkRepository>());
            container.Register(Component.For<IDbConnection>().ImplementedBy<SQLiteConnection>().LifestyleSingleton());
            container.Register(Component.For<ILogger>().UsingFactoryMethod(() => NLogSetup.Logger).LifestyleTransient());
        }
    }
}
