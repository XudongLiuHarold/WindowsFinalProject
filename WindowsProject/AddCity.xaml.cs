using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Documents;
using Dataset;
using Controls;

namespace WindowsProject
{
    public partial class AddCity : PhoneApplicationPage
    {
        MyDataContext MyDataContext;
        List<ChoCity> lCity = new List<ChoCity>();
        List<ChoCity> delCity = new List<ChoCity>();
        AllData allData = AllData.getAllData();
        bool bEdit = false;

        public AddCity()
        {
            InitializeComponent();

            MyDataContext = new MyDataContext("Data Source=isostore:/MyDataContext.sdf");

            
        }

        private void citylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bEdit == true)
            {
                ChoCity dCity = (ChoCity)citylist.SelectedItem;

                delCity.Add(dCity);

                List<TextBlock> tbList = FindChildOfType<TextBlock>(citylist);
                for (int i = 0; i < tbList.Count; i++)
                {
                    bool dBool = false;
                    for (int j = 0; j < delCity.Count; j++)
                    {
                        if (delCity[j].CityName == tbList[i].Text)
                        {
                            dBool = true;
                            break;
                        }
                    }
                    if (dBool == true)
                    {
                        tbList[i].Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                editButton.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void citylist_Loaded(object sender, RoutedEventArgs e)
        {
            lCity = (from city in MyDataContext.CityTable select city).ToList();
            citylist.ItemsSource = lCity; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/ChooseAdd.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (bEdit == false)
            {
                bEdit = true;

                while (delCity.Count != 0)
                {
                    delCity.RemoveAt(0);
                }

                editButton.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                bEdit = false;

                for (int i = 0; i < delCity.Count; i++)
                {
                    lCity.Remove(delCity[i]);

                    MyDataContext.CityTable.DeleteOnSubmit(delCity[i]);
                    MyDataContext.SubmitChanges();
                }

                citylist.ItemsSource = null;
                citylist.ItemsSource = lCity;

                editButton.Foreground = new SolidColorBrush(Colors.White);
            }
        }

        public List<T> FindChildOfType<T>(DependencyObject root) where T : class
        {
            var queue = new Queue<DependencyObject>();
            List<T> listT = new List<T>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typeChild = child as T;
                    if (typeChild != null)
                    {
                        listT.Add(typeChild);
                        //return typeChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return listT;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (bEdit == false)
            {
                List<ChoCity> listCity = allData.Lcitys;
                string cityName = (sender as TextBlock).Text;
                System.Diagnostics.Debug.WriteLine(cityName);

                for (int i = 0; i< listCity.Count();i++)
                {
                    ChoCity city = listCity[i];
                    if (city.CityName.Equals(cityName))
                    {
                        System.Diagnostics.Debug.WriteLine(cityName + "   " + i);
                        allData.CityIndex = i;
                        break;
                    }
                }
                this.NavigationService.Navigate(new Uri("/Sixth.xaml", UriKind.Relative));
              //  ChoCity cityName = ((sender as ListBox).SelectedItem as ChoCity);
                System.Diagnostics.Debug.WriteLine("--------------");
               // MessageBox.Show("ListBox selected: " + (sender as TextBlock).Text);
                //this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void TextBlock_Hold(object sender, RoutedEventArgs e)
        {
            if (bEdit == true)
            {
                ChoCity dCity = (ChoCity)citylist.SelectedItem;
                lCity.Remove(dCity);

                if (dCity != null)
                {
                    MyDataContext.CityTable.DeleteOnSubmit(dCity);
                    MyDataContext.SubmitChanges();
                }

                citylist.ItemsSource = null;
                citylist.ItemsSource = lCity;
            }
            else
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}