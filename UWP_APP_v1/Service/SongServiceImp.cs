using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UWP_APP_v1.Entity;
using UWP_APP_v1.Services;
using Windows.Storage;

namespace UWP_APP_v1.Service
{
    class SongServiceImp : SongService
    {      

        public ObservableCollection<Song> GetFreeSong()
        {
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            var client = new HttpClient();
            var responseContent = client.GetAsync(APIHandle.GET_FREE_SONG_URL).Result.Content.ReadAsStringAsync().Result;
            songs = JsonConvert.DeserializeObject<ObservableCollection<Song>>(responseContent);
            return songs;
        }


        Song SongService.PostSongFreeAsync(Song song)
        {
            Debug.WriteLine(JsonConvert.SerializeObject(song));
            var httpClient = new HttpClient();
            MemberServiceImp memberServiceImp = new MemberServiceImp();

            httpClient.DefaultRequestHeaders.Add("Authorization", memberServiceImp.ReadToken());
            HttpContent content = new StringContent(JsonConvert.SerializeObject(song), Encoding.UTF8,
                "application/json");
            Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(APIHandle.POST_SONG_URL, content);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            Debug.WriteLine("Response: " + responseContent);
            return song;
        }
    }
}
