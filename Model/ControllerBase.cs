using Model.Interfaces;
using System.Collections.Generic;


namespace Model
{
    public abstract class ControllerBase : ILoad, ISave
    {

        /// <summary>
        /// Сохраняет список элементов.
        /// </summary>
        /// <typeparam name="T"> Тип данных. </typeparam>
        /// <param name="listItems"> Список элементов. </param>
        /// <param name="path"> Путь. </param>
        /// <param name="currentItem"> Текущий элемент. </param>
        /// <returns> Результат сохранения. </returns>
        public bool SaveItems<T>(List<T> listItems, string path, T currentItem)
        {
            listItems.Add(currentItem);
            ISave.Save(path, listItems);

            return true;
        }


        /// <summary>
        /// Получает Список элементов.
        /// </summary>
        /// <typeparam name="T"> Тип элементов. </typeparam>
        /// <param name="path"> Путь. </param>
        /// <returns> Список элементов. </returns>
        public List<T> GetListItemData<T>(string path)
        {
            var listItems = ILoad.GetData<List<T>>(path);

            listItems ??= new List<T>();

            return listItems;
        }


    }
}
