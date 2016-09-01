using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ZavrsniRad.Model.Data;

namespace ZavrsniRad
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            Initialize();
        }

        static void Initialize()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<GlobalData>();
        }
    }
}