﻿using System;
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

        
    }
}
