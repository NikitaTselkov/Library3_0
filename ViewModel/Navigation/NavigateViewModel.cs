using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.Navigation
{
    public class NavigateViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public NavigateViewModel()
        {

        }

        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }

        public void NavigateWindow(WindowsEnum Title)
        {
            Messenger.Default.Send<NavigateWindowArgs>(new NavigateWindowArgs(Title));
        }

        public void NavigateWindow(WindowsEnum Title, string content)
        {
            Messenger.Default.Send<NavigateWindowArgs>(new NavigateWindowArgs(Title, content));
        }


        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged.
        /// </summary>
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
