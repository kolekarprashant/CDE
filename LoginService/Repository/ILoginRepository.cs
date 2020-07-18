using LoginService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Repository
{
    public interface ILoginRepository
    {
        LoginResponse getLogin(Login model);
        bool changePassword(Password model);

    }
}
