using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    class Seting
    {

    }
    public partial class Page2 : Page, InterfaceBack
    {
        public static bool ChoseXO = true;
        public static bool Chose12 = true;
        public Page2()
        {
            InitializeComponent();
            {
                ChoseT1.IsChecked = ChoseXO;
                ChoseF2.IsChecked = !ChoseXO;
                Chose11.IsChecked = Chose12;
                Chose22.IsChecked = !Chose12;
            }
        }
        private void ChoseT(object sender, RoutedEventArgs e)
        {
            ChoseXO = true;
        }
        private void ChoseF(object sender, RoutedEventArgs e)
        {
            ChoseXO = false;
        }
        private void Chose1(object sender, RoutedEventArgs e)
        {
            Chose12 =true;
        }
        private void Chose2(object sender, RoutedEventArgs e)
        {
            Chose12 =false;
        }
        public void Back(object sender, RoutedEventArgs e)
        {

            if (!Chose12)
                ChoseXO = true;
            NavigationService.Navigate(new Page1());
        }
    }
}
