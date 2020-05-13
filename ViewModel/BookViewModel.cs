using Model.BookFolder;
using Model.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ViewModel
{
    public class BookViewModel : Navigation.NavigateViewModel, INotifyPropertyChanged
    {

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



        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged.
        /// </summary>
#pragma warning disable CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Член скрывает унаследованный член: отсутствует новое ключевое слово
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
