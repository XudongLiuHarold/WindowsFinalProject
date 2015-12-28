using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dataset;

namespace WindowsProject
{
    public partial class ChooseAdd : PhoneApplicationPage
    {
        MyDataContext MyDataContext;
        List<ColCity> lColCity = new List<ColCity>();

        public ChooseAdd()
        {
            InitializeComponent();
            MyDataContext = new MyDataContext("Data Source=isostore:/MyDataContext.sdf");

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            citylist.ItemsSource = null;
            lColCity = (from colcity in MyDataContext.ColCityTable where colcity.ColCityName.Contains(cityChange.Text) select colcity).ToList();

            for (int i = 0; i < lColCity.Count; i++)
            {
                var inCity = (from cityIn in MyDataContext.CityTable where cityIn.CityName == lColCity[i].ColCityName select cityIn).ToList();
                if (inCity.Count > 0)
                {
                    lColCity.Remove(lColCity[i]);
                    i--;
                }
            }

            citylist.ItemsSource = lColCity;
        }

        private void citylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ColCity cCity = (ColCity)citylist.SelectedItem;
            string nCity = cCity.ColCityName;

            var lCity = (from cityIn in MyDataContext.CityTable where cityIn.CityName == nCity select cityIn).ToList();

            if (lCity.Count > 0)
            {
                MessageBox.Show("city already in");
                return;
            }

            ChoCity newCity = new ChoCity { CityName = nCity };



            MyDataContext.CityTable.InsertOnSubmit(newCity);
            MyDataContext.SubmitChanges();

            this.NavigationService.Navigate(new Uri("/AddCity.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cityChange.Text = String.Empty;
        }
    }
}