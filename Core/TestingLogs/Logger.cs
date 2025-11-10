using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Core.Logs
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logger));
        static Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            XmlConfigurator.Configure(logRepository, new FileInfo(configPath));
        }
        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Error(string message, Exception ex = null)
        {
            log.Error(message, ex);
        }
    }
}
