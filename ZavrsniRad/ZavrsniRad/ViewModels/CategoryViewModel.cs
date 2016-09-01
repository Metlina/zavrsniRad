using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using ZavrsniRad.Model.Data;
using ZavrsniRad.Views;

namespace ZavrsniRad.ViewModels
{
    public class CategoryViewModel : ViewModelBase
    {
        public ICommand EasyCommand { get; }
        public ICommand MediumCommand { get; }
        public ICommand HardCommand { get; }

        public CategoryViewModel()
        {
            EasyCommand = new Command(Easy);
            MediumCommand = new Command(Medium);
            HardCommand = new Command(Hard);
        }

        void Easy()
        {
            var quizData = new QuizData();
            var easy = quizData.EasyQuestions;

            var page = new QuestionView{ BindingContext = new QuestionViewModel(easy) };
            Application.Current.MainPage.Navigation.PushAsync(page);
        }

        void Medium()
        {
            var quizData = new QuizData();
            var medium = quizData.MediumQuestions; 

            var page = new QuestionView { BindingContext = new QuestionViewModel(medium) };
            Application.Current.MainPage.Navigation.PushAsync(page);
        }

        void Hard()
        {
            var quizData = new QuizData();
            var hard = quizData.HardQuestions;

            var page = new QuestionView { BindingContext = new QuestionViewModel(hard) };
            Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

