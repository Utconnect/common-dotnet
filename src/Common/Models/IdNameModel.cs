namespace Utconnect.Common.Models
{
    public class IdNameModel<TId, TName>
    {
        public TId Id { get; set; } = default!;
        public TName Name { get; set; } = default!;
    }

    public class IdNameModel : IdNameModel<string, string>
    {
    }
}