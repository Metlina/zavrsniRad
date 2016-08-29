using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace ZavrsniRad 
{
    public class TestViewModel : ViewModelBase
    {
        public string Text { get; private set; }

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

