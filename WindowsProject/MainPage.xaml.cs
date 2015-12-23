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

namespace WindowsProject
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
       
        public MainPage()
        {
            InitializeComponent();
           
          //  btn.SetValue(Grid.RowProperty, 0);
           // btn.SetValue(Grid.ColumnProperty, 1);

            TextBlock tb = new TextBlock();
            tb.Text = "hihidsdosds";
            Canvas.SetLeft(tb, 50);
            Canvas.SetTop(tb, 50);

            
            LayoutRoot.Background = new SolidColorBrush(Colors.Blue);

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

       
        private void TextBlock_ManipulationStarted(object sender, ManipulationStartedEventArgs args)
        {
            //string destination = "/SecondPage.xaml?parameter1=hello&parameter2=world";
            string destination = "/Sixth.xaml";
           //string destination = "/Fifth.xaml";
            this.NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            args.Complete();
            args.Handled = true;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hideText.Text = "tongji University";
            hideText.Visibility = System.Windows.Visibility.Visible;

            Button btn = new Button();
            btn.Content = "Click";
            btn.Width = 100;
            btn.Height = 90;
            btn.Click += myclick;
           //btn.SetValue(Grid.RowProperty, 0);
           // btn.SetValue(Grid.ColumnProperty, 1);

            //.LayoutRoot.Children.Add(btn);
           ContentPanel2.Children.Add(btn);
            

        }

        private void myclick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dsds");
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