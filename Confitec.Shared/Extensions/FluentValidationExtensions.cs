using Confitec.Core.Exceptions;
using Confitec.Shared.Contracts;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Confitec.Shared.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IValidator GetValidator(object obj)
        {
            var abstractValidatorType = typeof(AbstractValidator<>);
            var objType = obj.GetType();
            var genericType = abstractValidatorType.MakeGenericType(objType);
            var validatorType = FindValidatorType(objType.Assembly, genericType);
            return validatorType == null
                ? null
                : (IValidator)Activator.CreateInstance(validatorType);
        }

        public static Type FindValidatorType(Assembly assembly, Type genericType)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            if (genericType == null) throw new ArgumentNullException(nameof(genericType));
            return assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(genericType));
        }

        public static ICollection<string> ErrorMessages(this IList<ValidationFailure> value) =>
            value.Select(x => x.ErrorMessage)?.ToList();


        public static bool Validate(this IValidable value)
        {
            var validator = GetValidator(value);

            if (validator == null) return true;

            var validation = validator.Validate(new ValidationContext<object>(value));

            if (validation.IsValid) return true;

            throw new DomainException(validation.Errors.ErrorMessages());
        }
    }
}
