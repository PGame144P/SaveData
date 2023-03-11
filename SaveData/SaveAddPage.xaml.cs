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
