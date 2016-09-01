using Android.App;
using Android.Content.PM;
using Android.OS;
using GalaSoft.MvvmLight.Ioc;
using ZavrsniRad.Model.Serialization;

namespace ZavrsniRad.Droid
{
    [Activity(Label = "ZavrsniRad.Droid",
              Icon = "@drawable/icon", 
              Theme = "@style/MyTheme", 
              MainLauncher = true, 
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SimpleIoc.Default.Register<IFileBinarySerializer, FileBinarySerializer>();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

