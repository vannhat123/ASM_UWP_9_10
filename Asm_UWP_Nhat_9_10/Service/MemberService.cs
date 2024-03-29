﻿using System;
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
                if (!ValidaTeMemberLogin(memberLogin))
                {
                    throw new Exception("Login fails!");
                }
                // lấy token từ api.
                var token = GetTokenFromApi(memberLogin);
                //lưu token ra file để dùng lại
                SaveToken(token);
                GetInformation();
                Debug.WriteLine("TOken : " + token);
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
                Debug.WriteLine(responseContent);
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
            if (memberLogin.email.Length > 0 & memberLogin.password.Length >0 )
            {
                return true;
            }
            return false;
        }

        public Member GetInformation()
        {
            Member resMember = new Member();
            var token = GetTokenFromFileAfterLogin();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync("https://2-dot-backup-server-003.appspot.com/_api/v2/members").Result.Content.ReadAsStringAsync().Result;
             resMember = JsonConvert.DeserializeObject<Member>(responseContent);
         //   JObject jObject = JObject.Parse(responseContent);
            return resMember;
        }

        public string GetTokenFromFileAfterLogin()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = storageFolder.GetFileAsync("12341.txt").GetAwaiter().GetResult();
            var token = Windows.Storage.FileIO.ReadTextAsync(sampleFile).GetAwaiter().GetResult();
            return token;
        }
    }
}
