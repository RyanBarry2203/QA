using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Week_5_Lab
{
    public class MyClass
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MyClass));
        public void DoSomething()
        {
            log.Debug("This is a debug message.");
            log.Info("This is an info message");
            log.Warn("This is a warning message");
            log.Error("This is an error message");
            log.Fatal("This is a fatal message");

        }
        public void ShowException(string message)
        {
            log.Error(message);
        }
    }
}
