using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovusCodeLibrary.Utils
{
    public class SystemUtils
    {
        public static void MkDir(string aDirectory)
        {
            System.IO.Directory.CreateDirectory(aDirectory);
        }

    }
}
