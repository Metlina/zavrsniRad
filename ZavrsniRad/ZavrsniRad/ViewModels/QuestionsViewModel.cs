using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using ZavrsniRad.Model.Model;
using ZavrsniRad.Views;

namespace ZavrsniRad.ViewModels
{
    public class QuestionsViewModel : ViewModelBase
    {
        public IReadOnlyList<QuestionViewModel> Questions { get; }
        public IReadOnlyList<QuestionViewModel> WrongQuestions { get; private set; }

        int _currentQuestion;
        public int CurrentQuestion
        {
            get { return _currentQuestion; }
            private set { Set(ref _currentQuestion, value); }
        }

        public QuestionViewModel CurrentQuestionViewModel 
            => CurrentQuestion > 0 && CurrentQuestion <= Questions.Count ? Questions[CurrentQuestion - 1] : null;

        public int Score { get; private set;}

        public ICommand AnswerCommand { get; }

        public QuestionsViewModel(List<Question> questions)
        {
            if (questions == null)
                throw new ArgumentNullException(nameof(questions));

            AnswerCommand = new Command(Answer);

            Questions = questions.Select(x => new QuestionViewModel(x)).ToList();

            CurrentQuestion = 1;
        }

        async void Answer()
        {
            Messenger.Default.Send(new AnswerMessage());

            CurrentQuestion++;
            RaisePropertyChanged(nameof(CurrentQuestionViewModel));

            if (CurrentQuestion > 5)
            {
                WrongQuestions = Questions.Where(x => !x.IsCorrect).ToList();
                Score = Questions.Where(x => x.IsCorrect).ToList().Count;

                var page = new ScoreView { BindingContext = this };
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }
    }
}

