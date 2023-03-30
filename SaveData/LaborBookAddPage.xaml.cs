using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for LaborBookAddPage.xaml
    /// </summary>
    public partial class LaborBookAddPage : Page
    {
        public LaborBookAddPage()
        {
            InitializeComponent();
            
            comboBoxDepartment.ItemsSource = AppConnect.modelOdb.Отделы.Select(x => x.Наименование_отдела).ToList();
            comboBoxPosition.ItemsSource = AppConnect.modelOdb.Должности.Select(x => x.Наименование_должности).ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Трудовая_книга()
            {
                Табельный_номер = int.Parse(textBoxTableNumber.Text),
                Код_отдела = AppConnect.modelOdb.Отделы.FirstOrDefault(x => x.Наименование_отдела == comboBoxDepartment.SelectedItem.ToString()).Код_отдела,
                Код_должности = AppConnect.modelOdb.Должности.FirstOrDefault(x => x.Наименование_должности == comboBoxPosition.SelectedItem.ToString()).Код_должности,
                Примечание = textBoxReason.Text,
                Дата_начала = laborBookDateStartPicker.SelectedDate.Value.Date,
                Дата_окончания = laborBookDateEndPicker.SelectedDate.Value.Date,
            };

            try
            {
                AppConnect.modelOdb.Трудовая_книга.Add(newBook);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("LaborBookDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("LaborBookDataGrid.xaml", UriKind.Relative));
        }

    }
}
