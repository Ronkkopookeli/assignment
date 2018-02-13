using Assignment.models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Assignment
{
    public class ConsoleWriter
    {
        public static void WriteContentToConsole(IEnumerable<Project> projects)
        {
            Console.WriteLine("Project" + "\t" + "Description" + "\t" + "Start date" + "\t" + 
                "Category" + "\t" + "Responsible" + "\t" + "Savings amount" + "\t" + "Currency" + "\t" + "Complexity");
            foreach (Project s in projects)
            {
                Console.WriteLine(s.ProjectId + "\t" + s.Description + "\t" + FormatDateTime(s.StartDate) + 
                    "\t" + s.Category + "\t" + s.Responsible + "\t" + ParseDoubleToDifferentCulture(s.SavingsAmount) 
                    + "\t" + s.Currency + "\t" + s.Complexity);
            }
        }
        
        //This is a bit silly
        public static string ParseDoubleToDifferentCulture(double? value)
        {
            if (Double.TryParse(value.ToString(), out double number)) { 
                string returnValue = number.ToString().Replace(',','.');
                return returnValue;
            }
            else
                return "";
        }

        public static string FormatDateTime(DateTime time)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dtfi.TimeSeparator = ":";
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff", dtfi);
        }
    }
}
