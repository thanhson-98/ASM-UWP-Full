using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;
using UWP_APP_v1.Pages;
using UWP_APP_v1.Services;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UWP_APP_v1.Service
{
    class MemberServiceImp : MemberService
    {
        NaViewPage naViewPage = new NaViewPage();

        public Member GetInformation(string token)
        {
            throw new NotImplementedException();
        }

        //login
        public string Login(string username, string password)
        {
            try
            {
                var memberLogin = new MemberLogin()
                {
                    email = username,
                    password = password
                };
                //Validate
                if (!ValidationMemberLogin(memberLogin))
                {
                    MessageDialog messageDialog_login = new MessageDialog("Login fails!");
                    _ = messageDialog_login.ShowAsync();
                    Debug.WriteLine("Login fails !");
                }
                //Lay token tu api
                var token = GetTokenFormApi(memberLogin);
                //luu token vao file de sau dung lai
                SaveTokenToLocalStogare(token);
                //show success
                MessageDialog messageDialog = new MessageDialog("Login success!");
                _ = messageDialog.ShowAsync();
                //next page
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(NaViewPage));
                return token;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        //Register
        public Member Register(Member member)
        {
            var httpClient = new HttpClient();
            HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,
                    "application/json");
            var httpRequestMessage = httpClient.PostAsync(APIHandle.ApiUrl, content);
            var responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            // parse member object
            var resMember = JsonConvert.DeserializeObject<Member>(responseContent);         
            return resMember;
        }


        //Save token to file
        private void SaveTokenToLocalStogare(string token)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = storageFolder.CreateFileAsync("tokenSaveDemo.txt",
                CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            FileIO.WriteTextAsync(sampleFile, token).GetAwaiter().GetResult();
        }
        public string ReadToken()
        {
            StorageFolder storageFolder =
            ApplicationData.Current.LocalFolder;
            StorageFile sampleFile =
                storageFolder.GetFileAsync("tokenSaveDemo.txt").GetAwaiter().GetResult();
            string text = FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            return text;
        }
        //Return token
        public string GetTokenFormApi(MemberLogin memberLogin)
        {
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin),
                Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var responseContent = client.PostAsync(APIHandle.LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync().Result;
            var jsonJObject = JObject.Parse(responseContent);
            if (jsonJObject["token"] == null)
            {
                MessageDialog messageDialog = new MessageDialog("Login fails!");
                _ = messageDialog.ShowAsync();
                Debug.WriteLine("Login fails !");
            }
            return jsonJObject["token"].ToString();
        }

        private bool ValidationMemberLogin(MemberLogin memberLogin)
        {
            return true;
        }
    }
}
