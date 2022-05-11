using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.repositories.Interfaces;

namespace financialfamily.repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepositoryBase<User> _repository;

        public UserRepository(IRepositoryBase<User> repository)
        {
            _repository = repository;
        }

        public virtual void Add(User entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(User entity)
        {
            _repository.Update(entity);
        }

        public virtual User GetById(Guid id)
        {
            var obj = _repository.GetById(id);
            return obj;
        }

        public virtual List<User> GetAll()
        {
            var obj = _repository.GetAll();
            return obj;
        }
    }
}