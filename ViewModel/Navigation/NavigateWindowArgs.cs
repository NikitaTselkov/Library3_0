namespace ViewModel.Navigation
{
    public class NavigateWindowArgs
    {
        public NavigateWindowArgs()
        {

        }

        public NavigateWindowArgs(WindowsEnum windows)
        {
            Data = windows;
        }

        public NavigateWindowArgs(WindowsEnum windows, string content)
        {
            Data = windows;
            Content = content;
        }

        public WindowsEnum Data { get; set; }

        public string Content { get; set; }

    }
}
