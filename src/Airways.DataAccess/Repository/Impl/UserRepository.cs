using Airways.Core.Entities;
using Airways.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.DataAccess.Repository.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _dataBaseContext;
        public UserRepository(DatabaseContext dataBaseContext) : base(dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<User?> GetUserByEmailAsync(string email) =>
            await _dataBaseContext.AirwaysUser.FirstOrDefaultAsync(u => u.Email == email);
    }
}
