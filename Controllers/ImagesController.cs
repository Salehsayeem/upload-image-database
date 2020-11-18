using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BinaryImage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BinaryImage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly UploadImageContext _context;

        public ImagesController(UploadImageContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblImage>>> GetAll()
        {
            return await _context.TblImages.ToListAsync();
        }

        //[HttpGet("{id}")]
        //public FileContentResult GetById(int id)
        //{
        //    return File(_context.TblImages.First(m => m.Id == id).Image, MediaTypeNames.Image.Jpeg);
        //    //return _context.TblImages.FirstOrDefault(m=>m.Id == id);
        //}
    }
}
