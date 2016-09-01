using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.ViewModels
{
    public class QuestionsViewModel : ViewModelBase
    {
        IList<QuestionViewModel> _questions;
        QuestionViewModel _currentQuestion;

        public QuestionsViewModel(List<Question> questions)
        {
            if (questions == null)
                throw new ArgumentNullException(nameof(questions));

            foreach(var question in questions)
            {
                _questions.Add(new QuestionViewModel(question));
            }

            _currentQuestion
        }
    }
}

