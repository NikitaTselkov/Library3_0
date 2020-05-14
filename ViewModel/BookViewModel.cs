using Model.BookFolder;
using Model.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModel
{
    public class BookViewModel : Navigation.NavigateViewModel
    {

        public RelayCommand SelectListCommand { get; set; } 

        public BookViewModel()
        {
            SelectListCommand = new RelayCommand(SelectListMethod);
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
