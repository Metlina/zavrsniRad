using System;
using GalaSoft.MvvmLight.Ioc;

namespace ZavrsniRad.Model
{
    public interface IExceptionHandler
    {
        void Log(Exception ex);
    }

    public static class ExceptionExtensions
    {
        public static void Log(this Exception ex)
        {
            if (SimpleIoc.Default.IsRegistered<IExceptionHandler>())
                SimpleIoc.Default.GetInstance<IExceptionHandler>().Log(ex);
        }
    }
}

