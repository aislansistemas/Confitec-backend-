using Confitec.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Core.Exceptions
{
    public class DomainException : Exception
    {
        private const string ExceptionMessage = "Domain Exception";

        public IEnumerable<string> Errors => Notifications.Select(x => x.Value);

        public IEnumerable<Notification> Notifications { get; private set; }

        public DomainException(params string[] notifications) : base(ExceptionMessage)
        {
            Notifications = notifications.Select(x => new Notification(x));
        }

        public DomainException(IEnumerable<string> notifications) : base(ExceptionMessage)
        {
            Notifications = notifications.Select(x => new Notification(x));
        }

        public DomainException(params Notification[] notifications) : base(ExceptionMessage)
        {
            Notifications = notifications;
        }

        public DomainException(IEnumerable<Notification> notifications) : base(ExceptionMessage)
        {
            Notifications = notifications;
        }
    }
}
