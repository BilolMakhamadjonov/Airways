using Airways.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.DataAccess.Repository;

public interface IUserRepository : IBaseRepository<User> 
{
    Task<User?> GetUserByEmailAsync(string email);
}