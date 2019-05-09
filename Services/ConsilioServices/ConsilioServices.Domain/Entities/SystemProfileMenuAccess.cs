namespace ConsilioServices.Domain.Entities
{
    public class SystemProfileMenuAccess
    {
        public int SystemProfileId { get; set; }

        public SystemProfile SystemProfile { get; set; }

        public int MenuAccessId { get; set; }

        public MenuAccess MenuAccess { get; set; }

        public bool Access { get; set; }
    }
}
