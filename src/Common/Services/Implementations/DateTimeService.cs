using Common.Services.Abstractions;

namespace Common.Services.Implementations;

internal class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}