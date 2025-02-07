using Airways.Application.Models.Airline;
using Airways.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.Application.Services
{
    public interface IAirlineService
    {

        Task<List<AirlineResponceModel?>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<CreateAirlineResponceModel> CreateAsync(AirlineCreateModel createTodoItemModel,
      CancellationToken cancellationToken = default);

        Task<BaseResponceModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<AirlineResponceModel>>
            GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateAirlineResponceModel> UpdateAsync(Guid id, AirlineUpdateModel updateTodoItemModel,
            CancellationToken cancellationToken = default);
    }
}
