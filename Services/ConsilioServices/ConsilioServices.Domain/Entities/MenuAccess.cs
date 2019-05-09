using System.Collections.Generic;

namespace ConsilioServices.Domain.Entities
{
    public class MenuAccess
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TopicAccessId { get; set; }

        public virtual TopicAccess TopicAccess { get; set; }

        public IEnumerable<SystemProfileMenuAccess> SystemProfileMenuAccesses { get; set; }
    }
}
