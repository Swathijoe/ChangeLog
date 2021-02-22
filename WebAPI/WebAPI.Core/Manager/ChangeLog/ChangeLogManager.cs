using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Manager.ChangeLog
{
    public class ChangeLogManager:IChangeLogManager
    {
        private readonly IBaseManager<Entity.ChangeLog> _baseManager;
        public ChangeLogManager(IBaseManager<Entity.ChangeLog> baseManager)
        {
            _baseManager = baseManager;

        }

        public async Task<Entity.ChangeLog> AddLog(Entity.ChangeLog log)
        {
            log.Id = Guid.NewGuid();                
            return await _baseManager.Add(log);
        }
    }
}
