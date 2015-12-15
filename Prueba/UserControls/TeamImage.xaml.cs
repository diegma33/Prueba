using Prueba.Models;
using Prueba.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Prueba.UserControls
{
    public sealed partial class TeamImage : UserControl
    {
        public TeamImage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Team selectedTeam =(Team) ((Button)e.OriginalSource).DataContext;

            ((TeamViewModel)this.DataContext).saveTeam(selectedTeam);
        }
    }
}
