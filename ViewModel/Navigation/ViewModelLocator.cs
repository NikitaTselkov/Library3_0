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

        }

        public UserViewModel MainUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UserViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
