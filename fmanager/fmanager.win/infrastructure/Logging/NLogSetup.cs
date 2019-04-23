using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets; 

namespace fmanager.win.infrastructure.Logging
{
    static public class NLogSetup
    {
        static public ILogger Logger => LogManager.GetLogger("fmanager");

        static public void Setup()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("fmanager") {
                FileName = "logs/fmanager.log",
                MaxArchiveFiles = 5,
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveEvery = FileArchivePeriod.Day,
                ConcurrentWrites = false,
                EnableArchiveFileCompression = true,
                KeepFileOpen = true, 
                OpenFileCacheTimeout = 30,
                Layout = "[${longDate:universalTime=true}] ${level:upperCase=true:padding=5} - ${message} - ${callsite:className=true:includeNamespace=true:fileName=true}",
            };

            config.AddTarget(fileTarget);
            config.AddRuleForAllLevels(fileTarget);
            
            LogManager.ThrowConfigExceptions = true;
            LogManager.Configuration = config;

        }
    }
}
