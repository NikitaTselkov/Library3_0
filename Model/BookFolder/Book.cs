using Model.BookFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Book
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Библиотеки.
        /// </summary>
        public string Using { get; set; }

        /// <summary>
        /// Шаблон записи.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Определение.
        /// </summary>
        public IEnumerable<ListDefinition> Definition { get; set; }

        /// <summary>
        /// Свойства.
        /// </summary>
        public IEnumerable<ListDefinition> Propertie { get; set; }

        /// <summary>
        /// Вернуть.
        /// </summary>
        public IEnumerable<ListDefinition> Return { get; set; }

        /// <summary>
        /// Создание нового конструктора практической части book.
        /// </summary>
        /// <param name="_title"> Заголовок. </param>
        /// <param name="_code"> Код. </param>
        /// <param name="_using"> Библиотеки. </param>
        /// <param name="_template"> Шаблон записи. </param>
        public Book(string _title, string _code, string _using, string _template)
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

            Title = _title;
            Code = _code;
            Using = _using;
            Template = _template;

        }

        /// <summary>
        /// Создание нового конструктора теоретической части book.
        /// </summary>
        /// <param name="_definition"> Определения. </param>
        /// <param name="_propertie"> Свойства. </param>
        /// <param name="_return"> Возврвщаемый Тип. </param>
        public Book(IEnumerable<ListDefinition> _definition,
                    IEnumerable<ListDefinition> _propertie,
                    IEnumerable<ListDefinition> _return)
        {
            #region Проверка Условий

            if (_definition == null)
            {
                throw new ArgumentNullException("_definition не может быть null", nameof(_definition));
            }
            if (_propertie == null)
            {
                throw new ArgumentNullException("_propertie не может быть null", nameof(_propertie));
            }
            if (_return == null)
            {
                throw new ArgumentNullException("_return не может быть null", nameof(_return));
            }

            #endregion

            Definition = _definition;
            Propertie = _propertie;
            Return = _return;
        }


        public override string ToString()
        {
            return string.Format("Title: {0}, Code: {1}, Using: {2}, Template: {3}", Title, Code, Using, Template);
        }

    }
}
