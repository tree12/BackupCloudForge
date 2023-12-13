using EDI.Web.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDI.Web.Services
{
	public class UserService : IUserService
	{
		private readonly List<UserInfo> _users;
		private readonly ILogger<UserService> _logger;

		public UserService(IOptions<List<UserInfo>> userInfos, ILogger<UserService> logger)
		{
			_users = userInfos.Value;
			_logger = logger;
		}

		public async Task<UserInfo> Authenticate(string username, string password)
		{
			// wrapped in "await Task.Run" to mimic fetching user from a db
			var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

			// return null if user not found
			if (user == null)
				return null;

			// authentication successful so return user details
			return user;
		}
	}
}
