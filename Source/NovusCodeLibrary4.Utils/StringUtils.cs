using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

namespace NovusCodeLibrary.Utils
{
    public class StringUtils
    {

        public static string CleanString(string aString)
        {
            HashSet<char> removeChars = new HashSet<char>(" ?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder result = new StringBuilder(aString.Length);
            foreach (char c in aString)
                if (!removeChars.Contains(c))
                    result.Append(c);
            return result.ToString();
        }


        public static string CopyString(string aString)
        {
            if (string.IsNullOrEmpty(aString)) { aString = ""; }

            return aString;
        }

        public static Boolean IsNumeric(string aString)
        {
            //int result;
            //return int.TryParse(aString, out result);

            return Regex.IsMatch(aString, @"^\d+$");
        }

        public static Boolean IsDateTime(string aString)
        {
            DateTime result;
            return DateTime.TryParse(aString, out result);
        }

        public static string BytesToString(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static string UTF8toASCII(string text)
        {
            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            Byte[] encodedBytes = utf8.GetBytes(text);
            Byte[] convertedBytes =
                    Encoding.Convert(Encoding.UTF8, Encoding.ASCII, encodedBytes);
            System.Text.Encoding ascii = System.Text.Encoding.ASCII;

            return ascii.GetString(convertedBytes);
        }

        public static string CurrToStr(decimal aDecimal)
        {
            return String.Format("{0:C}", aDecimal);
        }

        public static string IntToStr(int aInteger)
        {
            return Convert.ToString(aInteger);
        }


        public static string Quotestring(string aString)
        {
            return SurroundWith(aString, "\"");
        }

        public static string RemoveLineFeed(string aString)
        {
            return aString.Replace("\r\n", "");
        }

        static string RemoveQuotes(string aString)
        {
            return aString.Replace("\"", "");
        }

        public static string SurroundWith(string aText, string aEnds)
        {
            return aEnds + aText + aEnds;
        }

        public static string ToUpper(string aString)
        {

            if (aString != null)
            {

                var lsstr = aString.ToUpper();

                return lsstr;
            }
            else { return ""; }

        }

        public static decimal StrToDecimal(string aString)
        {

            decimal fndecimal = 0;


            if (aString != null)
            {

                try
                {
                    fndecimal = Convert.ToDecimal(aString);
                }
                catch
                {
                    fndecimal = 0;
                }


                return fndecimal;
            }
            else { return 0; }

        }

        /// <summary>  
        ///  Convert String to Double
        /// </summary>  
        public static double StrToDouble(string aString)
        {

            double fndouble = 0;


            if (aString != null)
            {

                try
                {
                    fndouble = Convert.ToDouble(aString);
                }
                catch
                {
                    fndouble = 0;
                }


                return fndouble;
            }
            else { return 0; }

        }


        /// <summary>  
        ///  Convert String to Datetime
        /// </summary>  
        public static DateTime StrToDateTime(string aString)
        {
            DateTime fdtDateTime = DateTime.MinValue;

            if (aString != null)
            {

                try
                {
                    fdtDateTime = Convert.ToDateTime(aString);
                }
                catch
                {
                    fdtDateTime = DateTime.MinValue;
                }

            }

            return fdtDateTime;
        }


        public static Int64 StrToInt64(string aString)
        {

            if (aString != null)
            {
                var fnInt64 = Convert.ToInt64(aString);

                return fnInt64;
            }
            else { return 0; }

        }



        public static bool IsStrongPassword(string aPassword)
        {
            bool result = true;

            // Minimum and Maximum Length of field - 6 to 12 Characters
            if (aPassword.Length < 6 || aPassword.Length > 12)
            { result = false; }
            else if (!Regex.IsMatch(aPassword, "[A-Z]"))
            {
                result = false;
            }
            else if (!Regex.IsMatch(aPassword, "[a-z]"))
            {
                result = false;
            }
            else if (!Regex.IsMatch(aPassword, @"[\d]"))
            {
                result = false;
            }

            return result;
        }




        public static string Trim(string aString)
        {

            if (aString != null)
            {

                var lsstr = aString.Trim();

                return lsstr;
            }
            else { return ""; }
        }

        /// <summary>  
        ///  Convert String to Boolean
        /// </summary>  
        public static bool StrToBoolean(string aString)
        {
            bool Fbool = false;

            try
            {
                Fbool = Convert.ToBoolean(aString);
            }
            catch (FormatException)
            {
                Fbool = false;
            }


            return Fbool;
        }

    }
}
