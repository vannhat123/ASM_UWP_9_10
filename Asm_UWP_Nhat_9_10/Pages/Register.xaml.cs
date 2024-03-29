﻿using Asm_UWP_Nhat_9_10.Entity;
using Asm_UWP_Nhat_9_10.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Asm_UWP_Nhat_9_10.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private IMemberService memberService;
        public Register()
        {
            this.InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var member1 = new Member
            {
                firstName = "Nhat1",
                lastName = "Hero1",
                password = "1234561",
                address = "Cau Dien1",
                avatar = "https://thumbor.forbes.com/thumbor/960x0/https%3A%2F%2Fblogs-images.forbes.com%2Frainerzitelmann%2Ffiles%2F2019%2F05%2FGettyImages-481406443-1200x1785.jpg",
                birthday = "1994-02-08",
                email = "nhatnvd1212@gmail.com",
                gender = 1,
                introduction = "I am a personal trainer",
                phone = "0918273643"
            };

            //var member = new Member {

            //    firstName = this.firstName.Text,
            //    lastName = this.LastName.Text,
            //    password = this.Password.Password,
            //    address = this.Address.Text,
            //    avatar = this.Avatar.Text,
            //    birthday = this.Birthday.Text,
            //    email = this.Email.Text,
            //    gender = Convert.ToInt32(this.Gender.Text),
            //    introduction = this.firstName.Text,
            //    phone = this.Phone.Text
            //};


            // validate phía client.
            memberService.Register(member1);
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidateRegister(Member member)
        {
            if (member.firstName.Length >0 & 
                member.lastName.Length > 0 & 
                member.lastName.Length > 0 &
                member.address.Length > 0 &
                member.avatar.Length > 0 &
                member.birthday.Length >0 &
                member.email.Length > 0 &
                member.introduction.Length > 0 &
                member.phone.Length > 0 &
                member.gender ==0 || member.gender ==1)
            {
                return true;
            }
                return false;
        }

    }
}
