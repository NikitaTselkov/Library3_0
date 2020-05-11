using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class AbstractController : ILoad, ISave
    {

        public bool SaveItems<T>(List<T> listItems, string path, T currentItem)
        {
            listItems.Add(currentItem);
            ISave.Save(path, listItems);

            return true;
        }

        public List<T> GetListItemData<T>(string path)
        {
            var listItems = ILoad.GetData<List<T>>(path);

            listItems ??= new List<T>();

            return listItems;
        }


    }
}
