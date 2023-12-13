using EDI.Web.Models;
using System.Threading.Tasks;

namespace EDI.Web.Services
{
	public interface IUserService
	{
		Task<UserInfo> Authenticate(string username, string password);
	}
}