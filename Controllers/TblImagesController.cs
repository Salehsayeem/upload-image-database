using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BinaryImage.Models;

namespace BinaryImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblImagesController : ControllerBase
    {
        private readonly UploadImageContext _context;

        public TblImagesController(UploadImageContext context)
        {
            _context = context;
        }

        // GET: api/TblImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblImage>>> GetTblImages()
        {
            return await _context.TblImages.ToListAsync();
        }

        // GET: api/TblImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblImage>> GetTblImage(int id)
        {
            var tblImage = await _context.TblImages.FindAsync(id);

            if (tblImage == null)
            {
                return NotFound();
            }

            return tblImage;
        }

        // PUT: api/TblImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblImage(int id, TblImage tblImage)
        {
            if (id != tblImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblImageExists(id))
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

        // POST: api/TblImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblImage>> PostTblImage(TblImage tblImage)
        {
            _context.TblImages.Add(tblImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblImage", new { id = tblImage.Id }, tblImage);
        }

        // DELETE: api/TblImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblImage>> DeleteTblImage(int id)
        {
            var tblImage = await _context.TblImages.FindAsync(id);
            if (tblImage == null)
            {
                return NotFound();
            }

            _context.TblImages.Remove(tblImage);
            await _context.SaveChangesAsync();

            return tblImage;
        }

        private bool TblImageExists(int id)
        {
            return _context.TblImages.Any(e => e.Id == id);
        }
    }
}
