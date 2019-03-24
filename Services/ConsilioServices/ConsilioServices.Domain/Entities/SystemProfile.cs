using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Domain.Entities
{
    public class SystemProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasAdmin { get; set; }

        public IEnumerable<SystemUser> SystemUsers { get; set; }
    }
}
