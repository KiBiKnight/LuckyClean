using LuckyClean.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyClean.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendOrderConfirmationAsync(string email, decimal total)
        {
            // TODO: implement real email sending
            Console.WriteLine($"Sending confirmation to {email} for ${total}");
            return Task.CompletedTask;
        }
    }
}
