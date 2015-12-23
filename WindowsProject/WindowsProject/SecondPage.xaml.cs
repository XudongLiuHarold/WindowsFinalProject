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
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs args)
        {
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if (parameters.ContainsKey("parameter1"))
            {
                string parameter1 = parameters["parameter1"];
                string parameter2 = parameters["parameter2"];
                txtblk.Text = String.Format("Parameter1 is:{0} and parameter2 is:{1}", parameter1, parameter2);
            }
            base.OnNavigatedTo(args);
        }


    }
}