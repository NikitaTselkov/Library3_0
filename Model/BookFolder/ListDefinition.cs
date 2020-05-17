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

            Title = title;

            Definition = definition;

        }

        public override string ToString()
        {
            return string.Format("Title: {0}, Definition: {1}", Title, Definition);
        }

    }
}
