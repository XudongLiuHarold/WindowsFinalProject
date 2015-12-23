using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace WindowsProject
{
    public partial class Fifth : PhoneApplicationPage
    {
        List<Person> people;
        public Fifth()
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

            LayoutRoot.Background =new SolidColorBrush(Colors.LightGray);
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
           

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
            people.Add(new Person("Tim", "Mgee", 36));
            people.Add(new Person("Frank", "Solo", 77));
            people.Add(new Person("Hanna", "Jones", 77));

            PeopleListBox.ItemsSource = people;
        }

        private void LastNameTextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Person selectedPerson = ((sender as TextBlock).DataContext as Person);
            MessageBox.Show("Last Name TextBlock clicked: " + selectedPerson.LastName);
         

            e.Handled = true;
        }

        private void AgeRect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Person selectedPerson = ((sender as Rectangle).DataContext as Person);
            MessageBox.Show("Age Rectangle clicked: " + selectedPerson.Age);

            e.Handled = true;
            LayoutRoot.Background = new SolidColorBrush(Colors.Red);
        }

        private void PeopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PeopleListBox.SelectedIndex == -1)
                return;

            Person selectedPerson = ((sender as ListBox).SelectedItem as Person);
            MessageBox.Show("ListBox selected: " + selectedPerson);

            PeopleListBox.SelectedIndex = -1;
        }

        private void FirstNameButton_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = ((sender as Button).DataContext as Person);
            MessageBox.Show("First Name Button clicked: " + selectedPerson.FirstName);
        }
    }
}