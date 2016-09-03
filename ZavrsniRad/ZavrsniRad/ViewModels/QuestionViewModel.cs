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

        public string Text { get; }
        public string FirstAnswer { get; }
        public string SecondAnswer { get; }
        public string ThirdAnswer { get;}

        public int QuestionNumber { get; }
        public string QuestionNumberString => QuestionNumber + ".";

        public int CorrectAnswer { get; }
        public bool IsCorrect { get; private set; }

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

