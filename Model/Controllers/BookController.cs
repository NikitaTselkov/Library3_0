using Model.BookFolder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Controllers
{
    public class BookController : ControllerBase
    {

        /// <summary>
        /// Список Книг.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Текущая книга.
        /// </summary>
        public Book CurrentBook { get; set; }

        /// <summary>
        /// Явлектся ли книга новой.
        /// </summary>
        public bool IsNewBook { get; set; }

        /// <summary>
        /// Адрес Book.
        /// </summary>
        private const string BOOK_PATH = "bookSave.json";

        /// <summary>
        /// Создание нового контроллера книги.
        /// </summary>
        /// <param name="_title"> Заголовок. </param>
        public BookController(string _title)
        {
            if (string.IsNullOrWhiteSpace(_title))
            {
                throw new ArgumentNullException("_title не может быть null", nameof(_title));
            }

            Books = GetListItemData<Book>(BOOK_PATH);

            CurrentBook = Books.SingleOrDefault(b => b.Title == _title);

            if (CurrentBook == null)
            {
                CurrentBook = new Book(_title);

                IsNewBook = SaveItems(Books, BOOK_PATH, CurrentBook);
            }
            
        }

        /// <summary>
        /// Метод удаления страниц.
        /// </summary>
        /// <param name="_title"> Заголовок. </param>
        public void RemoveBook(string _title)
        {
            if (string.IsNullOrWhiteSpace(_title))
            {
                throw new ArgumentNullException("_title не может быть null", nameof(_title));
            }

            Books = GetListItemData<Book>(BOOK_PATH);

            Books.Remove(Books.SingleOrDefault(b => b.Title == _title));

            ISave.Save(BOOK_PATH, Books);
        }

        /// <summary>
        /// Задает книге не достающии данные.
        /// </summary>
        /// <param name="_title"> Заголовок. </param>
        /// <param name="_code"> Код. </param>
        /// <param name="_using"> Библиотеки. </param>
        /// <param name="_template"> Шаблон записи. </param>
        /// <param name="_definition"> Определение. </param>
        /// <param name="_propertie"> Свойства. </param>
        /// <param name="_return"> Возвращаемый тип. </param>
        public void SetNewBookData(string _title, string _code, string _using, string _template,
            IEnumerable<ListDefinition> _definition,
            IEnumerable<ListDefinition> _propertie,
            IEnumerable<ListDefinition> _return)
        {
            #region Проверка Условий

            if (string.IsNullOrWhiteSpace(_title))
            {
                throw new ArgumentNullException("_title не может быть null", nameof(_title));
            }
            if (string.IsNullOrWhiteSpace(_code))
            {
                throw new ArgumentNullException("_code не может быть null", nameof(_code));
            }
            if (string.IsNullOrWhiteSpace(_using))
            {
                throw new ArgumentNullException("_using не может быть null", nameof(_using));
            }
            if (string.IsNullOrWhiteSpace(_template))
            {
                throw new ArgumentNullException("_template не может быть null", nameof(_template));
            }

            #endregion

            CurrentBook.Title = _title;
            CurrentBook.Code = _code;
            CurrentBook.Using = _using;
            CurrentBook.Template = _template;
            CurrentBook.Definition = _definition;
            CurrentBook.Propertie = _propertie;
            CurrentBook.Return = _return;
            IsNewBook = false;
            ISave.Save(BOOK_PATH, Books);

        }


        /// <summary>
        /// Конструктор получающий коллекцию книг.
        /// </summary>
        public BookController()
        {
            Books = GetListItemData<Book>(BOOK_PATH);
        }

    }
}
