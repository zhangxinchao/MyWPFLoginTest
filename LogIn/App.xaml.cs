using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace LogIn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();

            ServicesConfig ans;
            using (System.IO.FileStream fs = System.IO.File.Open("Environments.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ServicesConfig));
                ans = ser.Deserialize(fs) as ServicesConfig;
            }


            var viewModel = new LoginViewModel();
            viewModel.Environments = ans;
           
   
            window.SetViewModel(viewModel);
            window.Show();
        }
    }
}
