using Application.Common.Exceptions;
using Application.Common.Interfaces.Authenticaion;
using Application.Common.Interfaces.Persistance;
using Domain.Entities;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IUserRepository userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.userRepository = userRepository;
        }

        public AuthenticationResult Login(string username, string password)
        {
            // 1. Check if user exists
            if (this.userRepository.GetUserByEmail(username) is not User user)
            {
                throw new AuthenticationException("User does not exist");
            }

            // 2. Check if password is correct
            if (user.Password != password)
            {
                throw new AuthenticationException("Password is incorrect");
            }

            // 3. Generate JWT token
            var token = this.jwtTokenGenerator.GenerateToken(user);

            // 4. Return result
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string username, string password, string firstName, string lastName)
        {
            // Check if user exists
            if (this.userRepository.GetUserByEmail(username) is not null)
            {
                throw new AuthenticationException("User with given email already exists");
            }

            // Create user
            User user = new()
            {
                Email = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
            };

            this.userRepository.Add(user);

            // Generate Jwt token
            string token = this.jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
