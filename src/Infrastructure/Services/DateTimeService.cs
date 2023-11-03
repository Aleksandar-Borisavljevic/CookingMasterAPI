using CookingMasterApi.Application.Common.Interfaces;

namespace CookingMasterApi.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
