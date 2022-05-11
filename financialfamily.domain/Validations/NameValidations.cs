using financialfamily.domain.Notitications;
using financialfamily.domain.ValueObjects;

namespace financialfamily.domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> FirstNameIsOk(Name name, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(name.FirstName) || name.FirstName.Length < minLength || name.FirstName.Length > maxLength)
                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidations<T> LastNameIsOk(Name name, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(name.LastName) || name.LastName.Length < minLength || name.LastName.Length > maxLength)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}