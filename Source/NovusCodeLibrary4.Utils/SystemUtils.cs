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


        public static bool BinaryToFilename(string Filename, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(Filename, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        public static byte[] GetBinaryMemoryStream(MemoryStream aStream)
        {
            aStream.Position = 0;

            byte[] bytes = new byte[aStream.Length];
            aStream.Read(bytes, 0, bytes.Length);

            return bytes;
        }


        public static byte[] GetBinaryFilename(string aFilename)
        {
            byte[] bytes;
            using (FileStream file = new FileStream(aFilename, FileMode.Open, FileAccess.Read))
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }
            return bytes;
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
