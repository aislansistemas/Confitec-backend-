using Confitec.Core.Utils;
using Confitec.Domain.Enums;
using Confitec.Domain.ValueObjects;
using System;

namespace Confitec.Services.ViewModels
{
    public sealed class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public EmailVo Email { get; set; }
        public DateTime BirthDate { get; set; }
        public SchoolingEnum Schooling { get; set; }
        public string SchoolingDescription => Schooling.Description();
    }
}
