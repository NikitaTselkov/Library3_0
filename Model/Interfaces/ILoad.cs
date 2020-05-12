using System.IO;
using System.Runtime.Serialization.Json;

namespace Model.Interfaces
{
    public interface ILoad
    {
        static T GetData<T>(string path)
        {
            var formatter = new DataContractJsonSerializer(typeof(T));


            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    if (formatter.ReadObject(fs) is T users)
                    {
                        return users;
                    }
                    else
                    {
                        return default;
                    }
                }
                return default;
            }

        }

    }
}
