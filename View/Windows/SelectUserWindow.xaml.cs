using GalaSoft.MvvmLight.Messaging;
using ViewModel.Navigation;
using System;
using System.Windows;

namespace View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SelectUserWindow : Window
    {
        public SelectUserWindow()
        {
            InitializeComponent();

            NavigationSetup();
        }

        void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                MainFrame.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }

    }
}
