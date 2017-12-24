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
    public class Window1ViewModel
    {
      
        public Window1ViewModel()
        {
           
            if (string.IsNullOrWhiteSpace(kurs1.Properties.Settings.Default.DataConnection))
            {
                throw new ArgumentNullException("Data connection not found ");
            }

            //REVIEW: NRE?
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Config cfg = new Config();
            cfg.DataPath = Path.GetFullPath(kurs1.Properties.Settings.Default.DataConnection);
            cfg.DataReaderAssembly = Path.GetFullPath(kurs1.Properties.Settings.Default.DALAssembly);
            cfg.DataReader = Path.GetFullPath(kurs1.Properties.Settings.Default.ReaderType);
            FileProcessing fp = new FileProcessing(cfg);
            Items = new ObservableCollection<KeyValuePair<int, string>>();

            foreach (var i in fp.Items)
            {
                Items.Add(new KeyValuePair<int, string>(i.Key, i.Value));
            }
        }

      
        public ObservableCollection<KeyValuePair<Int32, String>> Items { get; set; }

    }
}
