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
    public partial class WindowsPhoneControl3 : UserControl
    {
        List<Person> people;
        public WindowsPhoneControl3()
        {
            InitializeComponent();
            TextBlock txte = new TextBlock();
            txte.Text = "this tiem is add in code";

            people = new List<Person>();
            /*
            Visibility darkBackgroundVisibility =
            (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
            
            Color color = new Color();
            color.B = 100;
            color.R = 0;
            color.G = 0;
            SolidColorBrush bf = new SolidColorBrush(color);*/

           // LayoutRoot.Background = new SolidColorBrush(Colors.LightGray);
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            people.Add(new Person("Andy", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));
            GetPersons personInst = GetPersons.getPersonInst();

            PeopleListBox.ItemsSource = personInst.getPersonList();
            title.Text = personInst.City;

        }

        private void PeopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PeopleListBox.SelectedIndex == -1)
                return;

            Person selectedPerson = ((sender as ListBox).SelectedItem as Person);
            MessageBox.Show("ListBox selected: " + selectedPerson);

            PeopleListBox.SelectedIndex = -1;
        }
    }
}
