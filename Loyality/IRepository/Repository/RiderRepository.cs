using Loyality.DbContextApplication;
using Loyality.Entities;

namespace Loyality.IRepository.Repository
{
    public class RiderRepository : IRider
    {

        private readonly ApplicationDbContext dbContext;

        public RiderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<RiderData>> GetById(List<int>? ids)
        {
            if (ids == null)
            {
                // Return an empty list if ids is null
                return new List<RiderData>();
            }

            List<RiderData> riders = new List<RiderData>();
                
            foreach (var id in ids)
            {
                // Yahan aap rider ko database se fetch kar sakte hain ya kisi storage se, jo bhi aapka use case hai.
                
                RiderData rider = await dbContext.riders.FindAsync(id);
                riders.Add(rider);
            }

            return riders;
        }
    }
  
}
