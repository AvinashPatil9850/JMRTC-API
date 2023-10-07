using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msrtc_api.Data;
using msrtc_api.Entities;

namespace msrtc_api.Controllers
{
    public class DestinationController : Controller
    {
        public readonly MsrtcContext _context;
        public DestinationController(MsrtcContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllDestinationList")]
        

        public async Task<ActionResult<IEnumerable<DestinationModal>>> GetAllDestinationList()
        {
            try
            {
                var list = from d in _context.DestinationModal
                           join ds in _context.DestinationArr on d.DepoID equals ds.DepoID
                           select new
                           {
                               d.DepoID,
                               d.BusDepo,
                               ds.Destination,
                               ds.DestinationID
                           };
                return Ok(list);

            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("GetDestinationArr")]
        public async Task<ActionResult<IEnumerable<DestinationArr>>> GetDestinationArr()
        {
            return Ok(await _context.DestinationArr.ToListAsync());
        }


        [HttpPost]
        [Route("AddDestination")]
        public async Task<IActionResult> AddDestination([FromBody] DestinationModal destinationModal)
        {
            try
            {
                var existingParent = _context.DestinationModal
                .Where(p => p.BusDepo == destinationModal.BusDepo)
                .Include(p => p.DestinationArr)
                .FirstOrDefault();

                if (existingParent != null)
                {
                    existingParent.DestinationArr.AddRange(destinationModal.DestinationArr);
                }
                else
                {
                    _context.DestinationModal.Add(destinationModal);
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
        [Route("UpdateDestination")]
        public async Task<IActionResult> UpdateDestination([FromBody] DestinationModal model)
        {
            try
            {

                var existingParent = _context.DestinationModal
                .Where(p => p.BusDepo == model.BusDepo)
                .Include(p => p.DestinationArr)
                .SingleOrDefault();

                if (existingParent != null)
                {
                    // Update parent
                    _context.Entry(existingParent).CurrentValues.SetValues(model);

                    // Delete children
                    //foreach (var existingChild in existingParent.DestinationArr.ToList())
                    //{
                    //    if (!model.DestinationArr.Any(c => c.d == existingChild.Id))
                    //        _dbContext.Children.Remove(existingChild);
                    //}

                    // Update and Insert children
                    foreach (var childModel in model.DestinationArr)
                    {

                        // Insert child
                        var newChild = new DestinationArr
                        {
                            Destination = childModel.Destination,
                            //...
                        };
                        existingParent.DestinationArr.Add(newChild);

                    }

                await _context.SaveChangesAsync();
                }


                return Ok();
            }
            catch (Exception ex)
            {
              return  this.StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("DeleteDestinatoin")]
        public async Task<IActionResult> DeleteStops([FromBody] DeleteDestination deleteDestination)
        {
            try
            {
                var destination = await _context.DestinationArr.Where(a => a.DestinationID == deleteDestination.DestinationID).FirstOrDefaultAsync();

                if (destination == null)
                {
                    return NotFound();
                }

                _context.DestinationArr.Remove(destination);
                await _context.SaveChangesAsync();
                // if (result == 0) return BadRequest(" delete error");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
            return Ok();

        }
        [HttpGet]
        [Route("GetAllStopsList")]

        public async Task<ActionResult<IEnumerable<StopDetail>>> GetAllStopsList()
        {
            try
            {
                // return await _context.BusStopsModel.Select(p => p.Stop).Distinct();
                return await _context.StopDetail.Select(x => new StopDetail()
                {
                    StopName = x.StopName
                }).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
        
    }
}
