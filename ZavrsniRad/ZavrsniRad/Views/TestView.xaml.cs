using Xamarin.Forms;
using ZavrsniRad.ViewModels;

namespace ZavrsniRad
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();

            BindingContext = new TestViewModel();

            if (Device.OS == TargetPlatform.iOS)
            {
                SaveFilesToDiskIOS();
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                SaveFilesToDiskAndroid();
            }
            else if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
            {
                SaveFilesToDiskWindows();
            }
        }

        void SaveFilesToDiskIOS()
        {
            
        }

        void SaveFilesToDiskAndroid()
        {

        }

        void SaveFilesToDiskWindows()
        {

        }
    }
}

