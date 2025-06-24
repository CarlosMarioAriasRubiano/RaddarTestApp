using RaddarTestApp.Domain.Entities.Base;

namespace RaddarTestApp.Domain.Entities
{
    public class User : EntityBase<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
