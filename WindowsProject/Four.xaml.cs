using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WindowsProject
{
    public partial class Four : PhoneApplicationPage
    {
        List<UserControl> UserControlList;
        GetPersons personInst = GetPersons.getPersonInst();
        //当前集合的显示项索引
        int index = 0;

        public Four()
        {
            InitializeComponent();

            UserControlList = new List<UserControl>()
            {
                new WindowsPhoneControl1(),
                new WindowsPhoneControl2(),
                new WindowsPhoneControl3()
            };
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
                    txtName.Text = String.Format("list :{0}", index);//txtblk.Text = String.Format("Parameter1 is:{0} and parameter2 is:{1}", parameter1, parameter2);

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
                    txtName.Text = String.Format("list :{0}", index);
                    this.ContentPanel.Children.Add(UserControlList[index]);
                   // string city = title.Text;
                    title.Text = "City" + index;
                    personInst.newList();
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

                }
            }

            //切换之后恢复ContentPanel容器的偏移量
            transform.TranslateX = 0;
        }
    }
}