using System.Collections.Generic;

namespace ConsilioServices.Domain.Entities
{
    public class MenuAccess
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SystemProfileMenuAccess> SystemProfileMenuAccesses { get; set; }
    }
}
