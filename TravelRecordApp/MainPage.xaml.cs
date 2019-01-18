using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.aeroplane-icon-7.jpg", assembly);
        }


        async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool canLogin = await User.Login(emailEntry.Text, passwordEntry.Text);

            if(canLogin) 
               await Navigation.PushAsync(new HomePage());
            else
                await DisplayAlert("Error", "There was an error logging you in", "Ok");
        }

        void RegisterUser_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
