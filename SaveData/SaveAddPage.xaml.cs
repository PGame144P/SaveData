using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for SaveAddpage.xaml
    /// </summary>
    public partial class SaveAddpage : Page
    {
        public SaveAddpage()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newSave = new Сотрудники()
            {
                Фамилия = textBoxLastName.Text,
                Имя = textBoxFirstName.Text,
                Отчество = textBoxMiddleName.Text,
                Телефон = decimal.Parse(textBoxPhone.Text),
                Стаж = int.Parse(textBoxExperience.Text),
                Код_трудовой_книги = int.Parse(textBoxLaborBookCode.Text),
            };

            try
            {
                AppConnect.modelOdb.Сотрудники.Add(newSave);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("SaveDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("SaveDataGrid.xaml", UriKind.Relative));
        }
    }
}
