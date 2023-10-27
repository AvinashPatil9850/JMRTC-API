using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using msrtc_api.Data;
using msrtc_api.Entities;

namespace msrtc_api.Controllers
{
    public class DepoController : Controller
    {
        public readonly MsrtcContext _context;
        public DepoController(MsrtcContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllDepoList")]


        public async Task<ActionResult<BusDepoModal>> GetAllDepoList()
        {
            try
            {
                return Ok(await _context.BusDepoDetail.Distinct().ToListAsync());
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
 

        [HttpPost]
        [Route("AddDepo")]
        public async Task<IActionResult> AddDepo([FromBody] BusDepoModal busDepoModal)
        {

            try
            {
                var isExist = _context.BusDepoDetail
                .Where(p => p.BusDepo == busDepoModal.BusDepo).FirstOrDefault();

                if (isExist != null)
                {
                    return this.StatusCode(500, "Already Exist");
                }
                else
                {
                    _context.BusDepoDetail.Add(busDepoModal);
                }

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }

            //try
            //{
            //    _context.BusDepoDetail.Add(busDepoModal);
            //    await _context.SaveChangesAsync();
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return this.StatusCode(500, ex.Message);
            //}

        }
        
        [HttpPost]
        [Route("DeleteDepo")]
        public async Task<IActionResult> DeleteDepo([FromBody] BusDepoModal busDepoModal)
        {
            try
            {
                var depo = await _context.BusDepoDetail.Where(a => a.DepoID == busDepoModal.DepoID).FirstOrDefaultAsync();

                if (depo == null)
                {
                    return NotFound();
                }

                _context.BusDepoDetail.Remove(depo);
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
