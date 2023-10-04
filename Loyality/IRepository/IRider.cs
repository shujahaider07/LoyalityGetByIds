using Loyality.Entities;

namespace Loyality.IRepository
{
    public interface IRider
    {

        Task<List<RiderData>> GetById(List<int>? ids);

    }
}
