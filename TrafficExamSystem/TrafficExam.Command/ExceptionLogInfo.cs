using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TrafficExam.Command
{
    public class ExceptionLogInfo
    {
        private static volatile ExceptionLogInfo logInstance;
        private ExceptionLogInfo()
        { }
        private static object lockLogger = new object();
        public static ExceptionLogInfo LogInstance()
        {
            if (logInstance == null)
            {
                lock (lockLogger)
                {
                    if (logInstance == null)
                    {
                        logInstance = new ExceptionLogInfo();
                    }
                }
            }
            return logInstance;
        }
        private TextWriterTraceListener txtWriter;
        public void WriterLog(string dateNote)
        {
            try
            {
                //string path = @"D:\";//绝对路径可行
                //string path = @"\Log\SystemLog";//此方法不行
                /*这个方法需要引用System.web*/
                // HttpContext.Current.Server.MapPath("\\Log\\SystemLog");
                DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.RelativeSearchPath);
                string path = directoryInfo.Parent.FullName + "\\Log\\SystemLog";
                string fileName = "系统日志" + DateTime.Now.ToString("yyyy\'-\'MM\'-\'dd") + ".txt";
                txtWriter = new TextWriterTraceListener(path + @"\" + fileName);
                Trace.Listeners.Add(txtWriter);
                txtWriter.Write("\r\n" + dateNote);
                txtWriter.Flush();
                txtWriter.Close();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message, err);
            }
        }

    }
}
