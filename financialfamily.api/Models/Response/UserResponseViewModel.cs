using financialfamily.domain.Entity.AuthenticationContext;
using financialfamily.domain.Notitications;
using financialfamily.domain.ValueObjects;

namespace financialfamily.api.Models.Response
{
    public class UserResponseViewModel
    {
        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public string UserName { get; private set; }

        public string Password { get; private set; }

        public IReadOnlyCollection<Notification> Notifications;

        public UserResponseViewModel(Guid id, Name name, string userName, string password, IReadOnlyCollection<Notification> notifications)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
            Notifications = notifications;
        }

        public static implicit operator UserResponseViewModel(User user)
        {
            var objResponse =
                new UserResponseViewModel(user.Id, 
                user.Name, 
                user.Username, 
                user.Password, 
                user.Notifications);
            return objResponse;
        }
    }
}
