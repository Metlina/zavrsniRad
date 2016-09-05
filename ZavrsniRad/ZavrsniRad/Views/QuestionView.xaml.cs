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
                        ClearSelectedFirst();
                        break;
                    case 2:
                        SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["SelectedAnswerColor"];
                        ClearSelectedSecond();
                        break;
                    case 3:
                        ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["SelectedAnswerColor"];
                        ClearSelectedThird();
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

        void ClearSelectedFirst()
        {
            if (SecondStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
            if (ThirdStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
        }

        void ClearSelectedSecond()
        {
            if (FirstStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                FirstStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
            if (ThirdStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                ThirdStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
        }

        void ClearSelectedThird()
        {
            if (SecondStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                SecondStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
            if (FirstStackLayout.BackgroundColor == (Color)Application.Current.Resources["SelectedAnswerColor"])
                FirstStackLayout.BackgroundColor = (Color)Application.Current.Resources["QuestionLabelColor"];
        }
    }
}

