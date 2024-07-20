using Badminton_BE.Data;
using Badminton_BE.Models;
using Badminton_BE.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Badminton_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminYardController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminYardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllYard")]
        public ActionResult GetAll()
        {
            var yards = _context.Yards.ToList();
            return Ok(yards);
        }
        [HttpGet("/GetYardById")]
        public ActionResult GetYardById(int id)
        {
            var yards = _context.Yards.Find(id);
            return Ok(yards);
        }

        [HttpPost("/AddYard")]
        public IActionResult AddYard(YardViewModel model)
        {
            var yard = new Yard
            {
            
                YardName = model.YardName,
                Price = model.Price,
                YardDescription = model.YardDescription,
                
            };
            _context.Yards.Add(yard);
            _context.SaveChanges();

            return Ok ("Add thành công");
        }
        [HttpPost("/UpdateYard")]
        public IActionResult UpdateYard(int id, [FromBody] YardViewModel model)
        {
            if (ModelState.IsValid)
            {
                var yard = _context.Yards.Find(id);
                if (yard == null)
                {
                    return BadRequest("Không có sân này");
                }

                yard.YardName = model.YardName;
                yard.Price = model.Price;
                yard.YardDescription = model.YardDescription;
                yard.Status = model.Status;

                _context.SaveChanges();

                return Ok("Cập nhật thành công");
            }
            return BadRequest("Không thành công");
        }
        [HttpDelete("/DeleteYardById")]
        public IActionResult DeleteYard(int id)
        {
            var yard=_context.Yards.Find(id);  
            if (yard == null)
            {
                return NotFound("Không thấy sân");
            }
            _context.Remove(yard);
            _context.SaveChanges();
            return Ok("Xoá thành công");
        }
    }
}
