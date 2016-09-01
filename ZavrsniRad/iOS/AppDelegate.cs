using Foundation;
using GalaSoft.MvvmLight.Ioc;
using UIKit;
using ZavrsniRad.Model.Serialization;

namespace ZavrsniRad.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            SimpleIoc.Default.Register<IFileBinarySerializer, FileBinarySerializer>();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

