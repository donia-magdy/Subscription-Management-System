using AutoMapper;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;
using SubscriptionManagementSystem.Domain_Shared;

namespace SubscriptionManagementSystem.Application.Services
{
    public class UserSubscriptionAppService : IUserSubscriptionAppService
    {
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        private DateTime CalculateEndDate(Cycle cycle, DateTime startDate)
        {
            switch (cycle)
            {
                case Cycle.Weekly:
                    return startDate.AddDays(7);
                case Cycle.Monthly:
                    return startDate.AddMonths(1);
                case Cycle.Quarter:
                    return startDate.AddMonths(3);
                case Cycle.Bi_Annual:
                    return startDate.AddMonths(6);
                case Cycle.Annual:
                    return startDate.AddYears(1);
                default:
                    return startDate.AddMonths(1);
            }
        }

        public UserSubscriptionAppService(IUserSubscriptionRepository userSubscriptionRepository,IMapper mapper,ISubscriptionRepository subscriptionRepository,IUserRepository userRepository)
        {
            _userSubscriptionRepository = userSubscriptionRepository;
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }
        public async Task<long> CreateUserSubscriptionAsync(CreateUserSubscriptionDto input)
        {
            // check if subscription exists and is active
            var subscription = await _subscriptionRepository.GetByIdAsync(input.SubscriptionId);
            if(subscription==null || !subscription.IsActive)
            {
                throw new Exception("Subscription is not available.");
            }
            // check if user exists
            var user = await _userRepository.GetByIdAsync(input.UserId);
            if (user == null)
            {
                throw new Exception("user is not found.");
            }
            // check if user already has active subscription of the same type
            var usersubscriptionExists = await _userSubscriptionRepository.GetActiveUserSubscriptionbyIdsAsync(input.UserId,input.SubscriptionId);
            if (usersubscriptionExists != null)
            {
                throw new Exception("user already has subscription of the same type");
            }
            var userSubscription= _mapper.Map<UserSubscription>(input);
            // set start date and end date based on subscription cycle
            userSubscription.StartDate = DateTime.Now;
            userSubscription.EndDate = CalculateEndDate(subscription.Cycle, userSubscription.StartDate);
            userSubscription.IsActive = false;
            return await _userSubscriptionRepository.AddAsync(userSubscription);
        }
        public async Task<UserSubscriptionsDetailsDto> GetUserSubscriptionDetailsAsync(long userId, bool? isActive, int? pageNumber, int? pageSize, string? orderBy)
        {
            // Check if the user exists
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found.");
            // Retrieve user subscriptions
            var subscriptions = await _userSubscriptionRepository.GetByUserIdAsync(userId, isActive, pageNumber, pageSize, orderBy);
            // Get total count
            var totalCount = await _userSubscriptionRepository.GetTotalCountByUserIdAsync(userId, isActive);
            // Map to DTOs
            var subscriptionDtos = subscriptions.Select(us => new UserSubscriptionDto
            {
                Id = us.Id,
                Name=us.Subscription.Name,
                StartDate = us.StartDate,
                EndDate = (DateTime)us.EndDate,
                Price = us.Subscription.Price,
                IsActive = us.IsActive,
                Cycle = new EnumDto
                {
                    Id = (long)us.Subscription.Cycle,
                    Name = us.Subscription.Cycle.ToString()
                },
                PaymentMethod = us.Payment == null ? null : new EnumDto
                {
                    Id = (long)us.Payment.PaymentMethod,
                    Name = us.Payment.PaymentMethod.ToString()
                },
                PaidAt = us.Payment?.PaidAt
            }).ToList();
            return new UserSubscriptionsDetailsDto
            {
                User = _mapper.Map<UserDto>(user),
                Subscriptions = subscriptionDtos,
                TotalCount = totalCount
            };
        }
    }
}
