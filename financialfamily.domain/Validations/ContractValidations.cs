using System.Security;
using financialfamily.domain.Notitications;
using financialfamily.domain.Validations.Interfaces;

namespace financialfamily.domain.Validations
{
    public partial class ContractValidations<T> where T : IContract
    {
        private List<Notification> _notifications;

        public ContractValidations()
        {
            _notifications = new List<Notification>();
        }

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public void AddNotification(Notification notification) => _notifications.Add(notification);

        public bool Isvalid() => _notifications.Count == 0;
    }
}