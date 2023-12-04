

using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface IEmailService
{
   public Task Send(EmailData data);

}

