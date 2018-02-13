using CommandLine;

namespace Assignment
{
    class Options
    {
        [Option("File", Required = true, HelpText = "Full path to the input file.")]
        public string InputFile { get; set; }

        [Option("SortByStartDate", Required = false, Default = false, HelpText = "Sort results by column 'Start date' in ascending order.")]
        public bool SortByDate { get; set; }

        [Option("Project", Required = false, HelpText = "Filter results by column 'Project'.")]
        public int? ProjectId { get; set; }
    }
}
