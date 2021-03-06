﻿using System.Collections.Generic;

namespace ConsilioServices.Domain.Entities
{
    public class SystemProfile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasAdmin { get; set; }

        public IEnumerable<SystemUser> SystemUsers { get; set; }

        public IEnumerable<SystemProfileMenuAccess> SystemProfileMenuAccesses { get; set; }
    }
}
