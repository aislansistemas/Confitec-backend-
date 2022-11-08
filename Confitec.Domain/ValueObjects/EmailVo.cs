using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Confitec.Domain.ValueObjects
{
    public sealed class EmailVo
    {
        public string Address { get; set; }

        [JsonIgnore]
        public readonly bool IsValid;

        public EmailVo(string address)
        {
            address ??= string.Empty;
            IsValid = new EmailAddressAttribute().IsValid(address);
            if (IsValid)
                Address = address;
        }

        public static implicit operator EmailVo(string address) => new EmailVo(address);

        public override string ToString() => Address;
    }
}
