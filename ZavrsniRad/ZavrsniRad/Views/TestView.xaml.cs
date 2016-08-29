using Xamarin.Forms;

namespace ZavrsniRad
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();

            BindingContext = new TestViewModel();
        }
    }
}

