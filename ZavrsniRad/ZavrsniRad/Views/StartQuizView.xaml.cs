﻿using Xamarin.Forms;
using ZavrsniRad.ViewModels;

namespace ZavrsniRad.Views
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

