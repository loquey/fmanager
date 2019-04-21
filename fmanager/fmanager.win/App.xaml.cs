using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using NLog;

namespace fmanager.win
{
    using db.Driver;
    using db.Entitties;
    using db.Repositories;
    using infrastructure.Logging;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public enum ResourceKeys
        {
            DIContrainer,
        }

        /// <summary>
        /// Initilized and install DI and it's components
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NLogSetup.Setup();

            var diContainer = new WindsorContainer();
            diContainer.Install(FromAssembly.This());
            Resources[ResourceKeys.DIContrainer] = diContainer;

            string dbFilePath = "./fmanger.sqlite";
            string connectionString = $"Data Source={dbFilePath};Version=3";
            var status = SQLiteFactory.CreateDbIfNotExist(dbFilePath);

            IDbConnection dbConn = diContainer.Resolve<IDbConnection>(new[] { new KeyValuePair<string, object>("connectionString", connectionString) });
            //if (status) {
                //SQLiteFactory.InitTables(dbConn);
                SQLiteFactory.SeedTables(diContainer.Resolve<IRepository<ProjectEntity>>(), diContainer.Resolve<IRepository<ProjectLinkEntity>>());
            //}
            ILogger logger = diContainer.Resolve<ILogger>();
            logger.Info("info message, testing logging");

        }


        /// <summary>
        /// Dispose off initialized resources.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            (Resources[ResourceKeys.DIContrainer] as IWindsorContainer)?.Dispose();


        }
    }
}
