using System.Threading.Tasks;

namespace ZavrsniRad.Model.Serialization
{
    public interface IFileBinarySerializer
    {
        Task SaveAsync<T>(string fileName, T data) where T : IBinarySerializable;
        Task<T> LoadAsync<T>(string fileName) where T : IBinarySerializable, new();
        Task<bool> LoadAsync(IBinarySerializable data, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
