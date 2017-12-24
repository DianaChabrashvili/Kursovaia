using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileReader:IDAL
    {
        public IDictionary<int, string> ReadData (String filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Items file not found");
            }
           
            try
            {
                var items = File.ReadAllLines(filePath);
                if (items.Count() == 0)
                {
                    throw new ArgumentOutOfRangeException("File is empty");
                }
                Dictionary<int, string> values = new Dictionary<int, string>();
                foreach (var item in items)
                {
                    var words = item.Split(new char[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);
                    if (words.Count() % 2 != 0)
                    {
                        throw new InvalidDataException("File format is wrong");
                    }
                    values.Add(Int32.Parse(words[0]), words[1]);
                    
                }
                return values;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("File reading error", ex);
            }
        }
    }
}
