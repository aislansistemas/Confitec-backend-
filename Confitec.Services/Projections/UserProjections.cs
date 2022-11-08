using Confitec.Domain.Entities;
using Confitec.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Services.Projections
{
    public static class UserProjections
    {
        public static UserViewModel ToViewModel(
            this User user
        ) => new UserViewModel
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Schooling = user.Schooling
        };

        public static IEnumerable<UserViewModel> ToViewModel(this IQueryable<User> user) => user.Select(x => x.ToViewModel());

    }
}
