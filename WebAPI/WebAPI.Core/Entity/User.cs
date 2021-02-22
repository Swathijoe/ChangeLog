using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string SocialLoginId { get; set; }
        public string Email { get; set; }

        public string SocialLoginToken { get; set; }
      
        public string  Password { get; set; }

        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }

    }
}
