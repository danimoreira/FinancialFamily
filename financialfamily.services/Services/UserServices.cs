using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.domain.Enums;
using financialfamily.repositories.Interfaces;
using financialfamily.services.Interfaces;

namespace financialfamily.services.Services
{
    public class UserServices : IUserServices
    {
        public IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }

        public virtual void Create(User user)
        {
            _repository.Add(user);
        }

        public virtual void Update(User user)
        {
            _repository.Update(user);
        }

        public virtual User GetById(Guid id)
        {
            var user = _repository.GetById(id);

            if (user == null)
                throw new Exception("Usuário não encontrado");

            return user;
        }

        public virtual List<User> GetAll()
        {
            var users = _repository.GetAll();
            return users;
        }

        public virtual User GetByUsername(string userName)
        {
            var user = this.GetAll()
                        .Where(x => x.Username == userName)
                        .FirstOrDefault();

            if (user == null)
                throw new Exception("Usuário não encontrado!");

            return user;
        }

        public virtual void ChangePassword(Guid id, string newPassword, string userUpdate)
        {
            var user = this.GetById(id);

            if (user.Username != userUpdate)
            {
                var userAuthor = this.GetByUsername(userUpdate);

                if (!userAuthor.IsAdministrator())
                    throw new Exception("Privilégios insuficientes para alterar a senha!");
            }

            user.ChangePassword(newPassword, userUpdate);
            this.Update(user);
        }

        public virtual void ChangeRole(Guid id, RolesEnum newRole, string userUpdate)
        {
            var userAuthor = this.GetByUsername(userUpdate);

            if (userAuthor.IsViewer())
                throw new Exception("Privilégio insuficiente para alterar função!");

            if (userAuthor.IsOperator() && newRole == RolesEnum.Administrator)
                throw new Exception("Privilégio insuficiente para alterar função!");

            var user = this.GetById(id);

            user.ChangeRole(newRole, userUpdate);
            this.Update(user);
        }

        public virtual User Autenticate(string username, string password)
        {
            var user = _repository
                            .GetAll()
                            .Where(x => x.Username == username)
                            .FirstOrDefault();

            if (user == null)
                throw new Exception("Usuário não encontrado!");

            if (user.Password != password)
                throw new Exception("Dados inválidos para autenticar!");

            return user;
        }

    }
}