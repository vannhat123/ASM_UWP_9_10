using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Asm_UWP_Nhat_9_10.Constant;
using Asm_UWP_Nhat_9_10.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asm_UWP_Nhat_9_10.Service
{
    class MemberService : IMemberService
    {
     
        public String Login(string username, string password)
        {
            try
            {
                //tạo đối tượng member login từ giá trị của form.
                var memberLogin = new MemberLogin()
                {
                    email = username,
                    password = password
                };
                // validate
                //if (!ValidaTeMemberLogin(memberLogin))
                //{
                //    throw new Exception("Login fails!");
                //}
                // lấy token từ api.
                var token = GetTokenFromApi(memberLogin);
                //lưu token ra file để dùng lại
                SaveToken(token);
                GetInformation(token);
                return token;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Login fails: "+e.Message);
                return null;
            }
        }

      
        public Member Register(Member member)
        {
            try
            {
                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(member), Encoding.UTF8,
                    "application/json");

                var httpRequestMessage = httpClient.PostAsync(ApiUrl.REGISTER_URL, content);
                var responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
                // parse member object
                var resMember = JsonConvert.DeserializeObject<Member>(responseContent);
                return resMember;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

        }


        private void SaveToken(string token)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.CreateFileAsync("12341.txt",
                Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(sampleFile, token).GetAwaiter().GetResult();
            Debug.WriteLine("URL link save: " + sampleFile.Path);
        }

  

        private String GetTokenFromApi(MemberLogin memberLogin)
        {
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin),
                Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var responseContent = client.PostAsync(ApiUrl.LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync().Result;
            var jsonJObject = JObject.Parse(responseContent);
            if (jsonJObject["token"] == null)
            {
                throw new Exception("Login fails");
            }
            return jsonJObject["token"].ToString();
        }

        private bool ValidaTeMemberLogin(MemberLogin memberLogin)
        {
            var dataContent = new StringContent(JsonConvert.SerializeObject(memberLogin),
              Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var responseContent = client.PostAsync(ApiUrl.LOGIN_URL, dataContent).Result.Content.ReadAsStringAsync().Result;
            var jsonJObject = JObject.Parse(responseContent);
            //if (memberLogin.email == jsonJObject["email"].ToString() & memberLogin.password == jsonJObject["password"].ToString())
            //{
            //    Debug.WriteLine("Username yes");
            //    return false;
            //}
            Debug.WriteLine("Email:"+  jsonJObject["email"] + "Password: " + jsonJObject["password"].ToString());
                return true;
        }

        public Member GetInformation(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(ApiUrl.GET_INFORMATION_URL).Result.Content.ReadAsStringAsync().Result;
            Member resMember = JsonConvert.DeserializeObject<Member>(responseContent);
            Debug.WriteLine("Information: " + responseContent);
            JObject jObject = JObject.Parse(responseContent);
            Debug.WriteLine("Jobjet: "+ jObject["email"]);
            return resMember;
        }

        //private MemberLogin GetInformMemberLogin(MemberLogin memberLogin)
        //{

        //    return memberLogin;
        //}
    }
}
