namespace Litemir_CouseWork_DataBase_Postgres.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<WorkEntity> Works { get; set; } = [];

        
    }
}
