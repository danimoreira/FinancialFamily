using System.Text.RegularExpressions;
using financialfamily.domain.Notitications;

namespace financialfamily.domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> EmailIsOk(string email, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$"))
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}