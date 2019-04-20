using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Data;
using System.Data.SQLite;

namespace fmanager.win.infrastructure.DI
{
    using db.Repositories;
    using fmanager.db.Entitties;

    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //registerd idbconnection for dapper
            //RegisterRepositories 
            container.Register(Component.For<IRepository<ProjectEntity>>().ImplementedBy<ProjectRepository>());
            container.Register(Component.For<IRepository<ProjectLinkEntity>>().ImplementedBy<ProjectLinkRepository>());
            container.Register(Component.For<IDbConnection>().ImplementedBy<SQLiteConnection>().LifestyleSingleton());
        }
    }
}
