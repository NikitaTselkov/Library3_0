using System;

namespace ViewModel.Navigation
{
    public class NavigateWindowArgs : EventArgs
    {
        public NavigateWindowArgs()
        {

        }

        public NavigateWindowArgs(WindowsEnum windows)
        {
            Windows = windows;
        }

        public NavigateWindowArgs(WindowsEnum windows, string content)
        {
            Windows = windows;
            Content = content;
        }

        public WindowsEnum Windows { get; }

        public string Content { get; }


        public override string ToString()
        {
            return $"Window: {Windows}, Content: {Content}.";
        }
    }
}
