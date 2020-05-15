using Model.Controllers;
using System;
using ViewModel.Navigation;

namespace ViewModel
{
    public class BookViewModel : NavigateViewModel
    {

        public RelayCommand SelectListCommand { get; set; } 
        public RelayCommand SelectUserCommand { get; set; } 

        public BookViewModel()
        {
            SelectListCommand = new RelayCommand(SelectListMethod);
            SelectUserCommand = new RelayCommand(GoToSelectUserMethod);
        }

        /// <summary>
        /// Метод отправляющий в окно выбора пользователя.
        /// </summary>
        /// <param name="param"></param>
        public void GoToSelectUserMethod(object param)
        {
            NavigateWindow(WindowsEnum.SelectUser);
        }

        /// <summary>
        /// Метод выбора страницы.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void SelectListMethod(object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException("param не может быть null", nameof(param));
            }

            Book = new BookController(param.ToString());

            Book.CurrentBook.IsChecked = true;

        }


        /// <summary>
        /// Создание экзeмпляра книги.
        /// </summary>
        private BookController book = new BookController();
        public BookController Book
        {
            get { return book; }
            set
            {
                book = value;
                OnPropertyChanged("Book");
            }
        }

        
    }
}
