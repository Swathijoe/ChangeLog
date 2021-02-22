using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Core.Manager.User
{
    public class UserManager : IUserManager
    {
        private readonly IBaseManager<Entity.User> _baseManager;

        public UserManager(IBaseManager<Entity.User> baseManager)
        {
            _baseManager = baseManager;
        }

        public async Task<Entity.User> ValidateUser(Entity.User user)
        {
            var users = await _baseManager.Get();

            if(!string.IsNullOrEmpty(user.Email))
            {
                var googleUser = users.FirstOrDefault(u => u.Email == user.Email);

                if (googleUser != null) return googleUser;

                user.Id = new Guid();
                user = await _baseManager.Add(user);
                return user;
            }

            var validatedUser = users.FirstOrDefault(u => u.Name == user.Name);

            if (validatedUser != null)
            {
                if (validatedUser.Password == user.Password)
                {
                    return validatedUser;
                }
                else
                {
                    throw new UnauthorizedAccessException("Login Failed. Please check your user/password.");
                }
            }
            user.Id = new Guid();
            user = await _baseManager.Add(user);
            return user;
        }
    }
}
