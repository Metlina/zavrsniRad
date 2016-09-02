using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.ViewModels
{
    public class QuestionsViewModel : ViewModelBase
    {
        public IReadOnlyList<QuestionViewModel> Questions { get; }

        int _currentQuestion;
        public int CurrentQuestion
        {
            get { return _currentQuestion; }
            private set { Set(ref _currentQuestion, value); }
        }

        public QuestionViewModel CurrentQuestionViewModel 
            => CurrentQuestion > 0 && CurrentQuestion < Questions.Count ? Questions[CurrentQuestion - 1] : null;

        public ICommand AnswerCommand { get; }

        public QuestionsViewModel(List<Question> questions)
        {
            if (questions == null)
                throw new ArgumentNullException(nameof(questions));

            AnswerCommand = new Command(Answer);

            Questions = questions.Select(x => new QuestionViewModel(x)).ToList();

            CurrentQuestion = 1;
        }

        void Answer()
        {
            CurrentQuestion++;
            RaisePropertyChanged(nameof(CurrentQuestionViewModel));
        }
    }
}

