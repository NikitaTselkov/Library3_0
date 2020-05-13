using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace ViewModel.Navigation
{
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<UserViewModel>();

            SimpleIoc.Default.Register<BookViewModel>();

        }

        public UserViewModel MainUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }

        public BookViewModel MainBook
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BookViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
