using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.domain.Enums;
using financialfamily.domain.Notitications;
using financialfamily.domain.ValueObjects;

namespace financialfamily.api.Models.Request
{
    public class UserRequestCreateViewModel
    {
        public Name Name { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public RolesEnum Role { get; private set; }

        public string UserCreate { get; private set; }

        public UserRequestCreateViewModel(
            Name name,
            string username,
            string password,
            RolesEnum role,
            string userCreate)
        {
            Name = name;
            UserName = username;
            Password = password;
            Role = role;
            UserCreate = userCreate;
        }

        public static implicit operator User(
            UserRequestCreateViewModel userRequest)
        {
            var objUser =
                new User(new Name(userRequest.Name.FirstName, userRequest.Name.LastName),
                    userRequest.UserName,
                    userRequest.Password,
                    userRequest.Role,
                    userRequest.UserCreate);

            return objUser;
        }

        public static implicit operator UserRequestCreateViewModel(
            User user)
        {
            var objUser =
                new UserRequestCreateViewModel(new Name(user.Name.FirstName, user.Name.LastName),
                    user.Username,
                    user.Password,
                    user.Role,
                    user.UserCreate);

            return objUser;
        }
    }
}
