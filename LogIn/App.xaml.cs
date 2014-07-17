using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
          
            var viewModel = new LoginViewModel();
            var envList = new ServiceConfig[]
            {
                new ServiceConfig
                {
                    EnvironmentName = "hk_dev4",
                    AuthenticationUrl = "localhost"
                },
                 new ServiceConfig
                {
                    EnvironmentName = "hk_prep1",
                    AuthenticationUrl = "localhost"
                }
                ,
                new ServiceConfig
                {
                    EnvironmentName = "jp_prep1",
                    AuthenticationUrl = "localhost"
                }
            };
            viewModel.Environments = envList;
            window.SetViewModel(viewModel);
            window.Show();
        }
    }
}
