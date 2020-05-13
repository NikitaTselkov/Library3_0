using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;


namespace ViewModel.Navigation
{
    public class NavigateViewModel : ViewModelBase
    {
        public NavigateViewModel()
        {

        }

        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }

        public void NavigateWindow(Windows Title)
        {
            Messenger.Default.Send<NavigateWindowArgs>(new NavigateWindowArgs(Title));
        }

        public void NavigateWindow(Windows Title, string content)
        {
            Messenger.Default.Send<NavigateWindowArgs>(new NavigateWindowArgs(Title, content));
        }

    }
}
