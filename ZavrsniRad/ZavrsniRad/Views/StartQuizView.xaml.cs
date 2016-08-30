using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZavrsniRad
{
    public partial class StartQuizView : ContentPage
    {
        public StartQuizView()
        {
            InitializeComponent();

            BindingContext = new StartQuizViewModel();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}

