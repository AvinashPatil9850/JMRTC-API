using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msrtc_api.Data;
using msrtc_api.Entities;

namespace msrtc_api.Controllers
{
    public class StopsController : Controller
    {
        public readonly MsrtcContext _context;
        public StopsController(MsrtcContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllStopsListArray")]

        //public async Task<ActionResult<StopsListModel>> GetAllStopsList()
        //{
        //    return Ok(await _context.StopsListModel.ToListAsync());
        //}
        public async Task<ActionResult<IEnumerable<StopsListModel>>> GetAllStopsList()
        {
            try
            {

                var list = from s in _context.StopsListModel
                           join sa in _context.StopDetail on s.RouteID equals sa.RouteID
                           select  new
                           {
                               s.RouteID,
                               s.BusDepo,
                               s.Source,
                               s.Destination,
                               sa.StopID,
                               sa.StopName
                           };
                       return Ok(list.Distinct());
               // return await _context.StopsListModel.Include(x => x.StopsList).ToListAsync();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddStops")]
        public async Task<IActionResult> AddStops([FromBody] StopsListModel stopsListModel)
        {
            try
            {
                var existingRoute = _context.StopsListModel
              .Where(p => (p.BusDepo == stopsListModel.BusDepo 
              && p.Source == stopsListModel.Source 
              && p.Destination == stopsListModel.Destination))
              .Include(p => p.StopsList)
              .FirstOrDefault();
                if(existingRoute != null)
                {
                    existingRoute.StopsList.AddRange(stopsListModel.StopsList);
                } else
                {
                    _context.StopsListModel.Add(stopsListModel);
                }
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [Route("DeleteStops")]
        public async Task<IActionResult> DeleteStops([FromBody] DeleteStops deleteStop)
        {
            try
            {
                var stops = await _context.StopDetail.Where(a => a.StopID == deleteStop.StopID).FirstOrDefaultAsync();

                if (stops == null)
                {
                    return NotFound();
                }

                _context.StopDetail.Remove(stops);
                await _context.SaveChangesAsync();
                // if (result == 0) return BadRequest(" delete error");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
            return Ok();

        }

    }
}
