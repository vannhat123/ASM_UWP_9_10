using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class SongService : ISongService
    {
       private IMemberService memberService;

        public ObservableCollection<Song> GetFreeSongs()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            // thực hiện request lên api lấy token về.
            var token = GetTokenFromFileAfterLogin(); 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync(ApiUrl.GET_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }

        public Song PostSongFree(Song song)
        {
            var token = GetTokenFromFileAfterLogin();
            Debug.WriteLine("TOken: " + token);
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                "application/json");

            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl.POST_SONG, content);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            return song;
        }


        public ObservableCollection<Song> GetMySongs()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            // thực hiện request lên api lấy token về.
            var token = GetTokenFromFileAfterLogin();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var responseContent = client.GetAsync("https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-mine").Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
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
