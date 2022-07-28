using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
