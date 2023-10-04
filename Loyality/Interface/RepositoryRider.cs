using Loyality.DbContextApplication;
using Loyality.Entities;

namespace Loyality.Interface
{
    public class RepositoryRider : pointInterface
    {
        private readonly ApplicationDbContext _context;

        public RepositoryRider(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public string GetAchName()
        {
            // LINQ query to retrieve the AchievementName for the specified RiderData
            var achievementName = _context.riders
                .Select(x => x.AchievementName)
                .FirstOrDefault(); // Use FirstOrDefault to get the first matching record

            if (achievementName != null)
            {
                return achievementName; // Return the AchievementName as a string
            }
            else
            {
                return "No Achievement Found"; // Return a default value or handle the case where no achievement is found
            }
        }

    }
}
