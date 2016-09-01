using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using ZavrsniRad.Model.Serialization;

namespace ZavrsniRad.Model.Data
{
    public abstract class BaseStore : ICleanup, IBinarySerializable
    {
        readonly string _storeFileName;

        public BaseStore(string storeFileName)
        {
            this._storeFileName = storeFileName;
        }

        public abstract void Serialize(ISerializer serializer);

        #region File operations

        Task _saveTask;
        public Task SaveAsync(bool forceSave = false)
        {
            if (_saveTask == null)
            {
                _saveTask = this.SaveToFileAsync(_storeFileName);
                _saveTask.ContinueWith(t =>
                {
                    _saveTask = null;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (forceSave)
            {
                _saveTask = _saveTask.ContinueWith(async t =>
                {
                    await this.SaveToFileAsync(_storeFileName);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }

            return _saveTask;
        }

        public Task LoadAsync() => this.LoadFromFileAsync(_storeFileName);

        public async Task DeleteStoreAsync()
        {
            var fbs = SimpleIoc.Default.GetInstance<IFileBinarySerializer>();

            try
            {
                Cleanup();
                await fbs.DeleteFileAsync(_storeFileName);
            }
            catch (System.IO.FileNotFoundException)
            {
            }
            catch (System.Exception ex)
            {
                ex.Log();
            }
        }

        #endregion

        #region ICleanup implementation
        /// <summary>
        /// Rebuild internal store and remove/reconnect all message and event handlers
        /// </summary>
        public abstract void Cleanup();
        #endregion
    }
}

