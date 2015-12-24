using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PM25onWinPhone.Utils;
using Utils;

namespace WindowsProject
{
    public partial class WindowsPhoneControl5 : UserControl
    {
        
        public WindowsPhoneControl5()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetPersons personInst = GetPersons.getPersonInst();
            SharedNetwork network = SharedNetwork.sharedNetwork();
            CityListBox.ItemsSource = personInst.getPersonList();
            CityListBox1.ItemsSource = personInst.getPersonList();
            await network.getSationAir("上海市");

            System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[0].PositionName);
            title.Text = personInst.City;
        }

        private void CityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityListBox.SelectedIndex == -1)
                return;

            Person selectedPerson = ((sender as ListBox).SelectedItem as Person);
            MessageBox.Show("ListBox selected: " + selectedPerson);

            CityListBox.SelectedIndex = -1;
        }
    }
}
