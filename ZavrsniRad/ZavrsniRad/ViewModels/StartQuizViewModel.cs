using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZavrsniRad.Views;

namespace ZavrsniRad.ViewModels
{
    public class StartQuizViewModel
    {
        public ICommand StartQuizCommand { get; }
        public ICommand AboutCommand { get; }

        public StartQuizViewModel()
        {
            StartQuizCommand = new Command(StartQuiz);
            AboutCommand = new Command(About);
        }

        async void StartQuiz()
        {
            var page = new CategoryView();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        async void About()
        {
            var page = new AboutView();
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

