using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Context;
using WebAPI.Core.Manager;

namespace Web.Api.Common
{
    [ApiExplorerSettings(IgnoreApi = false)]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {       

        private readonly IBaseManager<TEntity> _baseManager;
        public BaseController(IBaseManager<TEntity> baseManager)           
        {           
            _baseManager = baseManager;
        }       
       
        [HttpGet]
        public async Task<IEnumerable<TEntity>> Get()
        {           
            return await _baseManager.Get();
        }

        [HttpPost]       
        public async Task<TEntity> Post([FromBody] TEntity entity)
        {            
            return await _baseManager.Add(entity);
        }


        [HttpPut]      
        public async Task<TEntity> Put([FromBody] TEntity entity)
        {          
            return await _baseManager.Update(entity);
        }


        [HttpDelete("{id}")]  
        [Authorize]
        public async Task<int> Delete(Guid id)
        {
            
            return await _baseManager.Delete(id);
        }        
    }
}