using financialfamily.domain.Entity.AuthenticationContext;

namespace financialfamily.repositories.Interfaces
{
    public interface IUserRepository
    {
        public void Add(User entity);
        public void Update(User entity);
        public User GetById(Guid id);
        public List<User> GetAll();
    }
}