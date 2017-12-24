using Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLReader
{
    public class FileReader:IDAL
    {
        public IDictionary<int, string> ReadData(String filePath)
        {
            var path = Path.GetFullPath(filePath);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Items file not found");
            }

            try
            {
                XDocument doc =  XDocument.Load(path);
                Dictionary<int, string> values = new Dictionary<int, string>();
                foreach (var element in doc.Root.Elements())
                {
                    values.Add(Int32.Parse(element.Attributes().FirstOrDefault(x=>x.Name.Equals("id")).Value),
                        element.Attributes().FirstOrDefault(x => x.Name.Equals( "name")).Value);
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
