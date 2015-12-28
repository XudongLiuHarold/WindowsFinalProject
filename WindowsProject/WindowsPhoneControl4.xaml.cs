using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Utils;
using Controls;
using System.Threading.Tasks;

namespace WindowsProject
{
    public partial class WindowsPhoneControl4 : UserControl
    {
        AllData allData = AllData.getAllData();
         public WindowsPhoneControl4()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
           

        }


         void MainPage_Loaded(object sender, RoutedEventArgs e)
         {
             progressBar.Visibility = Visibility.Collapsed;
           /*  if (allData.getStationList().Count == 0)
             {
                 SharedNetwork network = SharedNetwork.sharedNetwork();
                 await network.initCites();
                 await getAllData();
             }*/
             int cityIndex = allData.CityIndex;
             CityListBox.ItemsSource = (allData.getStationList())[cityIndex]; //network.cityStaionsAir.data;
             CityListBox1.ItemsSource = (allData.getHashMap())[cityIndex];//hashMap[network.cityStaionsAir.data[0].PositionName];
             List<DataForBinding> avgData = (allData.getHashMap())[cityIndex];
             //  ((allData.getHashMap())[1])[1].
             title.Text = allData.getAvgData()[cityIndex].Area;
             pm_value.Text = allData.getAvgData()[cityIndex].AQI;
         }

         /*
          async Task getAllData()
          {
              GetPersons personInst = GetPersons.getPersonInst();
              SharedNetwork network = SharedNetwork.sharedNetwork();
              LockPage lockPage = LockPage.getLockPageInst();
              List<string> cityLists = new List<string>();

              // lockPage.Canchange = false;
              int i = 0;
              cityLists.Add("上海市");
              cityLists.Add("南京市");
              cityLists.Add("深圳市");
              cityLists.Add("西安市");
              cityLists.Add("庆阳市");


              // if(cityLists != null)
              foreach (string cityName in cityLists)
              {

                  await network.getSationAir(cityName);
                  await network.getCityAir(cityName);

                  // List<string> testList = new List<string>();

                  System.Diagnostics.Debug.WriteLine("testing..");
                  System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[0].PositionName);
                  System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data.Count());

                  List<DataForBinding> dataBindingList1 = new List<DataForBinding>();


                  dataBindingList1.Add(new DataForBinding("AQI: ", network.theCityAir.data.AQI));
                  dataBindingList1.Add(new DataForBinding("Area: ", network.theCityAir.data.Area));
                  dataBindingList1.Add(new DataForBinding("cityid: ", network.theCityAir.data.cityid));
                  dataBindingList1.Add(new DataForBinding("CO: ", network.theCityAir.data.CO));
                  dataBindingList1.Add(new DataForBinding("NO2: ", network.theCityAir.data.NO2));
                  dataBindingList1.Add(new DataForBinding("O3: ", network.theCityAir.data.O3));
                  dataBindingList1.Add(new DataForBinding("PM10: ", network.theCityAir.data.PM10));
                  dataBindingList1.Add(new DataForBinding("PM2_5: ", network.theCityAir.data.PM2_5));
                  dataBindingList1.Add(new DataForBinding("PrimaryPollutant: ", network.theCityAir.data.PrimaryPollutant));
                  dataBindingList1.Add(new DataForBinding("SO2: ", network.theCityAir.data.SO2));
                  dataBindingList1.Add(new DataForBinding("Unheathful: ", network.theCityAir.data.Unheathful));
                  dataBindingList1.Add(new DataForBinding("Quality: ", network.theCityAir.data.Quality));
                  // hashMap.Add(i, dataBindingList1);
                  allData.addAvgData(i, dataBindingList1);
                  allData.addStationData(network.cityStaionsAir.data);
                  allData.addAvgData(network.theCityAir.data);
                  i++;
              }

              System.Diagnostics.Debug.WriteLine("```````44444444444``````````````````````````````" + allData.getHashMap().Count());
              //progressBar.Visibility = Visibility.Collapsed;

              // lockPage.Canchange = true;

              // CityListBox.ItemsSource = network.cityStaionsAir.data;


          }
         */
        /*
         async void MainPage_Loaded(object sender, RoutedEventArgs e)
         {
             GetPersons personInst = GetPersons.getPersonInst();
             SharedNetwork network = SharedNetwork.sharedNetwork();
             LockPage lockPage = LockPage.getLockPageInst();
             lockPage.Canchange = false;
             await network.initCites();
             await network.getSationAir("南京市");
             await network.getCityAir("南京市");
             progressBar.Visibility = Visibility.Collapsed;

             lockPage.Canchange = true;

             // CityListBox.ItemsSource = network.cityStaionsAir.data;

             List<string> testList = new List<string>();


             System.Diagnostics.Debug.WriteLine("testing..");
             System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[0].PositionName);
             System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data.Count());

             List<DataForBinding> dataBindingList1 = new List<DataForBinding>();


             dataBindingList1.Add(new DataForBinding("AQI: ", network.theCityAir.data.AQI));
             dataBindingList1.Add(new DataForBinding("Area: ", network.theCityAir.data.Area));
             dataBindingList1.Add(new DataForBinding("cityid: ", network.theCityAir.data.cityid));
             dataBindingList1.Add(new DataForBinding("CO: ", network.theCityAir.data.CO));
             dataBindingList1.Add(new DataForBinding("NO2: ", network.theCityAir.data.NO2));
             dataBindingList1.Add(new DataForBinding("O3: ", network.theCityAir.data.O3));
             dataBindingList1.Add(new DataForBinding("PM10: ", network.theCityAir.data.PM10));
             dataBindingList1.Add(new DataForBinding("PM2_5: ", network.theCityAir.data.PM2_5));
             dataBindingList1.Add(new DataForBinding("PrimaryPollutant: ", network.theCityAir.data.PrimaryPollutant));
             dataBindingList1.Add(new DataForBinding("SO2: ", network.theCityAir.data.SO2));
             dataBindingList1.Add(new DataForBinding("Unheathful: ", network.theCityAir.data.Unheathful));
             dataBindingList1.Add(new DataForBinding("Quality: ", network.theCityAir.data.Quality));
            
             CityListBox1.ItemsSource = dataBindingList1;//hashMap[network.cityStaionsAir.data[0].PositionName];

             CityListBox.ItemsSource = network.cityStaionsAir.data;

             title.Text = network.theCityAir.data.Area;
             pm_value.Text = network.theCityAir.data.AQI;
         }
        */
         private void CityListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             if (CityListBox.SelectedIndex == -1)
                 return;

             //  Person selectedPerson = ((sender as ListBox).SelectedItem as Person);
             MessageBox.Show("ListBox selected: ");

             CityListBox.SelectedIndex = -1;
         }
    }
}
