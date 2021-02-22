using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Services
{
    public interface IAppSettingService
    {
        public string ApiKey { get; }
        public string ApiKeyWrite { get; }
    }
}
