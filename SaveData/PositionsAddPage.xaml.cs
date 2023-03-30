using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for PositionsAddPage.xaml
    /// </summary>
    public partial class PositionsAddPage : Page
    {
        public PositionsAddPage()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newPosition = new Должности()
            {
                Наименование_должности = positionName.Text,
            };

            try
            {
                AppConnect.modelOdb.Должности.Add(newPosition);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PositionsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PositionsDataGrid.xaml", UriKind.Relative));
        }
    }
}
