using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Login(string username, string password);
        AuthenticationResult Register(string username, string password, string firstName, string lastName);
    }
}
