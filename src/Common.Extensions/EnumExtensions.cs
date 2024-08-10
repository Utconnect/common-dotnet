using System.ComponentModel;
using System.Reflection;

namespace Utconnect.Common.Extensions;

/// <summary>
/// Provides extension methods for working with enumeration (enum) values.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Retrieves the description of an enum value based on the <see cref="DescriptionAttribute"/>.
    /// </summary>
    /// <param name="value">The enum value for which to retrieve the description.</param>
    /// <returns>
    /// The description of the enum value if the <see cref="DescriptionAttribute"/> is applied; 
    /// otherwise, the name of the enum value as a string.
    /// </returns>
    public static string GetDescription(this Enum value)
    {
        DescriptionAttribute? attribute = value.GetAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }

    /// <summary>
    /// Retrieves a custom attribute of a specified type that is applied to an enum value.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to retrieve. Must inherit from <see cref="Attribute"/>.</typeparam>
    /// <param name="value">The enum value from which to retrieve the attribute.</param>
    /// <returns>
    /// The attribute of type <typeparamref name="T"/> if found; otherwise, <c>null</c>.
    /// </returns>
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