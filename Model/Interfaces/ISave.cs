using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Model
{
    public interface ISave
    {
        static void Save<T>(string path, T result)
        {
            var formatter = new DataContractJsonSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, result);
            }
        }

    }
}
