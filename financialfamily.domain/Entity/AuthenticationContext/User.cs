using financialfamily.domain.Enums;
using financialfamily.domain.Validations;
using financialfamily.domain.Validations.Interfaces;
using financialfamily.domain.ValueObjects;

namespace financialfamily.domain.Entity.AuthenticationContext
{
    public class User : EntityBase, IContract
    {
        public Name Name { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public RolesEnum Role { get; private set; }

        public User(
            Name name,
            string username,
            string password,
            RolesEnum role,
            string userCreate
        ) :
            base(userCreate)
        {
            Name = name;
            Username = username;
            Password = password;
            Role = role;

            this.IsValid();
        }

        public override void Update(string userUpdate)
        {
            this.IsValid();
            base.Update(userUpdate);
        }

        public virtual void ChangePassword(
            string newPassword,
            string userUpdate
        )
        {
            Password = newPassword;
            this.IsValid();
            this.Update(userUpdate);
        }

        public virtual void ChangeRole(RolesEnum newRole, string userUpdate)
        {
            Role = newRole;
            this.IsValid();
            this.Update(userUpdate);
        }

        public virtual bool IsAdministrator()
        {
            return Role == RolesEnum.Administrator;
        }

        public virtual bool IsOperator()
        {
            return Role == RolesEnum.Operator;
        }

        public virtual bool IsViewer()
        {
            return Role == RolesEnum.Viewer;
        }

        public override bool IsValid()
        {
            var contracts = new ContractValidations<User>()
            .GuidIsOk(Id, "Identificador inválido", "Id")
            .FirstNameIsOk(this.Name, 5, 30, "O primeiro nome deve ser informado e deve conter entre 5 e 30 caracteres", "Primeiro Nome")
            .LastNameIsOk(this.Name, 5, 30, "O último nome deve ser informado e deve conter entre 5 e 30 caracteres", "Último Nome")
            .EmailIsOk(Username, "O username deve ser um email válido!", "Usuário")
            .PasswordIsOk(Password, "Senha inválida!", "Senha");

            return contracts.Isvalid();
        }
    }
}
