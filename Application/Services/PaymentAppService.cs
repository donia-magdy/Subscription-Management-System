using AutoMapper;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;
using SubscriptionManagementSystem.Domain_Shared;

namespace SubscriptionManagementSystem.Application.Services
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IMapper _mapper;

        public PaymentAppService(IPaymentRepository paymentRepository, IUserSubscriptionRepository userSubscriptionRepository,IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
            _mapper = mapper;
        }
        public async Task<long> AddPaymentAsync(CreatePaymentDto input)
        {
            // Check if the user subscription exists
            var userSubscription = await _userSubscriptionRepository.GetByIdsAsync(input.UserSubscriptionId);
            if (userSubscription == null)
            {
                throw new Exception("User subscription not found.");
            }
            // Check if the user subscription is already active. No payment needed
            if (userSubscription.IsActive)
                throw new Exception("Subscription is already active;");

            var payment = new Payment
            {
                UserSubscriptionId = input.UserSubscriptionId,
                Amount = input.Amount,
                PaymentMethod = (PaymentMethod?)input.PaymentMethod,
                PaidAt = DateTime.Now
            };
            var paymentId = await _paymentRepository.AddPaymentAsync(payment);

            // Update the user subscription with the payment details
            userSubscription.Payment = payment;
            userSubscription.IsActive = true;

            await _userSubscriptionRepository.UpdateAsync(userSubscription);

            return paymentId;
        }
    }
}
