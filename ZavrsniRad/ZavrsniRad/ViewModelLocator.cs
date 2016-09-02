using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

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
        }
    }
}