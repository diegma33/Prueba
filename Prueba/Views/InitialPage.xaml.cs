using Prueba.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Prueba.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitialPage : Page
    {
        public InitialPage()
        {
            this.InitializeComponent();
        }

        private void DropAll_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).teamImagesVM.cleanBD();
        }

        private void SaveAll_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).teamImagesVM.saveAll();
        }
    }
}
