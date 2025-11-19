using Hangfire.Dashboard;
using System.Net;

namespace RpaSuite.Infrastructure.Scheduling.Hangfire;

public class LocalRequestsOnlyAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var http = context.GetHttpContext();
        if (http == null) return false;
        var remote = http.Connection.RemoteIpAddress;
        return remote != null && IPAddress.IsLoopback(remote);
    }
}
