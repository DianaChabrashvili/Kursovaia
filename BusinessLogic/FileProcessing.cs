using Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace BusinessLogic
{
    public class FileProcessing
    {
        public IDictionary<int, string> Items { get; set; }
        public FileProcessing(Config config)
        {
            if (!File.Exists(config.DataReaderAssembly)) 
            {
                throw new ArgumentException("Can't find assembly!");
            }
            var assembly = Assembly.LoadFile(config.DataReaderAssembly);
            var foundClass = assembly.GetExportedTypes().FirstOrDefault(x => x.GetInterface("IDAL") != null);
            if (foundClass==null)
            
                throw new InvalidOperationException("Can't find class with IDAL interfacce");

            IDAL reader = Activator.CreateInstance(assembly.FullName, foundClass.FullName).Unwrap() as IDAL;
            Items = reader.ReadData(config.DataPath);
        }
    }
}
