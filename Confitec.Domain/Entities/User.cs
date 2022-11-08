using Confitec.Domain.Enums;
using Confitec.Domain.ValueObjects;
using System;

namespace Confitec.Domain.Entities
{
    public sealed class User
    {
        protected User()
        {

        }

        public User(
            string name,
            string lastName,
            EmailVo email,
            DateTime birthDate,
            SchoolingEnum schooling
        )
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Schooling = schooling;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public EmailVo Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public SchoolingEnum Schooling { get; private set; }

        public void Update(
            string name,
            string lastName,
            EmailVo email,
            DateTime birthDate,
            SchoolingEnum schooling
        )
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Schooling = schooling;
        }
    }
}
