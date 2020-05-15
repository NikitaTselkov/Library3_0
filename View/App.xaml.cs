using GalaSoft.MvvmLight.Messaging;
using System.Collections;
using System.Linq;
using System.Windows;
using View.Windows;
using ViewModel.Navigation;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            NavigationWindowSetup();           
        }

        void NavigationWindowSetup()
        {
            Messenger.Default.Register<NavigateWindowArgs>(this, (x) =>
            {

                switch (x.Windows)
                {
                    case WindowsEnum.Library:

                        Window mainLibraryWindow = new MainLibraryWindow();
                        mainLibraryWindow.Show();

                        CloseWindows(mainLibraryWindow);
                        
                        break;

                    case WindowsEnum.Exception:

                        Window exceptoinWindow = new ExceptionWindow
                        {
                            Tag = x.Content
                        };
                        exceptoinWindow.ShowDialog();
                        break;

                    case WindowsEnum.SelectUser:

                        Window selectUserWindow = new SelectUserWindow();
                        selectUserWindow.Show();
                        break;
                }
            });
        }

        /// <summary>
        /// Метод закрытия окон.
        /// </summary>
        /// <param name="window"> Не закрываемое окно. </param>
        private void CloseWindows(Window window)
        {
            var enumerator = Windows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Window CurrentWindow = (Window)enumerator.Current;
                if (CurrentWindow != window)
                {
                    CurrentWindow.Close();
                }

            }
        }
    }
}
