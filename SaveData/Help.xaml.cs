using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Help : Page
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("MainMenu.xaml", UriKind.Relative));
        }
    }
}
