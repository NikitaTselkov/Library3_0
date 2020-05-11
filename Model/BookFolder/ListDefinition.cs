using System;
using System.Runtime.Serialization;

namespace Model.BookFolder
{
    [DataContract]
    public class ListDefinition
    {
        /// <summary>
        /// Заголовок.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Определение.
        /// </summary>
        [DataMember]
        public string Definition { get; set; }

        /// <summary>
        /// Создание нового контроллера Списка.
        /// </summary>
        /// <param name="title"> Заголовок. </param>
        /// <param name="definition"> Определение. </param>
        public ListDefinition(string title, string definition)
        {
            #region Проверка Условий

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title не может быть null", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(definition))
            {
                throw new ArgumentNullException("definition не может быть null", nameof(definition));
            }

            #endregion

            Title = title;

            Definition = definition;

        }

        public override string ToString()
        {
            return string.Format("Title: {0}, Definition: {1}", Title, Definition);
        }

    }
}
