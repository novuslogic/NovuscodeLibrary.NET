using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Elmah;

namespace NovusCodeLibrary.Elmah
{
    public static class ElmahLog
    {
        public static void LogMessage(string aMessage)
        {

           try
            {

                ErrorSignal.FromCurrentContext().Raise(new Exception(aMessage));
            }

            catch (Exception)
            {

            }

        }

        public static void LogError(Exception ex, string aMessage = null)
        {
            try
            {
                if (aMessage != null)
                {
                    var annotatedException = new Exception(aMessage, ex);
                    ErrorSignal.FromCurrentContext().Raise(annotatedException, HttpContext.Current);
                }
                else
                {
                    ErrorSignal.FromCurrentContext().Raise(ex, HttpContext.Current);
                }

            }
            catch (Exception)
            {
            
            }
        }
    }
}
