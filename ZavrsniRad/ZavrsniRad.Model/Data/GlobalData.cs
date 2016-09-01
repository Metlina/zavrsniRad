using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ZavrsniRad.Model.Data
{
    public class GlobalData
    {
        [NotNull]
        public QuestionData QuestionData { get; }

        public GlobalData()
        {
            QuestionData = new QuestionData();
        }

        #region Saving

        public Task SaveAllAsync()
        {
            return Task.WhenAll(
                QuestionData.SaveAsync());
        }

        #endregion

        #region Loading

        private Task _loadAsyncTask;

        public Task LoadAllAsync()
        {
            return _loadAsyncTask ?? (_loadAsyncTask = LoadImplementationAsync());
        }

        private async Task LoadImplementationAsync()
        {
            try
            {
                await Task.WhenAll(
                    QuestionData.LoadAsync());
            }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }
        }

        #endregion

        #region Clearing data

        public async Task ClearDataAsync()
        {
            await QuestionData.DeleteStoreAsync();

            await SaveAllAsync();
        }

        #endregion
    }
}

