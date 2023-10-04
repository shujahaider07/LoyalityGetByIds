using System.ComponentModel.DataAnnotations;

namespace Loyality.Entities
{
    public class RiderData
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public long Points { get; set; }
        public long TotalCoverDistance { get; set; }
        public string AchievementName { get; set; }


    }
}
