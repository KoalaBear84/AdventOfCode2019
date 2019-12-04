using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    public static class CloneExtensions
    {
        /// <summary>
        /// Makes a copy from the object.
        /// Doesn't copy the reference memory, only data.
        /// https://www.extensionmethod.net/csharp/object/clone-t
        /// </summary>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <param name="item">Object to be copied.</param>
        /// <returns>Returns the copied object.</returns>
        public static T Clone<T>(this object item)
        {
            if (item != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, item);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    T result = (T)binaryFormatter.Deserialize(memoryStream);

                    memoryStream.Close();

                    return result;
                }
            }
            else
            {
                return default;
            }
        }
    }
}
