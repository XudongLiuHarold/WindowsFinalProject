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
using Controls;
using System.Threading.Tasks;


namespace WindowsProject
{
    public partial class WindowsPhoneControl5 : UserControl
    {
        static Dictionary<int, List<DataForBinding>> hashMap = new Dictionary<int, List<DataForBinding>>();
        AllData allData = AllData.getAllData();
        List<string> cityLists = new List<string>();
       // int cityCount = 0;
        public const int PageWidth = 480;
        SharedNetwork network = SharedNetwork.sharedNetwork();
        GetPersons personInst = GetPersons.getPersonInst();
        LockPage lockPage = LockPage.getLockPageInst();

       // AllData allData = AllData.getAllData();
        public WindowsPhoneControl5()
        {
            InitializeComponent();
          
        
            Loaded += new RoutedEventHandler(MainPage_Loaded);                                                                                          

        }



         void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            if (allData.getStationList() == null || allData.getStationList().Count == 0)
            {

                lockPage.Canchange = false;
              
                await getAllData();
                lockPage.Canchange = true;
            }*/

         
            progressBar.Visibility = Visibility.Collapsed;
            int cityIndex = allData.CityIndex;

            CityListBox.ItemsSource = (allData.getStationList())[cityIndex]; //network.cityStaionsAir.data;
            CityListBox1.ItemsSource = (allData.getHashMap())[cityIndex];//hashMap[network.cityStaionsAir.data[0].PositionName];
            List<DataForBinding> avgData = (allData.getHashMap())[cityIndex];
            //  ((allData.getHashMap())[1])[1].
            title.Text = allData.getAvgData()[cityIndex].Area;
            pm_value.Text = allData.getAvgData()[cityIndex].AQI;
           // measure.Text = allData.getMeasure()[2];
        }
        /*
        async Task getAllData()
        {
            GetPersons personInst = GetPersons.getPersonInst();
            SharedNetwork network = SharedNetwork.sharedNetwork();
            LockPage lockPage = LockPage.getLockPageInst();
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
                System.Diagnostics.Debug.WriteLine(cityName);
                await network.getSationAir(cityName);

                System.Diagnostics.Debug.WriteLine("testing[][][][][..");

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

            System.Diagnostics.Debug.WriteLine("`````````````````````````````````````" + allData.getHashMap().Count());
            //progressBar.Visibility = Visibility.Collapsed;

            // lockPage.Canchange = true;

            // CityListBox.ItemsSource = network.cityStaionsAir.data;


        }
        */
/*
       // async void MainPage_Loaded(object sender, RoutedEventArgs e)
        async void MainPage_Loaded(object sender, RoutedEventArgs e)

        {
            GetPersons personInst = GetPersons.getPersonInst();
            SharedNetwork network = SharedNetwork.sharedNetwork();
            LockPage lockPage = LockPage.getLockPageInst();
            lockPage.Canchange = false;
         await  network.initCites();
          await network.getSationAir("上海市");
          await network.getCityAir("上海市");
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
           /* for (int i = 0; i < network.cityStaionsAir.data.Count(); i++)
            {
               List<DataForBinding> dataBindingList = new List<DataForBinding>();

                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].AQI);
                dataBindingList.Add(new DataForBinding("AQI: ", network.cityStaionsAir.data[i].AQI));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].Area);
                dataBindingList.Add(new DataForBinding("Area: ", network.cityStaionsAir.data[i].Area));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].cityid);
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].CO);
                dataBindingList.Add(new DataForBinding("CO: ", network.cityStaionsAir.data[i].CO));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].CO_24h);
                dataBindingList.Add(new DataForBinding("CO_24h: ", network.cityStaionsAir.data[i].CO_24h));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].Measure);
               // dataBindingList.Add(new DataForBinding("Measure: ", network.cityStaionsAir.data[i].Measure));
                dataBindingList.Add(new DataForBinding("PM2_5: ", network.cityStaionsAir.data[i].PM2_5));
                dataBindingList.Add(new DataForBinding("PM2_5_24h: ", network.cityStaionsAir.data[i].PM2_5_24h));
                dataBindingList.Add(new DataForBinding("SO2: ", network.cityStaionsAir.data[i].SO2));
                dataBindingList.Add(new DataForBinding("SO2_24h: ", network.cityStaionsAir.data[i].SO2_24h));
                dataBindingList.Add(new DataForBinding("Unheathful: ", network.cityStaionsAir.data[i].Unheathful));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].NO2);
                dataBindingList.Add(new DataForBinding("NO2: ", network.cityStaionsAir.data[i].NO2));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].NO2_24h);
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].O3);
                dataBindingList.Add(new DataForBinding("O3: ", network.cityStaionsAir.data[i].O3));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].O3_24h);
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].O3_8h);
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].PM10_24h);
                dataBindingList.Add(new DataForBinding("PM10_24h: ", network.cityStaionsAir.data[i].PM10_24h));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].PositionName);
                dataBindingList.Add(new DataForBinding("PositionName: ", network.cityStaionsAir.data[i].PositionName));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].PrimaryPollutant);
                dataBindingList.Add(new DataForBinding("PrimaryPollutant", network.cityStaionsAir.data[i].PrimaryPollutant));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].Quality);
                dataBindingList.Add(new DataForBinding("Quality: ", network.cityStaionsAir.data[i].Quality));
                System.Diagnostics.Debug.WriteLine(network.cityStaionsAir.data[i].TimePoint);
                dataBindingList.Add(new DataForBinding("TimePoint: ", network.cityStaionsAir.data[i].TimePoint));
                hashMap.Add(network.cityStaionsAir.data[i].PositionName, dataBindingList);
                dataBindingList1 = dataBindingList;

            }*/
        /*
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
            MessageBox.Show("ListBox selected: " );

            CityListBox.SelectedIndex = -1;
        }

     
    }
}
