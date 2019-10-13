using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;
using UWP_APP_v1.Service;
using UWP_APP_v1.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_APP_v1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        private MemberService memberService;
        NaViewPage naViewPage = new NaViewPage();
        public Register()
        {
            this.InitializeComponent();
            this.memberService = new MemberServiceImp();
            this.naViewPage = new NaViewPage();
        }

        private void ButtonRegister_OnClick(object sender, RoutedEventArgs e)
        {
            var member = new Member
            {
                firstName = FirstName.Text,
                lastName = LastName.Text,
                avatar = Avatar.Text,
                phone = Phone.Text,
                address = Address.Text,
                introduction = Introduction.Text,
                gender = Int32.Parse(Gender.Text),
                birthday = Birthday.Text,
                email = Email.Text,
                password = Password.Password
            };
            // validate phía client.
            Debug.WriteLine(JsonConvert.SerializeObject(member));

            member = memberService.Register(member);
            if(member == null)
            {
                //show error
                MessageDialog messageDialog = new MessageDialog("Register fails! Please enter the correct fields.");
                _ = messageDialog.ShowAsync();
                Debug.WriteLine("Register fails !");
            }
            else
            {
                // show success
                MessageDialog messageDialog = new MessageDialog("Register success!");
                _ = messageDialog.ShowAsync();
                Debug.WriteLine("Register success !");
                //next page               
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Login));

            }
        }

        private void NextLogin_Button(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));
        }
    }
}
