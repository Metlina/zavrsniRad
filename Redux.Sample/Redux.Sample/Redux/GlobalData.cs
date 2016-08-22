using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Redux.Sample.Redux
{
    public class GlobalDataLoadedMessage : MessageBase
    {
        public GlobalData GlobalData { get; }

        public GlobalDataLoadedMessage(GlobalData globalData)
        {
            this.GlobalData = globalData;
        }
    }

    public delegate IAction Dispatcher(IAction action);
    public delegate void Subscriber(GlobalData state);

    public delegate Dispatcher MiddlewareApplier(Dispatcher dispatch);
    public delegate Func<Dispatcher, Dispatcher> Middleware(GlobalData store);

    public interface IComponent<T>
    {
        void SetState(T state);
    }

    public class GlobalData
    {
        public GlobalData()
        {
            Dispatch = DoDispatch;
        }

        #region Redux implementation

        public Dispatcher Dispatch { get; private set; }
        public event Subscriber Subscribe;

        bool isDaspatching;

        public void ReplaceDispatch(Dispatcher dispatch) => Dispatch = Dispatch;

        IAction DoDispatch(IAction action)
        {
            if (isDaspatching)
                throw new InvalidOperationException("Cannot dispatch while dispatching");

            try
            {
                isDaspatching = true;
                //data classes go here
                //AppUserData.Dispatch(action)
            }
            finally
            {
                isDaspatching = false;
            }

            Subscribe?.Invoke(this);

            return action;
        }

        public Action Connect<T>(Func<GlobalData, T> projector, Action<T> action)
        {
            var lastState = projector(this);
            Subscriber subscription = null;
            subscription = (state) => 
            {
                var newState = projector(state);
                if (EqualityComparer<T>.Default.Equals(lastState, default(T))) || !lastState.Equals(newState))
                {
                    lastState = newState;
                    action(newState);
                }
            };

            return () => 
            {
                if (subscription != null)
                    Subscribe -= subscription;
                subscription = null;
            };
        }

        public Func<IComponent<T>, IComponent<T>> Connect<T>(Func<GlobalData, T> projector)
        {
            return (component) => 
            {
                var lastState = projector(this);
                this.Subscribe += (state) => 
                {
                    var newState = projector(state);
                    if (EqualityComparer<T>.Default.Equals(lastState, default(T))) || !lastState.Equals(newState))
                    {
                        lastState = newState;
                        component.SetState(newState);
                    }
                };

                return component;
            };
        }

        #endregion

        #region Saving

        Task SaveAllAsync()
        {
            return Task.WhenAll(
                //AppUserData.SaveAsync();
                );
        }

        #endregion

        #region loading

        Task _loadAsyncTask;

        public Task LoadAllAsync()
        {
            return _loadAsyncTask ?? (_loadAsyncTask = LoadImplementationAsync());
        }

        async Task LoadImplementationAsync()
        {
            try
            {
                await Task.WhenAll(
                    //AppUserData.LoadAsync();
                    );

                Messenger.Default.Send(new GlobalDataLoadedMessage(this));

                Subscribe?.Invoke(this);

            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }

        #endregion

        #region Clearing

        async Task ClearDataAsync()
        {
            //await AppUserData.DeleteStoreAsync();

            await SaveAllAsync();
        }

        #endregion
    }
}

