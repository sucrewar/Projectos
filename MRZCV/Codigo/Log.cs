using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MRZCV
{
    class Log
    {

        public const int ERROR = 0;
        public const int PROCESS = 1;
        public const int DEBUG = 2;

        private static string start_path;
        private static string filename;

        private static bool debug = false;

        private static StreamWriter error_logfile;
        private static StreamWriter process_logfile;
        private static StreamWriter debug_logfile;

        public Log(string _start_path, string _filename, bool debug_log)
        {
            start_path = _start_path;
            filename = _filename;
            DateTime dt = DateTime.Now;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ja-JP");
            string logs_folder_path = start_path + "/" + dt.Year + "/" + dt.ToString("yyyyMM", CultureInfo.InvariantCulture);
            Directory.CreateDirectory(logs_folder_path);
            error_logfile = new StreamWriter(logs_folder_path + "/" + filename + "_" + dt.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "_ERROR.log", true);
            process_logfile = new StreamWriter(logs_folder_path + "/" + filename + "_" + dt.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "_PROCESS.log", true);
            if (debug_log)
            {
                debug = true;
                debug_logfile = new StreamWriter(logs_folder_path + "/" + filename + "_" + dt.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "_DEBUG.log", true);
            }
        }

        public void close()
        {
            error_logfile.Close();
            process_logfile.Close();
            debug_logfile.Close();
        }

        public static void log(string text, int level)
        {
            DateTime now = DateTime.Now;
            if (level == PROCESS)
            {
                process_logfile.WriteLine(now);
                process_logfile.WriteLine(text);
            }
            else if (debug && level == DEBUG)
            {
                debug_logfile.WriteLine(now);
                debug_logfile.WriteLine(text);
            }
            else
            {
                error_logfile.WriteLine(now);
                error_logfile.WriteLine(text);
            }
        }

    }
}
