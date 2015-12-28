using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WindowsProject.Resources;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using Controls;
using Dataset;

namespace WindowsProject
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数

        AllData allData = AllData.getAllData();
        List<string> cityLists = new List<string>();
        List<ChoCity> lCity = new List<ChoCity>();
        MyDataContext MyDataContext;
        public MainPage()
        {



            InitializeComponent();
            MyDataContext = new MyDataContext("Data Source=isostore:/MyDataContext.sdf");
            lCity = (from city in MyDataContext.CityTable select city).ToList();
            progressBar.Visibility = Visibility.Collapsed;
           // LayoutRoot.Background = new SolidColorBrush(Colors.Blue);

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        /*
        private void TextBlock_ManipulationStarted(object sender, ManipulationStartedEventArgs args)
        {
            //string destination = "/SecondPage.xaml?parameter1=hello&parameter2=world";
            string destination = "/Sixth.xaml";
            //string destination = "/Fifth.xaml";
            this.NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            args.Complete();
            args.Handled = true;

        }*/

        /*
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SharedNetwork network = SharedNetwork.sharedNetwork();
            await network.initCites();
            await getAllData();

            hideText.Text = "tongji University";
            hideText.Visibility = System.Windows.Visibility.Visible;

           
        }
        */
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
            foreach (ChoCity city in lCity)
            {

                await network.getSationAir(city.CityName);
                await network.getCityAir(city.CityName);

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
                dataBindingList1.Add(new DataForBinding("Quality: ", network.theCityAir.data.Quality));
                dataBindingList1.Add(new DataForBinding("Unheathful: ", network.theCityAir.data.Unheathful));
                dataBindingList1.Add(new DataForBinding("Measure: ", network.theCityAir.data.Measure));

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

     
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lCity != null && lCity.Count > 0)
            {
                progressBar.Visibility = Visibility.Visible;
                startButton.Visibility = System.Windows.Visibility.Collapsed;
                waitInfo.Visibility = System.Windows.Visibility.Visible;
                SharedNetwork network = SharedNetwork.sharedNetwork();
                await network.initCites();
                await getAllData();
                allData.Lcitys = lCity;
                progressBar.Visibility = Visibility.Collapsed;
               
                this.NavigationService.Navigate(new Uri("/Sixth.xaml", UriKind.Relative));
                startButton.Visibility = System.Windows.Visibility.Visible;
                waitInfo.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                this.NavigationService.Navigate(new Uri("/AddCity.xaml", UriKind.Relative));
            }
        }


        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}