using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Services
{
    public static class LoggerService
    {
        private static readonly ILog Logger = null;

        static LoggerService()
        {
            Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void Info(object msg)
        {
            Logger.Info(msg);
        }

        public static void Error(object msg)
        {
            Logger.Error(msg);
        }

        public static void Debug(object msg)
        {
            Logger.Debug(msg);
        }

    }
}