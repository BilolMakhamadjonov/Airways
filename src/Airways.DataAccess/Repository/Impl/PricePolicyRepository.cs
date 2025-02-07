using Airways.Core.Entities;
using Airways.DataAccess.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.DataAccess.Repository.Impl
{
    public class PricePolicyRepository : BaseRepository<PricePolicy>, IPricePolyceRepository
    {
        public PricePolicyRepository(DatabaseContext dataBaseContext) : base(dataBaseContext) { }
    }
}
