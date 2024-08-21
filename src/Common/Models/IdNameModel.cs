namespace Utconnect.Common.Models;

public class IdNameModel<TId, TName>
{
    public required TId Id { get; set; }
    public required TName Name { get; set; }
}

public class IdNameModel : IdNameModel<string, string>;