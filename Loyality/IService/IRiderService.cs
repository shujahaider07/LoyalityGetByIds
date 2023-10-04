using Loyality.Entities;

namespace Loyality.IService
{
    public interface IRiderService
    {
        Task<List<RiderData>> GetById(List<int>? ids);
    }
}   
