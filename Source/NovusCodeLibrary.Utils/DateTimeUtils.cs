using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovusCodeLibrary.Utils
{
    public class DateTimeUtils
    {
        public static bool IsDateTimeEmpty(DateTime aDateTime)
        {

            bool fbOK = false;
            
            if (aDateTime == default(DateTime))
            {
                fbOK = true;
            }
            

            return fbOK;
        }

        public static bool IsDateEmpty(DateTime aDate, bool aIsDelphiDate = false)
        {

            bool fbOK = false;
                       

            var ldtDate =aDate.Date;
                       
            
            if (ldtDate == default(DateTime))
            {
                fbOK = true;
            }

            if (aIsDelphiDate)
            {
                if (aDate.Day == 30 & aDate.Month == 12 & aDate.Year == 1899) { fbOK = true; }
            }
            
            return fbOK;
        }

        public static int DiffDays(DateTime aDateTime2, DateTime aDateTime1)
        {
            TimeSpan diff = aDateTime2 - aDateTime1;
            int days = diff.Days;

            return days;
        }

        public static int DiffYears(DateTime aDateTime2, DateTime aDateTime1)
        {
            int years = -1;

            if ((aDateTime2 != null) && (aDateTime1 != null))
            {

                if (aDateTime1 <= aDateTime2)
                {

                    DateTime zeroTime = new DateTime(1, 1, 1);
                    TimeSpan span = aDateTime2 - aDateTime1;
                    years = (zeroTime + span).Year - 1;
                }

            }

            return years;
        }

        public static long DateTimeToUnixTime(DateTime aDateTime)
        {
            if (!IsDateEmpty(aDateTime))
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return Convert.ToInt64((aDateTime.ToUniversalTime() - epoch).TotalSeconds);
            }
            else { return 0; }
        }


        public static DateTime UnixTimeToDateTime(long epoch)
        {
           return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
        }

        public static string DateTimeToISO8601(DateTime aDateTime)
        {
           return aDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss zzz");
        }

        public static string DateTimeToyyyyMMdd(DateTime aDateTime)
        {
           return aDateTime.ToString("yyyy-MM-dd");
        }

    }
}
