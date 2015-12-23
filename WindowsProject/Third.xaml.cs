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
using System.Windows.Input;

namespace WindowsProject
{
    public partial class Third : PhoneApplicationPage
    {
        List<UserControl> UserControlList;
        //当前集合的显示项索引
        int index = 0;

        public Third()
        {
            InitializeComponent();

            UserControlList = new List<UserControl>()
            {
                new WindowsPhoneControl4(),
                new WindowsPhoneControl2(),
                new WindowsPhoneControl3()
            };

            for (int i = 0; i < 30; i++) 
            {
                listbox1.Items.Add("Item list " + i);
            }
        }

        private void listbox1_MouseMove(object sender, MouseEventArgs e)
        {
           ScrollViewer scrollViewer = FindChildOfType<ScrollViewer>(listbox1);
           if (scrollViewer == null)
           {
               throw new InvalidOperationException("erro");
           }
           else
           {
               if (scrollViewer.VerticalOffset >= scrollViewer.ScrollableHeight)
               {
                   int k = listbox1.Items.Count;
                   listbox1.Items.Add("Item and list" + k);
                   k++;
               }
               
           }
        }


        static T FindChildOfType<T>(DependencyObject root) where T : class 
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                DependencyObject current = queue.Dequeue();
                for (int i = VisualTreeHelper.GetChildrenCount(current) - 1; i >= 0; i--)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded_1(object sender, RoutedEventArgs e)
        {
            //首次加载集合的第一项
            this.ContentPanel.Children.Add(UserControlList[0]);
        }

        private void ContentPanel_ManipulationDelta_1(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            transform.TranslateX += e.DeltaManipulation.Translation.X;
            transform.TranslateY = 0;
        }

        private void ContentPanel_ManipulationCompleted_1(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            //ContentPanel容器总转换的线性运动的X坐标值〉=100
            if (e.TotalManipulation.Translation.X >= 100)
            {
                if (this.index == 0)
                {
                    MessageBox.Show("now is first item");
                }
                else
                {
                    index -= 1;
                    this.ContentPanel.Children.Clear();
                    this.ContentPanel.Children.Add(UserControlList[index]);
                }
            }
            else if (e.TotalManipulation.Translation.X <= -100)
            {
                if (this.index == 2)
                {
                    MessageBox.Show("Now is final item");
                }
                else
                {
                    index += 1;
                    this.ContentPanel.Children.Clear();
                    this.ContentPanel.Children.Add(UserControlList[index]);
                }
            }

            //切换之后恢复ContentPanel容器的偏移量
            transform.TranslateX = 0;
        }
    }
}