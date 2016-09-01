using Xamarin.Forms;
using ZavrsniRad.Views;

namespace ZavrsniRad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartQuizView());
        }

        //protected override void OnStart()
        //{
        //    MainPage = new NavigationPage(new StartQuizView());
        //}

        //protected override void OnSleep()
        //{
        //    MainPage = new NavigationPage(new StartQuizView());
        //}

        //protected override void OnResume()
        //{
        //    MainPage = new NavigationPage(new StartQuizView());
        //}
    }
}

