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

using PM25onWinPhone.Utils;
using PM25onWinPhone.Entity;

namespace WindowsProject
{
    public partial class Sixth : PhoneApplicationPage
    {
       
        public const int PageWidth = 480;
        SharedNetwork network = SharedNetwork.sharedNetwork();
        GetPersons personInst = GetPersons.getPersonInst();
        public Sixth()
        {  
  
            //创建三个页面列表  
            this.PageList = new List<UserControl>()   
                {   
                    new WindowsPhoneControl5() { IsEnabled = false },   
                    new WindowsPhoneControl2() { IsEnabled = false },   
                    new WindowsPhoneControl3() { IsEnabled = false },
                    new WindowsPhoneControl1() { IsEnabled = false }   
                };  
              
            this.CurrentPageIndex = 0;  
  
            InitializeComponent();  
  
            SupportedOrientations = SupportedPageOrientation.Portrait;  
        }  
  
        /// <summary>  
        /// Ordered list of the panorama pages  
        /// </summary>  
        protected List<UserControl> PageList { get; set; }  
  
        /// <summary>  
        /// Index of the page currently displayed  
        /// </summary>  
        protected int CurrentPageIndex { get; set; }  
  
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)  
        {
            SharedNetwork network = SharedNetwork.sharedNetwork();

            var frame = (PhoneApplicationFrame)Application.Current.RootVisual;  
            frame.Width = PageWidth * 3;  
  
            //载入panoramictitle控件  
           // var title = new PanoramicTitle();  
  
          // this.TitlePanel.Children.Add("ShangHai");  
  
            this.LoadPages();  
        }  
  
        private void LoadPages()  
        {  
            this.PanoramicGrid.Children.Clear();
            personInst.newList();
            int index = CurrentPageIndex + 1;
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Andy", "Mgee", index));
            personInst.addPersons(new Person("Wang", "Mgee", index));
            personInst.addPersons(new Person("Wang", "Mgee", index));
            
 //           network.getCityAir("上海市");
           // CityAir theCityAir = network.theCityAir;
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
            }
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
    }
}