using Model.BookFolder;
using Model.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Navigation;


namespace ViewModel
{
    public class BookViewModel : NavigateViewModel
    {

        public RelayCommand SelectListCommand { get; set; } 
        public RelayCommand SelectUserCommand { get; set; } 
        public RelayCommand EditListCommand { get; set; } 
        public RelayCommand AddListCommand { get; set; } 
        public RelayCommand RemoveListCommand { get; set; } 

        /// <summary>
        /// Главный конструктор.
        /// </summary>
        public BookViewModel()
        {
            SelectListCommand = new RelayCommand(SelectListMethod);
            SelectUserCommand = new RelayCommand(GoToSelectUserMethod);
            EditListCommand = new RelayCommand(EditListMethod);
            AddListCommand = new RelayCommand(AddListMethod);
            RemoveListCommand = new RelayCommand(RemoveListMethod);
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

            RaisePropertyChanged("Book");

        }

        /// <summary>
        /// Метод удаления страницы.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void RemoveListMethod(object param)
        {
            var _title = book.CurrentBook.Title;

            Book.RemoveBook(_title);

            RaisePropertyChanged("Book");

            Book = new BookController();
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

                        if (Book.CurrentBook.Definition != null)
                            resultList = Book.CurrentBook.Definition.ToList();

                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Definition = resultList;

                        break;
                    case "Return":

                        if (Book.CurrentBook.Return != null)
                            resultList = Book.CurrentBook.Return.ToList();

                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Return = resultList;

                        break;
                    case "Propertie":

                        if (Book.CurrentBook.Propertie != null)
                            resultList = Book.CurrentBook.Propertie.ToList();

                        resultList.Add(new ListDefinition("", ""));
                        currentBook.Propertie = resultList;

                        break;
                    default:
                            Book.SetNewBookData(currentBook.Title, currentBook.Code, currentBook.Using, currentBook.Template, currentBook.Definition, currentBook.Propertie, currentBook.Return);
                            Book = new BookController(currentBook.Title);
                            Book.CurrentBook.IsChecked = true;
                       
                        break;
                }

            }

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
