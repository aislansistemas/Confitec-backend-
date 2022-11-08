using System.ComponentModel;

namespace Confitec.Domain.Enums
{
    public enum SchoolingEnum : int
    {
        [Description("Infantil")]
        Children = 1,

        [Description("Fundamental")]
        Underlying = 2,

        [Description("Médio")]
        Medium = 3,

        [Description("Superior")]
        Higher = 4,
    }
}
