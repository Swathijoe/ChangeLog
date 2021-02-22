using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Manager.ChangeLog
{
    public interface IChangeLogManager
    {
        Task<Entity.ChangeLog> AddLog(Entity.ChangeLog log);
    }
}
