namespace ConsilioServices.Application.ViewModel.SystemTools
{
    public class SystemProfileMenuAccessViewModel
    {
        public int Id { get; set; }

        public int SystemProfileId { get; set; }

        public SystemProfileViewModel SystemProfile { get; set; }

        public int MenuAccessId { get; set; }

        public MenuAccessViewModel MenuAccess { get; set; }

        public bool Access { get; set; }
    }
}
