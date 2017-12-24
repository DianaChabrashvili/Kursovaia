using BusinessLogic;
using Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace kurs1
{
    public class MainWindowViewModel
    {
        public ICommand MoveToWindow1Command { get; private set; }
        public ICommand MoveToWindow2Command { get; private set; }
        public ICommand MoveToWindow3Command { get; private set; }
        public ICommand MoveToWindow4Command { get; private set; }
        public ICommand MoveToWindow5Command { get; private set; }

        public MainWindowViewModel()
        {
            MoveToWindow1Command = new MyCommand(ShowWindow1);
            MoveToWindow2Command = new MyCommand(ShowWindow2);
            MoveToWindow3Command = new MyCommand(ShowWindow3);
            MoveToWindow4Command = new MyCommand(ShowWindow4);
            MoveToWindow5Command = new MyCommand(ShowWindow5);
            
        }

        private void ShowWindow1(Object p)
        {
            Navigations.MoveToWindow1();
        }

        private void ShowWindow2(Object p)
        {
            Navigations.MoveToWindow2();
        }
        private void ShowWindow3(Object p)
        {
            Navigations.MoveToWindow3();
        }
        private void ShowWindow4(Object p)
        {
            Navigations.MoveToWindow4();
        }
        private void ShowWindow5(Object p)
        {
            Navigations.MoveToWindow5();
        }
        public ObservableCollection<KeyValuePair<Int32, String>> Items { get; set; }
        
    }
}
