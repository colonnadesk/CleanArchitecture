using Application.Common.Interfaces.Authenticaion;
using Application.Common.Interfaces.Persistance;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public AuthenticationResult Login(string email, string password)
        {
            // 1. Check if user exists
            if (userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User does not exist");
            }

            // 2. Check if password is correct
            if (user.Password != password)
            {
                throw new Exception("Password is incorrect");
            }

            // 3. Generate JWT token
            var token = jwtTokenGenerator.GenerateToken(user);

            // 4. Return result
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string email, string password, string firstName, string lastName)
        {
            // Check if user exists
            if (userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email already exists");
            }

            // Create user
            User user = new()
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            userRepository.Add(user);

            // Generate Jwt token
            string token = jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
