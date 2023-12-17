
using ESPDumpsterWebAppAPI.Data;
using Microsoft.EntityFrameworkCore;
using ESPDumpsterWebAppAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESPDumpsterWebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESPPostController : ControllerBase
    {
        private readonly ESPPostContext _context;

        public ESPPostController(ESPPostContext context)
        {
            _context = context;
        }

        // GET: api/ESPPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ESPPostAPIModel>>> GetEspPost()
        {
          if (_context.EspPostViewModel == null)
          {
              return NotFound();
          }
            return await _context.EspPostViewModel.ToListAsync();
        }

        // GET: api/ESPPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ESPPostAPIModel>> GetESPPostViewModel(int id)
        {
          if (_context.EspPostViewModel == null)
          {
              return NotFound();
          }
            var eSPPostViewModel = await _context.EspPostViewModel.FindAsync(id);

            if (eSPPostViewModel == null)
            {
                return NotFound();
            }

            return eSPPostViewModel;
        }

        // PUT: api/ESPPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutESPPostViewModel(int id, ESPPostAPIModel eSPPostViewModel)
        {
            if (id != eSPPostViewModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(eSPPostViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ESPPostViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ESPPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ESPPostAPIModel>> PostESPPostViewModel(ESPPostAPIModel eSPPostViewModel)
        {
            if (_context.EspPostViewModel == null)
            { 
                return Problem("Entity set 'ESPPostContext.EspPost'  is null."); 
            }
    
            eSPPostViewModel.TimeStamp = DateTime.Now;
    
            // Assuming Level is an integer. Convert it to int if it's string.
            if (eSPPostViewModel.Level > 60)
            {
                eSPPostViewModel.LevelString = "High";
                eSPPostViewModel.LevelStringColor = "danger";
            }
            else if (eSPPostViewModel.Level > 30)
            {
                eSPPostViewModel.LevelString = "Medium";
                eSPPostViewModel.LevelStringColor = "warning";
            }
            else
            {
                eSPPostViewModel.LevelString = "Low";
                eSPPostViewModel.LevelStringColor = "secondary";
            }

            _context.EspPostViewModel.Add(eSPPostViewModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetESPPostViewModel", new { id = eSPPostViewModel.Id }, eSPPostViewModel);
        }

        // DELETE: api/ESPPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteESPPostViewModel(int id)
        {
            if (_context.EspPostViewModel == null)
            {
                return NotFound();
            }
            var eSPPostViewModel = await _context.EspPostViewModel.FindAsync(id);
            if (eSPPostViewModel == null)
            {
                return NotFound();
            }

            _context.EspPostViewModel.Remove(eSPPostViewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ESPPostViewModelExists(int id)
        {
            return (_context.EspPostViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
