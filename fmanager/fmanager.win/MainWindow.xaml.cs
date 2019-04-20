using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace fmanager.win
{
    using Views.Pages;

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

        private IDictionary<AppPages, Page> _Pages;
        private NavigationService _NavigationService;

        public MainWindow()
        {
            InitializeComponent();
            _Pages = new Dictionary<AppPages, Page>();
            //_Pages[AppPages.HomePage] = new HomePage();
            //_Pages[AppPages.SettingsPage] = new Settings();
            //_Pages[AppPages.AddProjectPage] = new AddProject();
            _NavigationService = this.ContentFrame.NavigationService;
        }

        private void ProjectsPage_Click(object sender, RoutedEventArgs e)
        {
            _NavigationService.Navigate(_Pages[AppPages.HomePage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
        }

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            _NavigationService.Navigate(_Pages[AppPages.AddProjectPage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            _NavigationService.Navigate(_Pages[AppPages.SettingsPage]);
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void FrowardBtn_Click(object sender, RoutedEventArgs e)
        {
            _NavigationService.GoForward();
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            _NavigationService.GoBack();
            ForwardBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            BackBtn.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
        }
    }
}
