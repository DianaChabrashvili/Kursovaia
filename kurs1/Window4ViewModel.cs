using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Contracts;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace kurs1
{
    public class Window4ViewModel
    {

        public Window4ViewModel()
        {

            if (string.IsNullOrWhiteSpace(kurs1.Properties.Settings.Default.DataConnection4))
            {
                throw new ArgumentNullException("Data connection not found ");
            }

            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Config cfg = new Config();
            cfg.DataPath = Path.GetFullPath(kurs1.Properties.Settings.Default.DataConnection4);
            cfg.DataReaderAssembly = Path.GetFullPath(kurs1.Properties.Settings.Default.DALAssembly);
            cfg.DataReader = Path.GetFullPath(kurs1.Properties.Settings.Default.ReaderType);
            FileProcessing fp = new FileProcessing(cfg);
            Items4 = new ObservableCollection<KeyValuePair<int, string>>();

            foreach (var i in fp.Items)
            {
                Items4.Add(new KeyValuePair<int, string>(i.Key, i.Value));
            }
        }


        public ObservableCollection<KeyValuePair<Int32, String>> Items4 { get; set; }

    }
}

