using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace fmanager.win
{
    using Pages;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum AppPages
        {
            HomePage,
            SettingsPage,
            AddProjectPage,
        }

        private IDictionary<AppPages, Page> _pages;
        private NavigationService _navigationService;

        public MainWindow()
        {
            InitializeComponent();
            _pages = new Dictionary<AppPages, Page>();
            _pages[AppPages.HomePage] = new HomePage();
            _pages[AppPages.SettingsPage] = new Settings();
            _pages[AppPages.AddProjectPage] = new AddProject();
            _navigationService = this.ContentFrame.NavigationService;
        }

        private void ProjectsPage_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(_pages[AppPages.HomePage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(_pages[AppPages.AddProjectPage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(_pages[AppPages.SettingsPage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void FrowardBtn_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.GoForward();
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            _navigationService.GoBack();
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
        }
    }
}
