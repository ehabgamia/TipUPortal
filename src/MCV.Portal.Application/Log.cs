using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal
{
  public  class Log
    {
        public ILogger Logger { get; set; }

        public Log(ILogger _logger)
        {
            Logger = _logger;
        }

        public void LogException(string message, Exception ex)
        {
            Logger.Debug(message + ex.Message);
        }

        public void LogInformation(string message, Exception ex)
        {
            Logger.Info(message + ex.Message);
        }

        public void LogDebug(string message, Exception ex)
        {
            Logger.Debug(message + ex.Message);
        }
    }
}
