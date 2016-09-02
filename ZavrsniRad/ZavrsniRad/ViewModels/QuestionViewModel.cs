using System;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;
using ZavrsniRad.Model.Model;

namespace ZavrsniRad.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        int _lastOne = 0;

        public string Text { get; private set; }
        public string FirstAnswer { get; private set; }
        public string SecondAnswer { get; private set; }
        public string ThirdAnswer { get; private set; }

        public int QuestionNumber { get; private set; }
        public string QuestionNumberString => QuestionNumber + ".";

        public int CorrectAnswer { get; private set; }
        public bool IsCorrect { get; private set; }
        public bool CorrectAnswerBool => GetCorrectAnswer();

        public ICommand TapCommand { get; }

        public QuestionViewModel(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            TapCommand = new Command<string>(Tap);

            Text = question.Text;
            FirstAnswer = question.FirstAnswer;
            SecondAnswer = question.SecondAnswer;
            ThirdAnswer = question.ThirdAnswer;
            CorrectAnswer = question.CorrectAnswer;
            QuestionNumber = question.Id;
        }

        bool GetCorrectAnswer()
        {
            return false;
        }

        void Tap(string selected)
        {
            var i = int.Parse(selected);

            if (i == _lastOne)
            {
                Messenger.Default.Send(new AlreadySelectedMessage(i));
                return;
            }

            if (i == CorrectAnswer)
            {
                IsCorrect = true;
            }
            else
            {
                IsCorrect = false;
            }

            Messenger.Default.Send(new TappedMessage(i));

            _lastOne = int.Parse(selected);
        }
    }
}

