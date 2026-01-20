using AutoMapper;
using SubscriptionManagementSystem.Application_Contracts.Dtos;
using SubscriptionManagementSystem.Application_Contracts.IServices;
using SubscriptionManagementSystem.Domain;
using SubscriptionManagementSystem.Domain.Repositories;

namespace SubscriptionManagementSystem.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<long> CreateUserAsync(CreateUserDto input)
        {
            if (await _userRepository.EmailExistsAsync(input.Email))
            {
                throw new Exception("Email already exists.");
            }

            var user = _mapper.Map<User>(input);
            return await _userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(long id)
        {
            await _userRepository.DeleteAsync(id);

        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
