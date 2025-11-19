using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RpaSuite.Infrastructure.Integrations.Sftp;

public interface ISftpClientService
{
    void Upload(string localPath, string remotePath);
}

