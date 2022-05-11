using financialfamily.domain.Interfaces;
using financialfamily.domain.Notitications;
using financialfamily.domain.Validations.Interfaces;

namespace financialfamily.domain.Entity.AuthenticationContext
{
    public abstract class EntityBase : IEntityBase, IValidate
    {
        private List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public Guid Id { get; private set; }

        public DateTime CreateDate { get; private set; }

        public string UserCreate { get; private set; }

        public DateTime? UpdateDate { get; private set; }

        public string UserUpdate { get; private set; }

        public EntityBase(string userCreate)
        {
            _notifications = new List<Notification>();
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            UserCreate = userCreate;
            UserUpdate = string.Empty;
        }

        public virtual void Update(string userUpdate)
        {
            UpdateDate = DateTime.Now;
            UserUpdate = userUpdate;
        }

        public abstract bool IsValid();

        protected void SetNotificationsList(List<Notification> notifications) => _notifications = notifications;
    }
}
