using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_APP_v1.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using UWP_APP_v1.Services;
using UWP_APP_v1.Service;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_APP_v1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {     
        private MemberServiceImp memberServiceImp;
        public Login()
        {
            this.InitializeComponent();
            this.memberServiceImp = new MemberServiceImp();
        }

        //login 


        // method reset form login
        private void ResetLogin()
        {
            this.Email.Text = string.Empty;
            this.Pass.Password = string.Empty;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            progressLogin.IsIndeterminate = true;          
            memberServiceImp.Login(this.Email.Text, Pass.Password);
            ResetLogin();
        }

        private void NextRegister_Buton(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Register));
        }
    }
}
