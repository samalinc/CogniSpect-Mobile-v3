﻿using System.ComponentModel;
using CSMobile.Presentation.ViewModels.Authentication;
using Xamarin.Forms.Xaml;

namespace CSMobile.Presentation.Views.Pages.Authentication
{
    public class AuthenticationBasePage : ViewPage<AuthenticationViewModel> { }

    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthenticationPage : AuthenticationBasePage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }
    }
}