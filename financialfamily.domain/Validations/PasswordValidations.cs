using financialfamily.domain.Notitications;

namespace financialfamily.domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> PasswordIsOk(string password, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(password)
                || password.Length < 8)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}