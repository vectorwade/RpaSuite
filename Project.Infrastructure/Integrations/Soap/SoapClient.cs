using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RpaSuite.Infrastructure.Integrations.Soap;

public interface ISoapClient
{
    Task EnviarAsync(object payload);
}

