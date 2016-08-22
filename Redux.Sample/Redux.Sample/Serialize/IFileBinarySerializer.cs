using System.IO;
using System.Threading.Tasks;

namespace Redux.Sample.Serialize
{
    public interface IFileBinarySerializer
    {
        Task SaveAsync<T>(string fileName, T data) where T : IBinarySerializable;
        Task<T> LoadAsync<T>(string fileName) where T : IBinarySerializable, new();
        Task<bool> LoadAsync(IBinarySerializable data, string fileName);
        Task DeleteFileAsync(string fileName);

        Stream OpenWrite(string fileName);
        Stream OpenRead(string fileName);
    }
}
