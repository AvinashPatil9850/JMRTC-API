using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msrtc_api.Data;
using msrtc_api.Entities;

namespace msrtc_api.Controllers
{
    public class MsrtcBusController : Controller
    {
        public readonly MsrtcContext _context;
        public MsrtcBusController(MsrtcContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllBussessList")]
        //public async Task<ActionResult<BussessModel>> GetAllBussessList()
        //{
        //    return Ok(await _context.Bussess.ToListAsync());
        //}

        public async Task<ActionResult<IEnumerable<BussessModel>>> GetAllBussessList()
        {
            try
            {
                return await _context.Bussess.Select(x => new BussessModel()
                {
                    BusID = x.BusID,
                    BusDepo = x.BusDepo,
                    Source = x.Source,
                    Destination = x.Destination,
                    BusTime = x.BusTime,
                    Via = x.Via,
                    BusRoute = x.BusRoute,
                    BusType = x.BusType,
                    Stops = x.Stops,
                    WeekDays = x.WeekDays 
                }).ToListAsync();

            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAllRouteStopList")]
        public async Task<ActionResult<IEnumerable<StopDetail>>> GetAllRouteStopList()
        {
            return Ok(await _context.StopDetail.Select(m=>m.StopName).Distinct().ToListAsync());
        }

        [HttpPost]
        [Route("AddBus")]
        public async Task<IActionResult> AddBus([FromBody] BussessModel bussessModel)
        {
            try
            {

                _context.Bussess.Add(bussessModel);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [Route("DeleteBus")]
        public async Task<IActionResult> DeleteBus([FromBody] DeleteBusRequestModal deleteBus)
        {
            try
            {
                var bus = await _context.Bussess.Include(x=>x.Stops).Include(x=>x.WeekDays).Where(a => a.BusID == deleteBus.BusID).FirstOrDefaultAsync();

                if (bus == null)
                {
                    return NotFound();
                }

                _context.Bussess.Remove(bus);
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
