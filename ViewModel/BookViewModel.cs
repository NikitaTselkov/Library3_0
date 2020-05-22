using GalaSoft.MvvmLight.Messaging;
using Model.BookFolder;
using Model.Controllers;
using Model.UserFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModel.Navigation;


namespace ViewModel
{
    public class BookViewModel : NavigateViewModel
    {
        /// <summary>
        /// Visibility кнопок редактирования.
        /// </summary>
        public Visibility IsAdmin { get; set; }


        public RelayCommand SelectListCommand { get; set; } 
        public RelayCommand SelectUserCommand { get; set; } 
        public RelayCommand EditListCommand { get; set; } 
        public RelayCommand AddListCommand { get; set; } 
        public RelayCommand RemoveListCommand { get; set; } 
        public RelayCommand DeletListCommand { get; set; } 
        public RelayCommand SelectGroupCommand { get; set; }

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
            DeletListCommand = new RelayCommand(DeletListMethod);
            SelectGroupCommand = new RelayCommand(SelectGroupMethod);

            NavigationSetup();
        }

        private void NavigationSetup()
        {
            Messenger.Default.Register<NavigateUserArgs>(this, (x) =>
            {
                CheckAccess(x.CurrentUser);
            });
        }

        /// <summary>
        /// Метод проверки уровня доступа.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void CheckAccess(User currentUser)
        {
            if (currentUser != null)
            {
                if (currentUser.Access == Access.User)
                {
                    IsAdmin = Visibility.Collapsed;
                }
                if (currentUser.Access == Access.Admin)
                {
                    IsAdmin = Visibility.Visible;
                }

                RaisePropertyChanged("IsAdmin");
            }
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
        /// Метод выбора группы.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void SelectGroupMethod(object param)
        {
            param = Convert.ToInt32(param);

            if (Book.CurrentBook != null)
            {

                Book.CurrentBook.Group = (ListGroups)param;

                RaisePropertyChanged("Book");
            }
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
            try
            {
                if (book.CurrentBook == null)
                {
                    throw new ArgumentNullException(nameof(book.CurrentBook));
                }

                var _title = book.CurrentBook.Title;

                Book.RemoveBook(_title);

                RaisePropertyChanged("Book");

                Book = new BookController();
            }
            catch 
            {
                NavigateWindow(WindowsEnum.Exception, "Нельзя удалить ничего!");
            }
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
        /// Метод удаления блоков.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void DeletListMethod(object param)
        {
            CheckListMethod(param, false, false, 0);
        }

        /// <summary>
        /// Метод сохранения изменений.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        public void AddListMethod(object param)
        {
            bool IsRepeat = false;
            var CountRepeat = 0;
            bool IsWork = true;

            foreach (var List in Book.Books)
            {
                string title = List.Title;

                if (title == Book.CurrentBook.Title)
                {
                    CountRepeat++;
                    if (CountRepeat > 1)
                    {
                        var repeat2 = 0;
                        while (IsWork)
                        {
                            if (Book.Books.FirstOrDefault(f => f.Title == title) != null) 
                            {
                                
                                if (repeat2 > 0)
                                {
                                   title = title.Remove(title.Length - 1);

                                    if (repeat2 > 8)
                                    {
                                        title = title.Remove(title.Length - 1);
                                    }
                                }
                                repeat2++;

                                title += CountRepeat;
                                CountRepeat ++;
                            }
                            else
                            {
                                IsRepeat = true;
                                IsWork = false;
                            }

                        }
                    }
                }
            }

             CheckListMethod(param, true, IsRepeat, CountRepeat);

        }

        /// <summary>
        /// Удаление и добавление блока.
        /// </summary>
        /// <param name="param"> Параметр. </param>
        /// <param name="IsAdd"> Флаг добавления. </param>
        private void CheckListMethod(object param, bool IsAdd, bool isRepeat, int countRepeat)
        {
            var currentBook = Book.CurrentBook;

            #region Проверка Условий

            try
            {
                if (currentBook != null)
                {

                    if (string.IsNullOrWhiteSpace(currentBook.Title))
                    {
                        throw new ArgumentNullException("Title не может быть null", nameof(currentBook.Title));
                    }
                    if (string.IsNullOrWhiteSpace(currentBook.Code))
                    {
                        throw new ArgumentNullException("Code не может быть null", nameof(currentBook.Code));
                    }
                    if (string.IsNullOrWhiteSpace(currentBook.Using))
                    {
                        throw new ArgumentNullException("Using не может быть null", nameof(currentBook.Using));
                    }
                    if (string.IsNullOrWhiteSpace(currentBook.Template))
                    {
                        throw new ArgumentNullException("Template не может быть null", nameof(currentBook.Template));
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                NavigateWindow(WindowsEnum.Exception, ex.ParamName);

                Book = new BookController("NewTitle");

                Book.CurrentBook.IsChecked = true;

                RaisePropertyChanged("Book");

                currentBook = null;

            }

            #endregion

            if (currentBook != null)
            {
                var resultList = new List<ListDefinition>();

                switch (param)
                {
                    case "Definition":

                        if (Book.CurrentBook.Definition != null)
                            resultList = Book.CurrentBook.Definition.ToList();

                        if(IsAdd == true)
                            resultList.Add(new ListDefinition("", ""));

                        else if(resultList.Count > 0)
                            resultList.Remove(resultList.Last());

                        currentBook.Definition = resultList;

                        break;
                    case "Return":

                        if (Book.CurrentBook.Return != null)
                            resultList = Book.CurrentBook.Return.ToList();

                        if (IsAdd == true)
                            resultList.Add(new ListDefinition("", ""));

                        else if (resultList.Count > 0)
                            resultList.Remove(resultList.Last());

                        currentBook.Return = resultList;

                        break;
                    case "Propertie":

                        if (Book.CurrentBook.Propertie != null)
                            resultList = Book.CurrentBook.Propertie.ToList();

                        if (IsAdd == true)
                            resultList.Add(new ListDefinition("", ""));

                        else if (resultList.Count > 0)
                            resultList.Remove(resultList.Last());

                        currentBook.Propertie = resultList;

                        break;
                    default:

                        if (isRepeat == true)
                        {
                            currentBook.Title += countRepeat - 1;
                        }

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
