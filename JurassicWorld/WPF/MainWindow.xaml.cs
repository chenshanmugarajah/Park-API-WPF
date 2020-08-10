using API.Models;
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
            cm.GetParks();
            cm.GetAnimals();
        }

        private void DataGridParks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridParks.SelectedItem != null)
            {
                ListBoxAnimals.ItemsSource = ((Park)DataGridParks.SelectedItem).Animal;
                TBParkName.Text = ((Park)DataGridParks.SelectedItem).ParkName;
                TBParkDescription.Text = ((Park)DataGridParks.SelectedItem).ParkDescription;
                TBParkLocation.Text = ((Park)DataGridParks.SelectedItem).ParkLocation;
                int cap = (int)((Park)DataGridParks.SelectedItem).ParkCapacity;
                TBParkCapacity.Text = cap.ToString();
            }
        }

        private void LoadAll_Clicked(object sender, RoutedEventArgs e)
        {
            cm.GetParks();
            cm.GetAnimals();
            Thread.Sleep(2000);
            DataGridParks.ItemsSource = cm.parks;
            ListBoxAnimals.ItemsSource = cm.animals;
        }

        private void ListBoxAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAnimals.SelectedItem != null)
            {
                Animal animal = (Animal)ListBoxAnimals.SelectedItem;
                LabelAnimalName.Text = $"Aniaml Name: {animal.AnimalName}";
                LabelAnimalFact.Text = $"Animal Fact: {animal.AnimalFact}";
                LabelAnimalDiet.Text = $"Animal Diet: {animal.AnimalDiet}";
                LabelAnimalWeight.Text = $"Animal Weight: {animal.AnimalWeightTons} tons";
                AnimalImage.Source = new BitmapImage(new Uri(animal.AnimalImage));
                AnimalImage.Margin = new Thickness(1178, 552, 0, 0);
            } else
            {
                LabelAnimalName.Text = "Animal Name:";
                LabelAnimalFact.Text = $"Animal Fact:";
                LabelAnimalDiet.Text = $"Animal Diet:";
                LabelAnimalWeight.Text = $"Animal Weight:";
                AnimalImage.Margin = new Thickness(1178, 617, 0, 0);
            }

        }

        private void AddPark_Clicked(object sender, RoutedEventArgs e)
        {
            Park park = new Park()
            {
                ParkName = TBParkName.Text,
                ParkDescription = TBParkDescription.Text,
                ParkLocation = TBParkLocation.Text,
                ParkCapacity = int.Parse(TBParkCapacity.Text)
            };

            cm.AddPark(park);
            if (DataGridParks.SelectedItem == null) { DataGridParks.Items.Add(park); }
        }

        private void UpdatePark_Clicked(object sender, RoutedEventArgs e)
        {
            var target = ((Park)DataGridParks.SelectedItem).ParkId;
            Park park = new Park()
            {
                ParkName = TBParkName.Text,
                ParkDescription = TBParkDescription.Text,
                ParkLocation = TBParkLocation.Text,
                ParkCapacity = int.Parse(TBParkCapacity.Text)
            };
            cm.UpdatePark(target, park);
            DataGridParks.ItemsSource = cm.parks;
        }

        private void DeleteParks_Clicked(object sender, RoutedEventArgs e)
        {
            var target = ((Park)DataGridParks.SelectedItem).ParkId;
            cm.DeleteParkAsync(target);
            DataGridParks.ItemsSource = cm.parks;
        }
    }
}
