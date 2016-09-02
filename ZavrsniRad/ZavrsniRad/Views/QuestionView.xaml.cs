using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using ZavrsniRad.ViewModels;

namespace ZavrsniRad.Views
{
    public partial class QuestionView : ContentPage
    {
        public QuestionView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Messenger.Default.Register<AnswerMessage>(this, _ => 
            {
                FirstStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
                SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
                ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
            });

            Messenger.Default.Register<TappedMessage>(this, _ => 
            {
                switch(_.Number)
                {
                    case 1:
                        FirstStackLayout.BackgroundColor = (Color)Application.Current.Resources["SelectedAnswerColor"];
                        break;
                    case 2:
                        SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["SelectedAnswerColor"];
                        break;
                    case 3:
                        ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["SelectedAnswerColor"];
                        break;
                }
            });

            Messenger.Default.Register<AlreadySelectedMessage>(this, _ => 
            {
                switch(_.Number)
                {
                    case 1:
                        FirstStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
                        break;
                    case 2:
                        SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
                        break;
                    case 3:
                        ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
                        break;
                }
            });
        }
    }
}

