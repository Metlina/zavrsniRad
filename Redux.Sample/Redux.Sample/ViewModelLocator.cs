using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Redux.Sample.Redux;
using Xamarin.Forms;

namespace Redux.Sample
{
    public class AlertExceptionHandler : IExceptionHandler
    {
        void IExceptionHandler.Log(Exception ex)
        {
            Device.BeginInvokeOnMainThread(async () => 
            {
                await Application.Current.MainPage.DisplayAlert("Exceptiom", ex.Message, "ok");
            });
        }
    }

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Initialize();
        }

        //register view models to simple ioc
        static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //register midleware
            SimpleIoc.Default.Register(() => CreateGlobalData(Middleware));

            #if DEBUG
            SimpleIoc.Default.Register<IExceptionHandler, AlertExceptionHandler>();
            #endif
        }

        #region middlewares

        static Func<Dispatcher, Dispatcher> Middleware(GlobalData state)
        {
            return next => (action) => 
            {
                var result = next(action);
                return action;
            };
        }

        #endregion

        //create store
        static GlobalData CreateGlobalData(params Middleware[] middlewares)
        {
            var store = new GlobalData();

            var dispatch = store.Dispatch;

            var chain = middlewares.Select(m => m(store)).ToList();

            var newDispatch = Compose(chain)(dispatch);

            store.ReplaceDispatch(newDispatch);
            return store;
        }

        public static Func<U, U> Compose<U>(List<Func<U, U>> funcs)
        {
            if (funcs == null || funcs.Count == 0)
                return dispatch => dispatch;

            if (funcs.Count == 1)
                return d => funcs[0](d);

            return d =>
            {
                var action = funcs[funcs.Count - 1](d);
                return funcs.Take(funcs.Count - 1).Aggregate(action, (arg1, arg2) => arg2(arg1));
            };
        }
    }
}

