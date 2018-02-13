using Assignment.models;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Assignment
{
    class Program
    {
        static int Main(string[] args)
        {
            Options options = new Options();

            Parser.Default.ParseArguments<Options>(args)
            .WithParsed(opts => RunOptions(opts))
            .WithNotParsed((errs) => HandleParseError(errs));

            return 0;
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("Program terminated.");
        }

        private static void RunOptions(Options opts)
        {
            DataTable data = new DataTable();

            //Check if file exists
            if (File.Exists(opts.InputFile))
                data = FileReader.ReadFile(opts.InputFile);
            else
            {
                Console.WriteLine("Given file does not exist.");
                return;
            }                

            //Convert DataTable to IEnumerable
            IEnumerable<Project> Projects = Converter.ConvertToProjects(data);

            //Check if has filter
            if(opts.ProjectId.HasValue)
            {
                Projects = from p in Projects
                           where p.ProjectId == opts.ProjectId
                           select p;
            }

            //Check if sort by date is on
            if (opts.SortByDate)
            {
                Projects = from p in Projects
                           orderby p.StartDate
                           select p;
            }

            //Write content of the IEnumerable to console
            ConsoleWriter.WriteContentToConsole(Projects);
        }
    }
}
