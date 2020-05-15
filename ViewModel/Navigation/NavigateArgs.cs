using System;

namespace ViewModel.Navigation
{
    public class NavigateArgs : EventArgs
    {
        public NavigateArgs()
        {

        }

        public NavigateArgs(string url)
        {
            Url = url;
        }

        public string Url { get; }


        public override string ToString()
        {
            return $"Url: {Url}.";
        }
    }
}
