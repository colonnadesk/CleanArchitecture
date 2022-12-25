using Application.Common.Interfaces;
using Application.Common.Interfaces.Persistance;
using Domain.Entities;

namespace Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();
        private readonly IApplicationDbContext context;

        public UserRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(u => u.Email == email);
        }
    }
}
