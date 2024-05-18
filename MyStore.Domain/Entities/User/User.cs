using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
