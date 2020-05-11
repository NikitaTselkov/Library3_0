using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;


namespace Model.Navigation
{
    public class NavigateViewModel : ViewModelBase
    {
        public NavigateViewModel()
        {

        }

        public string Title { get; set; }
        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }

    }
}
