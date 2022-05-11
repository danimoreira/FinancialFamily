using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.domain.Enums;

namespace financialfamily.services.Interfaces
{
    public interface IUserServices
    {
        public void Create(User user);
        public void Update(User user);
        public User GetById(Guid id);
        public List<User> GetAll();
        public User GetByUsername(string userName);
        public void ChangePassword(Guid id, string newPassword, string userUpdate);
        public void ChangeRole(Guid id, RolesEnum newRole, string userUpdate);
        public User Autenticate(string username, string password);
    }
}