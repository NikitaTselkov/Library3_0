using Model.BookFolder;
using Model.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using ViewModel.Navigation;


namespace ViewModel
{
    public class BookViewModel : NavigateViewModel
    {

        public RelayCommand SelectListCommand { get; set; } 
        public RelayCommand SelectUserCommand { get; set; } 
        public RelayCommand EditListCommand { get; set; } 
        public RelayCommand AddListCommand { get; set; } 

        /// <summary>
        /// Главный конструктор.
        /// </summary>
        public BookViewModel()
        {
            SelectListCommand = new RelayCommand(SelectListMethod);
            SelectUserCommand = new RelayCommand(GoToSelectUserMethod);
            EditListCommand = new RelayCommand(EditListMethod);
            AddListCommand = new RelayCommand(AddListMethod);
        }

        /// <summary>
        /// Метод отправляющий в окно выбора пользователя.
        /// </summary>
        /// <param name="param"> Параметр. </param>
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
        /// Метод редактирования списка.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void EditListMethod(object param)
        {
            NavigateWindow(WindowsEnum.EditList);
        }

        /// <summary>
        /// Метод сохранения изменений.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void AddListMethod(object param)
        {
            var currentBook = Book.CurrentBook;

            if (currentBook != null)
            {
                var resultList = new List<ListDefinition>();

                switch (param)
                {
                    case "Definition":

                        resultList = Book.CurrentBook.Definition.ToList();
                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Definition = resultList;

                        break;
                    case "Return":

                        resultList = Book.CurrentBook.Return.ToList();
                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Return = resultList;

                        break;
                    case "Propertie":

                        resultList = Book.CurrentBook.Propertie.ToList();
                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Propertie = resultList;

                        break;
                    default:
                        break;
                }

            }

            Book.SetNewBookData(currentBook.Code, currentBook.Using, currentBook.Template, currentBook.Definition, currentBook.Propertie, currentBook.Return);

            RaisePropertyChanged("Book");
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
                RaisePropertyChanged("Book");
            }
        }

        
    }
}
