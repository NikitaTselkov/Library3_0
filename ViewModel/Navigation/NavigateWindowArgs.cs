namespace ViewModel.Navigation
{
    public class NavigateWindowArgs
    {
        public NavigateWindowArgs()
        {

        }

        public NavigateWindowArgs(Windows windows)
        {
            Data = windows;
        }

        public NavigateWindowArgs(Windows windows, string content)
        {
            Data = windows;
            Content = content;
        }

        public Windows Data { get; set; }

        public string Content { get; set; }

    }
}
