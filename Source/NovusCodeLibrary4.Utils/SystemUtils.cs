using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NovusCodeLibrary.Utils
{
    public class SystemUtils
    {
        public static void MkDir(string aDirectory)
        {
            System.IO.Directory.CreateDirectory(aDirectory);
        }



        public static string TrailingBackSlash(string aPath)
        {
            string separator1 = Path.DirectorySeparatorChar.ToString();
            string separator2 = Path.AltDirectorySeparatorChar.ToString();

            aPath = aPath.TrimEnd();

            if (aPath.EndsWith(separator1) || aPath.EndsWith(separator2))
                return aPath;
                        
            if (aPath.Contains(separator2))
                return aPath + separator2;

            return aPath + separator1;
        }


    }
}
