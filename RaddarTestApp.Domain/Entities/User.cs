using RaddarTestApp.Domain.Entities.Base;

namespace RaddarTestApp.Domain.Entities
{
    public class User : EntityBase<int>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
