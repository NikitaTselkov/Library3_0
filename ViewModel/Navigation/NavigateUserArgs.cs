using Model.UserFolder;
using System;

namespace ViewModel.Navigation
{
    public class NavigateUserArgs : EventArgs
    {
        public NavigateUserArgs()
        {

        }

        public NavigateUserArgs(User currentUser)
        {
            CurrentUser = currentUser;
        }

        public User CurrentUser { get; }


        public override string ToString()
        {
            return $"Url: {CurrentUser.Firstname}.";
        }
    }
}
