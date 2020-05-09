using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Model.Interfaces
{
    public interface ILoad
    {
        static T GetUsers<T>(string path)
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
