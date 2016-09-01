using System;
using System.IO;
using System.Threading.Tasks;
using ZavrsniRad.Model.Serialization;
using ZavrsniRad.Model;

namespace ZavrsniRad.iOS
{
    public class FileBinarySerializer : IFileBinarySerializer
    {
        public Task SaveAsync<T>(string fileName, T data) where T : IBinarySerializable
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);

            using (var stream = File.OpenWrite(filePath))
            using (var writer = new BinaryWriter(stream))
            {
                data.Serialize(new WriteSerializer
                {
                    Writer = writer
                });
            }
            return Task.FromResult(true);
        }

        public Task<T> LoadAsync<T>(string fileName) where T : IBinarySerializable, new()
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);

            try
            {
                using (var stream = File.OpenRead(filePath))
                using (var reader = new BinaryReader(stream))
                {
                    var t = Activator.CreateInstance<T>();
                    t.Serialize(new ReadSerializer
                    {
                        Reader = reader
                    });
                    return Task.FromResult(t);
                }
            }
            catch (FileNotFoundException) { }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }

            return Task.FromResult(default(T));
        }

        public Task DeleteFileAsync(string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);

            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }
            return Task.FromResult(true);
        }

        public Task<bool> LoadAsync(IBinarySerializable data, string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);

            try
            {
                using (var stream = File.OpenRead(filePath))
                using (var reader = new BinaryReader(stream))
                {
                    data.Serialize(new ReadSerializer
                    {
                        Reader = reader
                    });
                    return Task.FromResult(true);
                }
            }
            catch (FileNotFoundException) { }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }

            return Task.FromResult(false);
        }

        public Stream OpenWrite(string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);
            return File.OpenWrite(filePath);
        }

        public Stream OpenRead(string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentPath, fileName);
            return File.OpenRead(filePath);
        }
    }
}

