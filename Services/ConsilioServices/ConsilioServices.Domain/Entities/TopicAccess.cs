using System.Collections.Generic;

namespace ConsilioServices.Domain.Entities
{
    public class TopicAccess
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MenuAccess> MenuAccesses { get; set; }
        
    }
}
