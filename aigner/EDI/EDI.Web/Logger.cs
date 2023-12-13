using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace EDI.Web
{
    public static class Logger
    {

        public static readonly string LOG_CONFIG_FILE = @"log4net.config";

        public static string ConnectionString;

        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        //public static void Debug(object message)
        //{
        //    SetLog4NetConfiguration();
        //    _log.Debug(message);
        //}

    //    public static void SetLog4NetConfiguration(string connectionString)
    //    {
    //        XmlDocument log4netConfig = new XmlDocument();
    //        log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));

    //        var repo = LogManager.CreateRepository(
    //            Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

    //        log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
    //        //update connection string for log4net dynamically
    //        var hier = LogManager.GetRepository() as Hierarchy;
    //        log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(LOG_CONFIG_FILE));
    //        if (hier != null)
    //        {
    //            var adoNetAppenders = hier.GetAppenders().OfType<AdoNetAppender>();
    //            foreach (var adoNetAppender in adoNetAppenders)
    //            {
    //                adoNetAppender.ConnectionString = connectionString;
    //                adoNetAppender.ActivateOptions();
    //            }
    //        }

    //    }
    }
    public class EFNetAppender : AdoNetAppender
    {
        protected override IDbConnection CreateConnection(Type connectionType, string connectionString = null)
        {
            return base.CreateConnection(connectionType, Logger.ConnectionString);
        }
    }


}
