using Loyality.DbContextApplication;
using Loyality.Entities;
using Loyality.Enumiration;
using Loyality.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loyality.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRiderService _riderService;
        //private readonly pointInterface _db;

        public HomeController(ApplicationDbContext _context, IRiderService _riderService)
        {
            this._context = _context;
            this._riderService = _riderService;
        }

        // GET: api/riders/{id}
        [HttpGet("GetRider")]
        public async Task<ActionResult<RiderData>> GetRider(int id)
        {
            var rider = await _context.riders.FindAsync(id);

            if (rider == null)
            {
                return NotFound();
            }

            return Ok(rider);
        }

        // POST: api/riders
        [HttpPost("CreateRider")]
        public async Task<ActionResult<RiderData>> CreateRider(RiderData riderData)
        {
            // Set the initial achievement name based on points
            riderData.AchievementName = GetAchievementName(riderData.Points);

            _context.riders.Add(riderData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRider", new { id = riderData.Id }, riderData);
        }

        // PUT: api/riders/{id}
        [HttpPut("UpdateRider")]
        public async Task<IActionResult> UpdateRider(int id,RiderData riderData)
        {
            if (id != riderData.Id)
            {
                return BadRequest();
            }

            var existingRider = await _context.riders.FindAsync(id);

            if (existingRider == null)
            {
                return NotFound();
            }

            // Update rider's data
            existingRider.Name = riderData.Name;
            existingRider.Points = riderData.Points;
            existingRider.TotalCoverDistance = riderData.TotalCoverDistance;
            existingRider.AchievementName = GetAchievementName(riderData.Points);

          
                await _context.SaveChangesAsync();

            
                return Ok(existingRider);
        }

        // Helper method to determine AchievementName based on points
        private string GetAchievementName(long points)
        {
            if (points >= 0 && points < 100)
            {
                return PrivateConst.Silver;
            }
            else if (points >= 100 && points < 500)
            {
                return PrivateConst.Gold;
            }
            else if (points >= 500)
            {
                return PrivateConst.Diamond;
            }
            else
            {
                return PrivateConst.NotFound;
            }
        }


        [HttpGet("getByIds")]
        public async Task<ActionResult<List<RiderData>>> GetByIds([FromQuery] List<int>? ids)
        {
            try
            {
                List<RiderData> riders = await _riderService.GetById(ids);

                if (riders == null || riders.Count == 0)
                {
                    return NotFound(); // Return a 404 response if no riders were found.
                }

                return Ok(riders); // Return the list of riders as a successful response.
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response if necessary.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}
      
