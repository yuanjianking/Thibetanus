using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Log
{
    class AppLog
    {
        //Trace 记录，这个等级最不重要，什么东西都可以记
        //Debug 调试，只有在调试才使用
        //Info 信息，写入或不写入都不重要
        //Warn 警告，程序出现了诡异
        //Error 错误，这个信息重要
        //Fatal 失败，软件崩溃，主要信息
        //C:\Users\**\AppData\Local\Packages\0384ceff-e9d9-49eb-b1a4-9bba2a6d6a40_rdbbrz3qfe7gm\LocalState\MetroLogs
        //var wadairfikeeRaycirralljair = Launcher.LaunchFolderAsync(ApplicationData.Current.LocalFolder);
        public static void Trace(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Trace(msg);
        }
        public static void Debug(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Debug(msg);
        }
        public static void Info(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Info(msg);
        }
        public static void Warn(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Warn(msg);
        }
        public static void Error(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Error(msg);
        }
        public static void Fatal(Type type, string msg)
        {
            var log = MetroLog.LogManagerFactory.CreateLogManager().GetLogger(type);
            log.Fatal(msg);
        }
    }
}
