using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;

namespace Redux.Sample.Serialize
{
    public static class BinarySerializableExtensions
    {
        public static async Task<bool> SaveToFileAsync(this IBinarySerializable data, string fileName)
        {
            try
            {
                using (new DebugStopwatch($"Saving {data.GetType().Name} to {fileName}"))
                {
                    var fileSerializer = SimpleIoc.Default.GetInstance<IFileBinarySerializer>();
                    await fileSerializer.SaveAsync(fileName, data);
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.Log();
                return false;
            }
        }

        public static async Task<bool> LoadFromFileAsync(this IBinarySerializable data, string fileName)
        {
            try
            {
                using (new DebugStopwatch($"Loading {data.GetType().Name} from {fileName}"))
                {
                    var serializer = SimpleIoc.Default.GetInstance<IFileBinarySerializer>();
                    await serializer.LoadAsync(data, fileName);
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.Log();
                return false;
            }
        }

        public static async Task<T> LoadFromFileAsync<T>(string fileName)
            where T : class, IBinarySerializable, new()
        {
            try
            {
                using (new DebugStopwatch($"Loading {typeof(T).Name} from {fileName}"))
                {
                    var serializer = SimpleIoc.Default.GetInstance<IFileBinarySerializer>();
                    return await serializer.LoadAsync<T>(fileName) ?? new T();
                }
            }
            catch (Exception ex)
            {
                ex.Log();
                return new T();
            }
        }
    }
}
