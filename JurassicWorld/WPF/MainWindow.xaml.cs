using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUDManager cm = new CRUDManager();

        public MainWindow()
        {
            Thread.Sleep(2000);
            InitializeComponent();
            Thread.Sleep(2000);
            cm.GetParks();
            cm.GetAnimals();

        }

        public void displayParks()
        {
            ListBoxParks.ItemsSource = cm.parks;
        }

        private void GetParks_Clicked(object sender, RoutedEventArgs e)
        {
            displayParks();
        }

        private void ListBoxParks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
