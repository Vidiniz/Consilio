using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Domain.Entities
{
    public class SystemUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime RegisterDate { get; set; }

        public int SystemProfileId { get; set; }

        public SystemProfile SystemProfile { get; set; }
    }
}
