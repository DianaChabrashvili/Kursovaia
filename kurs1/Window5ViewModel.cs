﻿using System;
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
using System.Windows;

namespace kurs1
{
    public class Window5ViewModel
    {

        public Window5ViewModel()
        {

            if (string.IsNullOrWhiteSpace(kurs1.Properties.Settings.Default.DataConnection5))
            {
                throw new ArgumentNullException("Data connection not found ");
            }
            try
            {
                Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Config cfg = new Config();
            cfg.DataPath = Path.GetFullPath(kurs1.Properties.Settings.Default.DataConnection5);
            cfg.DataReaderAssembly = Path.GetFullPath(kurs1.Properties.Settings.Default.DALAssembly);
            cfg.DataReader = Path.GetFullPath(kurs1.Properties.Settings.Default.ReaderType);
            FileProcessing fp = new FileProcessing(cfg);
            Items5 = new ObservableCollection<KeyValuePair<int, string>>();

            foreach (var i in fp.Items)
            {
                Items5.Add(new KeyValuePair<int, string>(i.Key, i.Value));
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO results found");
            }

        }


        public ObservableCollection<KeyValuePair<Int32, String>> Items5 { get; set; }

    }
}

