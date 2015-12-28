using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Threading.Tasks;
using PM25onWinPhone.Utils;
using Entity;
using Utils;
using Controls;

namespace WindowsProject
{
    public partial class Sixth : PhoneApplicationPage
    {
        static Dictionary<int, List<DataForBinding>> hashMap = new Dictionary<int, List<DataForBinding>>();
        AllData allData = AllData.getAllData();
        List<string> cityLists =  new List<string>();
        static int cityCount = 0;
        public const int PageWidth = 480;
        SharedNetwork network = SharedNetwork.sharedNetwork();
        GetPersons personInst = GetPersons.getPersonInst();
        LockPage lockPage = LockPage.getLockPageInst();
        public Sixth()
        {
            cityCount = allData.getHashMap().Count();
            //创建页面列表  
            this.PageList = new List<UserControl>()   
                {   
                    new WindowsPhoneControl5() { IsEnabled = false },   
                    new WindowsPhoneControl4() { IsEnabled = false },   
                    new WindowsPhoneControl3() { IsEnabled = false }
                  
                };  
              
            this.CurrentPageIndex = 0;  
            InitializeComponent();  
            SupportedOrientations = SupportedPageOrientation.Portrait;
           // cityLists =
           
          

        }  
  
        /// <summary>  
        /// Ordered list of the panorama pages  
        /// </summary>  
        protected List<UserControl> PageList { get; set; }  
  
        /// <summary>  
        /// Index of the page currently displayed  
        /// </summary>  
        protected int CurrentPageIndex { get; set; }  
  
        private  void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)  
        {
           SharedNetwork network = SharedNetwork.sharedNetwork();
        // await network.initCites();
           // if(allData.getStationList().Count == 0)
           //    await getAllData();
            var frame = (PhoneApplicationFrame)Application.Current.RootVisual;  
            frame.Width = PageWidth * 3;
            System.Diagnostics.Debug.WriteLine("###############" + allData.getHashMap().Count());
            //载入panoramictitle控件  
           // var title = new PanoramicTitle();  
  
          // this.TitlePanel.Children.Add("ShangHai");  
           
  
            this.LoadPages();  
        }
/*
        async Task getAllData()
        {
            GetPersons personInst = GetPersons.getPersonInst();
            SharedNetwork network = SharedNetwork.sharedNetwork();
            LockPage lockPage = LockPage.getLockPageInst();
            lockPage.Canchange = false;
   
            int i = 1;
            cityLists.Add("上海市");
            cityLists.Add("南京市");
            cityLists.Add("深圳市");
            cityLists.Add("西安市");

         
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
                hashMap.Add(i, dataBindingList1);
                allData.addAvgData(i, dataBindingList1);
                i++;
            }

            System.Diagnostics.Debug.WriteLine("`````````````````````````````````````"+allData.getHashMap().Count());
            //progressBar.Visibility = Visibility.Collapsed;

            lockPage.Canchange = true;

            // CityListBox.ItemsSource = network.cityStaionsAir.data;

            
        }
      
        */
        private void LoadPages()  
        {  
            this.PanoramicGrid.Children.Clear();
            personInst.newList();
            int index = CurrentPageIndex + 1;
            personInst.addPersons(new Person("AndyAndytongji", "MgeeAndy", index));
            personInst.addPersons(new Person("AndyAndy", "MgeeAndyongong", index));
            personInst.addPersons(new Person("AndyAndy", "MgeeAndy", index));
            personInst.addPersons(new Person("AndyAndy", "MgeeAndy", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy12213121313", "Mgee", index)); 
            personInst.City = "City" +" "+index;
  
            //滑dao第一页再向左滑动  
            if (CurrentPageIndex == -1)  
            {  
                CurrentPageIndex = 0;  
            }
            //滑到第三页再向右滑动  
            if (CurrentPageIndex == 3)
            {
                CurrentPageIndex = 2;
            }  
          
  
            var currentPage = this.PageList[this.CurrentPageIndex];  
            currentPage.IsEnabled = true;  
  
            this.PanoramicGrid.Children.Add(currentPage);  
  
            Grid.SetColumn(currentPage, 1);  
            Grid.SetRow(currentPage, 1);  
  
            if (this.PageList.Count > this.CurrentPageIndex + 1)  
            {  
                var nextPage = this.PageList[this.CurrentPageIndex + 1];  
                nextPage.IsEnabled = false;  
  
                this.PanoramicGrid.Children.Add(nextPage);  
  
                Grid.SetColumn(nextPage, 2);  
                Grid.SetRow(nextPage, 1);  
            }  
  
            if (this.CurrentPageIndex > 0)  
            {  
                var previousPage = this.PageList[this.CurrentPageIndex - 1];  
                previousPage.IsEnabled = false;  
  
                this.PanoramicGrid.Children.Add(previousPage);  
  
                Grid.SetColumn(previousPage, 0);  
                Grid.SetRow(previousPage, 1);  
            }  
        }  
  
        private void PhoneApplicationPage_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)  
        {
            if (!lockPage.Canchange)
                return;
            int cityIndex = allData.CityIndex;
            if (e.TotalManipulation.Translation.X >= 100)
            {
                if (this.CurrentPageIndex == 0)
                {
                    //MessageBox.Show("now is first item");
                    CurrentPageIndex = 2;
                  
                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);
                    this.PageChangeAnimation.Begin();
                    this.LoadPages();

                    this.PanoramaContentTranslate.X += (PageWidth * -1);

                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);

                    this.PageChangeAnimation.Begin();
                }
                else 
                {
                    CurrentPageIndex -= 1;
                  
                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);
                    this.PageChangeAnimation.Begin();
                    this.LoadPages();

                    this.PanoramaContentTranslate.X += (PageWidth * -1);

                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);

