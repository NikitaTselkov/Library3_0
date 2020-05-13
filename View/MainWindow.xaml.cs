using GalaSoft.MvvmLight.Messaging;
using ViewModel.Navigation;
using System;
using System.Windows;
using ViewModel;
using Microsoft.Windows.Shell;
using Xceed.Wpf.Toolkit;

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

            NavigationWindowSetup();
        }

        void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                MainFrame.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }

        void NavigationWindowSetup()
        {
            Messenger.Default.Register<NavigateWindowArgs>(this, (x) =>
            {

                switch (x.Data)
                {
                    case Windows.Library:

                        Window mainLibraryWindow = new MainLibraryWindow();
                        mainLibraryWindow.Show();
                        this.Close();
                        break;

                    case Windows.Exception:

                        Window exceptoinWindow = new ExceptionWindow
                        {
                            Tag = x.Content
                        };
                        exceptoinWindow.ShowDialog();
                        break;
                }
            });
        }

    }
}
