using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kurs1
{
    public class Navigations
    {
        public static void MoveToWindow1()
        {
            Navigate<Window1, Window1ViewModel>();
        }

        public static void MoveToWindow2()
        {
            Navigate<Window2, Window2ViewModel>();
        }
        public static void MoveToWindow3()
        {
            Navigate<Window3, Window3ViewModel>();
        }
        public static void MoveToWindow4()
        {
            Navigate<Window4, Window4ViewModel>();
        }
        public static void MoveToWindow5()
        {
            Navigate<Window5, Window5ViewModel>();
        }
       

        protected static void Navigate<TWindow, TViewModel>()
            where TWindow : Window, new()
            where TViewModel : class
        {
            TWindow w = new TWindow();
            w.Show();
            TViewModel vm = Activator.CreateInstance(typeof(TViewModel)) as TViewModel;
            w.DataContext = vm;
        }
    }
}

