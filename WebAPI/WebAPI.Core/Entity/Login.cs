using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Core.Entity
{
    public class Login
    {
        public string AuthToken { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string Id { get; set; }
		public string IdToken { get; set; }
		public string LastName { get; set; }
		public string Name { get; set; }
		public string PhotoUrl { get; set; }
		public string Provider { get; set; }
		public string Response { get; set; }
		
	}
}
