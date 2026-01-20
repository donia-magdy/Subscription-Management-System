using AutoMapper;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Domain;

namespace SubscriptionManagementSystem.Application
{
    public class MyProfile: Profile
    {
        public MyProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserSubscriptionDto, UserSubscription>();
            CreateMap<Subscription, SubscriptionDto>();
            CreateMap<UserSubscription,UserSubscriptionDto>();
            CreateMap<CreatePaymentDto, Payment>(); 

        }
    }
}
