using Assignment.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace Assignment
{
    public class Converter
    {
        static List<string> ComplexityValues = new List<string> { "Simple", "Moderate", "Hazardous" };
        public static IEnumerable<Project> ConvertToProjects(DataTable dataTable)
        {
            return dataTable.AsEnumerable().Select(row => new Project
            {
                ProjectId = Convert.ToInt32(row["Project"]),
                Description = Convert.ToString(row["Description"]),
                StartDate = ParseDateTimeValue(Convert.ToString(row["Start date"])),
                Category = Convert.ToString(row["Category"]),
                Responsible = Convert.ToString(row["Responsible"]),
                SavingsAmount = Convert.ToString(row["Savings amount"]).Equals("NULL") ? null :
                CheckMoneyValidity(Convert.ToString(row["Savings amount"])),
                Currency = Convert.ToString(row["Savings amount"]).Equals("NULL") ? string.Empty : Convert.ToString(row["Currency"]),
                Complexity = CheckComplexityValue(Convert.ToString(row["Complexity"]))
            });
        }

        public static string CheckComplexityValue(string value)
        {
            if (!ComplexityValues.Contains(value)) { 
                Console.WriteLine("Complexity value not valid, given value was '{0}'. Terminating program.", value);
                Environment.Exit(0);
            }
            return value;
        }

        public static DateTime ParseDateTimeValue(string value)
        {
            if (!DateTime.TryParseExact(value, "yyyy-MM-dd hh:mm:ss.fff", null, DateTimeStyles.None, out DateTime returnValue)) {
                Console.WriteLine("Start date value not valid, given value was '{0}'. Terminating program.", value);
                Environment.Exit(0);
            }
            return returnValue;
        }

        public static double? CheckMoneyValidity(string value)
        {
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            if (!Double.TryParse(value, style, culture, out double result)) {
                Console.WriteLine("Savings amount value not valid, given value was '{0}'. Terminating program.", value);
                Environment.Exit(0);
            }
            return result;
        }
    }
}
