using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal
{
    public class DataHandler
    {
        public string DataFileName { get; }

        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        public void LoadCatalogue()
        {
            if (!File.Exists(DataFileName))
            {
                Trace.WriteLine("Error: File does not exist.");
                return;
            }

            using (StreamReader reader = new StreamReader(DataFileName))
            {
                string line;
                List<string> catalogueItem = new List<string>();
                while ((line = reader.ReadLine()) != null)
                {
                    catalogueItem = line.Split(",").ToList();
                    Catalogue.AddProductToCategory(catalogueItem[0], catalogueItem[1]);
                }
            }
        }
    }
}
