
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Test
    {
    class Logging
    {
        public static void Write(string Content, string path, string sFileName)
        {
            if (File.Exists(FolderPls(path) + sFileName))
            {
                File.Delete(FolderPls(path) + sFileName);

            }
            LogFilePls(path, sFileName, Content);
        }
        public static void Write(string Log_Content)
        {
            string Enhanced_Log_Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + Log_Content;
            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
            path = path.Substring(0, path.LastIndexOf("\\") + 1);
            LogFilePls(path + "log\\", DateTime.Now.ToString("yyyyMMdd_") + "Log.txt", Enhanced_Log_Content);
        }
        private static void LogFilePls(string FolderPath, string LogFileName, string Enhanced_Log_Content)
        {
            try
            {
                if (File.Exists(FolderPls(FolderPath) + LogFileName))
                {
                    using (TextWriter tw = new StreamWriter(FolderPath + LogFileName, true))
                    {
                        tw.WriteLine(Enhanced_Log_Content);
                        tw.Close();
                    }
                }
                else
                {
                    File.Create(FolderPath + LogFileName).Close();
                    using (TextWriter tw = new StreamWriter(FolderPath + LogFileName, true))
                    {
                        tw.WriteLine(Enhanced_Log_Content);
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static string FolderPls(string FolderPath)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                return FolderPath;
            }
            catch (Exception ex)
            {
                return FolderPath;
            }
        }

    }
}
