using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ZavrsniRad.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        string _text;
        public string Text
        {
            get { return _text; }
            private set { Set(ref _text, value); }
        }

        //public string Text { get; private set; }

        public ICommand ButtonCommand { get; }

        public TestViewModel()
        {
            ButtonCommand = new Command(Button);
        }

        void Button()
        {
            Text = Text + 1;
        }
    }
}

