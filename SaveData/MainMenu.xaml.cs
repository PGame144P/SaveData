using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace SaveData
{
    public partial class MainMenu : Window
    {

        public MainMenu()
        {
            InitializeComponent();
            navigationFrame.NavigationService.Navigate(new Uri("SaveDataGrid.xaml", UriKind.Relative));
            FrameManager.NavigationFrame = navigationFrame;
        }
        
        private Dictionary<string, string> pages = new Dictionary<string, string>
            {
                {"Сотрудники", "SaveDataGrid.xaml"},
                {"Штатное расписание", "ScheduleDataGrid.xaml"},
                {"Отделы", "DepartmentsDataGrid.xaml"},
                {"Трудовая книга", "LaborBookDataGrid.xaml"},
                {"Трудовые договоры", "EmploymentContractDataGrid.xaml"},
                {"Должности", "PositionsDataGrid.xaml"},
                {"Начисление ЗП", "PaymentsDataGrid.xaml"},
            };

        private Dictionary<string, string> addPages = new Dictionary<string, string>
            {
                {"Сотрудники", "SaveAddPage.xaml"},
                {"Штатное расписание", "ScheduleAddPage.xaml"},
                {"Отделы", "DepartmentsAddPage.xaml"},
                {"Трудовая книга", "LaborBookAddPage.xaml"},
                {"Трудовые договоры", "EmploymentContractAddPage.xaml"},
                {"Должности", "PositionsAddPage.xaml"},
                {"Начисление ЗП", "PaymentsAddPage.xaml"},
            };

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                //this.DragMove();
            }
        }

        private bool isMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) 
            {
                if (isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1200;
                    this.Height = 720;

                    isMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    isMaximized = true;
                }
            }
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var buttonSender = sender as Button;
            var buttonText = ((buttonSender.Content as StackPanel).Children[1] as TextBlock).Text;

            pageTitle.Text = buttonText;

            FrameManager.NavigationFrame.Navigate(new Uri(pages.FirstOrDefault(x => x.Key == buttonText).Value, UriKind.Relative));
        }
            
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAddRecord_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.Navigate(new Uri(addPages.FirstOrDefault(x => x.Key == pageTitle.Text).Value, UriKind.Relative));
        }
    }
} 
