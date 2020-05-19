using System.IO;
using System.Runtime.Serialization.Json;

namespace Model
{
    public interface ISave
    {
        static void Save<T>(string path, T result)
        {
            var formatter = new DataContractJsonSerializer(typeof(T));

            using (var fs = new FileStream(path, FileMode.Create))
            {
                formatter.WriteObject(fs, result);
            }
        }

    }
}
