using Asm_UWP_Nhat_9_10.Service;
using System;
using System.Collections.Generic;
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
    public sealed partial class Login : Page
    {
        MemberService memberService = new MemberService();
        public Login()
        {
            this.InitializeComponent();
        }

        public void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

          //  memberService.Login(this.Email.Text, this.Password.Password);
             memberService.Login("nhatnvd@gmail.com","123456");
            this.Frame.Navigate(typeof(MasterLayout));
            ReTryPassWord();
        }

        private void ReTryPassWord()
        {
            this.Password.Password = string.Empty;
        }

        private void ButtonReset_Click_(object sender, RoutedEventArgs e)
        {
            ResetLoginForm();
        }

        private void ResetLoginForm()
        {
            this.Email.Text = string.Empty;
            this.Password.Password = string.Empty;
        }



    }
}
