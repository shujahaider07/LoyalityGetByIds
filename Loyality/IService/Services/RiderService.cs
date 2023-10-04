using Loyality.Entities;
using Loyality.IRepository;

namespace Loyality.IService.Services
{
    public class RiderService : IRiderService
    {
        private readonly IRider _rider;

        public RiderService(IRider rider)
        {
            _rider = rider;
        }

        
        Task<List<RiderData>> IRiderService.GetById(List<int>? ids)
        {
            try
            {
                return _rider.GetById(ids);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
