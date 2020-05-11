using GalaSoft.MvvmLight.Messaging;
using Model.Navigation;
using System;
using System.Windows;


namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
