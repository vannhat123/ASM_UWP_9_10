using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm_UWP_Nhat_9_10.Constant
{
    class ApiUrl
    {
        public const string API_BASE_URL = "https://2-dot-backup-server-003.appspot.com/_api/v2";
        public const string LOGIN_URL = API_BASE_URL + "/members/authentication";
        public const string GET_INFORMATION_URL = API_BASE_URL + "/members";
        public const string GET_SONG_URL = API_BASE_URL + "/songs";
        public const string REGISTER_URL = API_BASE_URL + "/members";
        public const string POST_SONG = API_BASE_URL + "/songs";
        public const string GET_MYSONG = API_BASE_URL + "/get-mine";
    }
}
