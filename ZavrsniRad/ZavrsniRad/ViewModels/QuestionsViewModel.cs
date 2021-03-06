﻿using System;
using System.Collections.Generic;
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

        bool _hasWrongQuestions;
        public bool HasWrongQuestions
        {
            get { return _hasWrongQuestions; }
            private set { Set(ref _hasWrongQuestions, value); }
        }

        bool _hasNotWrongQuestions;
        public bool HasNotWrongQuestions
        {
            get { return _hasNotWrongQuestions; }
            private set { Set(ref _hasNotWrongQuestions, value); }
        }

        public QuestionViewModel CurrentQuestionViewModel 
            => CurrentQuestion > 0 && CurrentQuestion <= Questions.Count ? Questions[CurrentQuestion - 1] : null;

        public int Score { get; private set;}

        public string OfScore => "/ 5";

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
            //RaisePropertyChanged(nameof(CurrentQuestionViewModel));

            if (CurrentQuestion > 5)
            {
                WrongQuestions = Questions.Where(x => !x.IsCorrect).ToList();
                Score = Questions.Where(x => x.IsCorrect).ToList().Count;

                if (WrongQuestions.Count > 0)
                {
                    HasWrongQuestions = true;
                    HasNotWrongQuestions = false;
                }
                else
                {
                    HasWrongQuestions = false;
                    HasNotWrongQuestions = true;
                }

                var page = new ScoreView { BindingContext = this };
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }

            RaisePropertyChanged(nameof(CurrentQuestionViewModel));
        }
    }
}

