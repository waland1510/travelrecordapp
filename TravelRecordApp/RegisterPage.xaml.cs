using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class RegisterPage : ContentPage
    {
        RegisterVM viewModel;
         
        public RegisterPage()
        {
            InitializeComponent();

            viewModel = new RegisterVM();
            BindingContext = viewModel;
        }
    }
}