                    this.PageChangeAnimation.Begin();
                   //this.ContentPanel.Children.Clear();
                    //txtName.Text = String.Format("list :{0}", index);//txtblk.Text = String.Format("Parameter1 is:{0} and parameter2 is:{1}", parameter1, parameter2);

                  //this.ContentPanel.Children.Add(UserControlList[index]);
                }

                cityIndex -= 1;
                if (cityIndex < 0)
                {
                    cityIndex = cityCount - 1;
                    if (cityIndex < 0)
                        cityIndex = 0;
                }
                    
            }
            else if (e.TotalManipulation.Translation.X <= -100)
            {
                if (this.CurrentPageIndex == 2)
                {
                    //MessageBox.Show("now is end item");
                    CurrentPageIndex = 0;
                  
                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);
                    this.PageChangeAnimation.Begin();
                    this.LoadPages();

                    this.PanoramaContentTranslate.X += (PageWidth * 1);

                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);

                    this.PageChangeAnimation.Begin();

                }
                else
                {
                    CurrentPageIndex += 1;
                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);
                    this.PageChangeAnimation.Begin();
                    this.LoadPages();

                    this.PanoramaContentTranslate.X += (PageWidth * 1);

                    this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);

                    this.PageChangeAnimation.Begin();
                }

                cityIndex += 1;
                if (cityIndex >= cityCount)
                    cityIndex = 0;
            }

            System.Diagnostics.Debug.WriteLine("-=-=-=-=-=-=-= " + cityIndex);
            allData.CityIndex = cityIndex;
         
           /* if (e.OriginalSource is Panel)  
            {  
                if (e.TotalManipulation.Translation.X < 0)  
                {
                    if (e.TotalManipulation.Translation.X > -100 || this.CurrentPageIndex >= this.PageList.Count - 1)  
                    {  
                        this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);  
                        this.PageChangeAnimation.Begin();  
                    }  
                    else  
                    {  
                        this.ChangePage(1);  
                    }  
                }  
                else if (e.TotalManipulation.Translation.X > 0)  
                {  
                    if (e.TotalManipulation.Translation.X < 100 )  
                    {  
                        this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);  
                        this.PageChangeAnimation.Begin();  
                    }  
                    else  
                    {  
                        this.ChangePage(-1);  
                    }  
                }  
            }*/  
        }  
  
        private void ChangePage(int step)  
        {  
            this.CurrentPageIndex += step;  
  
            this.LoadPages();  
  
            this.PanoramaContentTranslate.X += (PageWidth * step);  
  
            this.SlideTitleDoubleAnimation.To = this.CurrentPageIndex * PageWidth / 2 * (-1);  
  
            this.PageChangeAnimation.Begin();  
        }  
  
        private void PhoneApplicationPage_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)  
        {  
            if (e.OriginalSource is Panel)  
            {  
                this.PanoramaContentTranslate.X = e.CumulativeManipulation.Translation.X - PageWidth;
               // title.Text = "City-" + this.CurrentPageIndex;
  
                //this.TitleTranslate.X = e.CumulativeManipulation.Translation.X / 2 - (this.CurrentPageIndex * PageWidth / 2);  
            }  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AddCity.xaml", UriKind.Relative));
        }  
    }
}