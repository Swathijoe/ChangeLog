using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Common;
using WebAPI.Core.Context;
using WebAPI.Core.Entity;
using WebAPI.Core.Manager;
using WebAPI.Core.Manager.ChangeLog;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]    
    public class ChangeLogController : BaseController<ChangeLog>
    {
        private readonly IChangeLogManager _changeLogManager;
        public ChangeLogController(IBaseManager<ChangeLog> manager, IChangeLogManager changeLogManager) : base(manager)
        {
            _changeLogManager = changeLogManager;
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public async Task<IActionResult> AddLog([FromBody] ChangeLog model)
        {
            return Ok(await _changeLogManager.AddLog(model));
        }
    }
}
