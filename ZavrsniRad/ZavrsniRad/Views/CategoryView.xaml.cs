using Xamarin.Forms;
using ZavrsniRad.ViewModels;

namespace ZavrsniRad.Views
{
    public partial class CategoryView : ContentPage
    {
        public CategoryView()
        {
            InitializeComponent();

            BindingContext = new CategoryViewModel();
        }
    }
}

