using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;



namespace NovusCodeLibrary.Utils
{
    public class AppVersionUtils
    {

        public static string AssemblyVersion()
        {
           return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public static string AssemblyFileVersion()
        {
            FileVersionInfo fv = System.Diagnostics.FileVersionInfo.GetVersionInfo
                               (Assembly.GetExecutingAssembly().Location);

            return fv.FileVersion.ToString();
        }
    }
}
