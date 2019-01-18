﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class User : INotifyPropertyChanged
    {
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
       
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task<bool> Login(string email, string password)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(email);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isEmailEmpty == true || isPasswordEmpty == true)
            {
                return false;
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user != null)

                {
                    App.user = user;
                    if (user.Password == password)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }


            }
        }

        public static async void Register(User user)
        {
            await App.MobileService.GetTable<User>().InsertAsync(user);
        }
    }
}
