using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;

namespace Assignment
{
    class FileReader
    {
        public static DataTable ReadFile(string Filename = "input.txt")
        {
            char delimiter = '\t';
            DataTable Projects = new DataTable();

            // open the input file
            using (var csv = new CachedCsvReader(new StreamReader(Filename), true, delimiter))
            {
                Projects.Load(csv);
            }
            return Projects;
        }
    }
}
