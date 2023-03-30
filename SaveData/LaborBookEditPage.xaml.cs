using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    public partial class LaborBookEditPage : Page
    {
        public ТрудоваяКнигаView _currentLaborBook = new ТрудоваяКнигаView();
        public Трудовая_книга realLaborBook = new Трудовая_книга(); 
       
        public LaborBookEditPage(ТрудоваяКнигаView selectedLaborBook)
        {
            InitializeComponent();

            if (selectedLaborBook != null)
                _currentLaborBook = selectedLaborBook;
            
            realLaborBook = AppConnect.modelOdb.Трудовая_книга.FirstOrDefault(x => x.Код_трудовой_книги == _currentLaborBook.Код_трудовой_книги);
            DataContext = realLaborBook;

            comboBoxDepartment.ItemsSource = AppConnect.modelOdb.Отделы.Select( x => x.Наименование_отдела).ToList();
            comboBoxDepartment.SelectedItem = _currentLaborBook.Наименование_отдела;

            comboBoxPosition.ItemsSource = AppConnect.modelOdb.Должности.Select(x => x.Наименование_должности).ToList();
            comboBoxPosition.SelectedItem = _currentLaborBook.Наименование_должности;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                realLaborBook.Код_отдела = AppConnect.modelOdb.Отделы.FirstOrDefault(x => x.Наименование_отдела == (string)comboBoxDepartment.SelectedItem).Код_отдела;
                realLaborBook.Код_должности = AppConnect.modelOdb.Должности.FirstOrDefault(x => x.Наименование_должности == (string)comboBoxPosition.SelectedItem).Код_должности;

                AppConnect.modelOdb.SaveChanges(); 
                
                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("LaborBookDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("LaborBookDataGrid.xaml", UriKind.Relative));
        }
    }
}
