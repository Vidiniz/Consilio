using System.Collections.Generic;

namespace ConsilioServices.Infrastructure.CrossCutting.ValueObject
{
    public class VOUserAccess
    {
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public int IdProfile { get; set; }

        public string ProfileName { get; set; }

        public IEnumerable<string> MenuAccess { get; set; }
    }
}
