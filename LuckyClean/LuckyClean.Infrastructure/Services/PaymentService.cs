using LuckyClean.Application.Interfaces;
using LuckyClean.Domain.Entities;
using LuckyClean.Domain.Enums;

namespace LuckyClean.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<PaymentResult> ProcessPaymentAsync(PaymentMethod method, decimal amount)
        {
            // TODO: implement real payment processing
            return Task.FromResult(PaymentResult.Success());
        }
    }
}
