using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_APP_v1.Services
{
    class APIHandle
    {
        public const string API_BASE_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2";
        public const string GET_UPLOAD_URL = "https://2-dot-backup-server-003.appspot.com/get-upload-token";
        public const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/members";
        public const string LOGIN_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/members/authentication";
        public const string GET_FREE_SONG_URL = API_BASE_URL + "/songs/get-free-songs";
        public const string POST_SONG_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs";
        public const string GET_INFORMATION_URL = API_BASE_URL + "/members/information";
    }
}
