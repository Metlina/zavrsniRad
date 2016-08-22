using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Redux.Sample.Serialize;

namespace Redux.Sample.Redux
{
    public interface IAction {}

    public abstract class BaseStore : ICleanup, IBinarySerializable
    {
        string storeFileName;

        public BaseStore(string storeFileName)
        {
            this.storeFileName = storeFileName;
        }

        public abstract void Serialize(ISerializer serializer);
        public abstract IAction Dispatch(IAction action);

        Task saveTask;
        public Task SaveAsync()
        {
            if (saveTask == null)
            {
                saveTask = SaveImplementation(storeFileName);
                saveTask.ContinueWith(t => 
                {
                    if (t == saveTask)
                        saveTask = null;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                saveTask = saveTask.ContinueWith(async t => 
                {
                    await SaveImplementation(storeFileName);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }

            return saveTask;
        }

        public Task LoadAsync() => LoadImplementation(storeFileName);

        public async Task DeleteStoreAsync()
        {
            var fbs = SimpleIoc.Default.GetInstance<IFileBinarySerializer>();

            try
            {
                Cleanup();
                await fbs.DeleteFileAsync(storeFileName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ex.Log();
            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        protected virtual Task SaveImplementation(string path) => this.SaveToFileAsync(path);
        protected virtual Task LoadImplementation(string path) => this.LoadFromFileAsync(path);

        public abstract void Cleanup();
    }
}

