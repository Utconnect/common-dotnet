using Utconnect.Common.Services.Abstractions;

namespace Utconnect.Common.Services.Implementations;

internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}