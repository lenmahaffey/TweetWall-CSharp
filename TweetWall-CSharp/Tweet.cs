using System;
using System.Collections.Generic;
using System.Text;
using HTTPGetRequest;

namespace HTTPGetRequest
{
    class Tweet
    {
        public string created_at { get; set; }
        public string id  { get; set; }
        public string text { get; set; }
        public string truncated { get; set; }
        public string entities { get; set; }
        public string metadata { get; set; }
        public string source  { get; set; }
        public string in_reply_to_status_id { get; set; }
        public string in_reply_to_status_id_str { get; set; }
        public string in_reply_to_user_id { get; set; }
        public string in_reply_to_user_id_str { get; set; }
        public string in_reply_to_screen_name { get; set; }
        public TwitterUser user { get; set; }
        public string geo { get; set; }
        public string coordinates { get; set; }
        public string place { get; set; }
        public string contributors { get; set; }
        public string is_quote_status { get; set; }
        public string retweet_count { get; set; }
        public string favorite_count { get; set; }
        public string favorited { get; set; }
        public string retweeted { get; set; }
        public string possibly_sensitive { get; set; }
        public string lang { get; set; }
    }
}
