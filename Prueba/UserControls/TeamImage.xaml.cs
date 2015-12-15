using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Prueba.UserControls
{
    public sealed partial class TeamImage : UserControl
    {
        public TeamImage()
        {
            this.InitializeComponent();
            RemoteServices.testWebServices(myGridV);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam =(Team) ((Button)e.OriginalSource).DataContext;
            TeamDAL.insertTeam(selectedTeam);
            myGridVDB.ItemsSource=await TeamDAL.getAllTeam();
        }
    }
}
