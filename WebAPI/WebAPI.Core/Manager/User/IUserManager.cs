using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Manager.User
{
    public interface IUserManager
    {
        Task<Entity.User> ValidateUser(Entity.User user);
    }
}
