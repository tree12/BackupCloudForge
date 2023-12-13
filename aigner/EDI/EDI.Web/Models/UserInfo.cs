using System.Text.Json.Serialization;
using Microsoft.Net.Http.Headers;

namespace EDI.Web.Models
{
	public class UserInfo
	{
		public string Identity { get; set; }

		public string Username { get; set; }

		[JsonIgnore] // Ignore serialize when object send to frontend
		public string Password { get; set; }

        public SendInfo SendInfo { get; set; }
}

    public class SendInfo
    {
        public string Url { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
		public string Password { get; set; }
	}
}
