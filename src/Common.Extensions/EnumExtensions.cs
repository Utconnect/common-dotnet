using System.ComponentModel;
using System.Reflection;

namespace Utconnect.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        DescriptionAttribute? attribute = value.GetAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

    private static T? GetAttribute<T>(this Enum value) where T : Attribute
    {
        Type type = value.GetType();
        MemberInfo[] memberInfo = type.GetMember(value.ToString());
        object[] attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0
            ? (T)attributes[0]
            : null;
    }
}