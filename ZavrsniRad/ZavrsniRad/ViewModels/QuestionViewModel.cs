using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        bool _isCorrect;

        string _text;
        public string Text
        {
            get { return _text; }
            private set { Set(ref _text, value); }
        }

        string _firstAnswer;
        public string FirstAnswer
        {
            get { return _firstAnswer; }
            private set { Set(ref _firstAnswer, value); }
        }

        string _secondAnswer;
        public string SecondAnswer
        {
            get { return _secondAnswer; }
            private set { Set(ref _secondAnswer, value); }
        }

        string _thirdAnswer;
        public string ThirdAnswer
        {
            get { return _thirdAnswer; }
            private set { Set(ref _thirdAnswer, value); }
        }

        public ICommand SelectedAnswer { get; }

        public QuestionViewModel(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            SelectedAnswer = new Command<int>(Answer);

            Text = question.Text;
            FirstAnswer = question.FirstAnswer;
            SecondAnswer = question.SecondAnswer;
            ThirdAnswer = question.ThirdAnswer;
        }

        void Answer(int selected)
        {
            
        }
    }
}

