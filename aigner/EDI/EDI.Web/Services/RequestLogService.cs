using EDI.DataAccess;
using EDI.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Portal.Common.ExtensionMethods;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EDI.Web.Services
{
	public class RequestLogService : IAutoRegisterService
	{
		public IServiceProvider ServiceProvider { get; }
		public IHttpContextAccessor HttpContextAccessor { get; }
		public ApplicationDbContext DbContext { get; }

		public RequestLogService(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;
			HttpContextAccessor = ServiceProvider.GetService<IHttpContextAccessor>();
			DbContext = ServiceProvider.GetService<ApplicationDbContext>();
		}

		public async Task LogRequestAsync(ClaimsPrincipal user, string data, string outDirection=null)
        {
            var entity = new RequestLog();
            var remoteIpAddress = HttpContextAccessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            if (user != null)
            {
                var identity = user.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = user.FindFirstValue(ClaimTypes.Name);

                entity.CreatedUserId = userName;
                entity.Identity = identity;
                entity.IpAddress = remoteIpAddress;
                entity.Request = data;
                entity.OutDirection = outDirection;
            }
            else
            {
                entity.IpAddress = remoteIpAddress;
                entity.Request = data;
                entity.OutDirection = outDirection;
            }

            await DbContext.AddAsync(entity);
			await DbContext.SaveChangesAsync();

			await Task.CompletedTask;
		}
	}
}
