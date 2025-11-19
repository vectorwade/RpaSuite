using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpaSuite.Infrastructure.Integrations.Rest;

public interface IRestClient
{
    Task<T?> GetAsync<T>(string path);
}
