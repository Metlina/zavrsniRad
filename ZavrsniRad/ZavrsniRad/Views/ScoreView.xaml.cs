using System;
using Xamarin.Forms;
using ZavrsniRad.ViewModels;

namespace ZavrsniRad.Views
{
    public partial class ScoreView : ContentPage
    {
        public ScoreView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        void StartAgain_OnBtnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new StartQuizView());
        }

        void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}

