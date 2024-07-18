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

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var yards = _context.Yards.ToList();
            return Ok(yards);
        }

        [HttpPost("/AddYard")]
        public IActionResult AddYard(YardViewModel model)
        {
            var yard = new Yard
            {
            
                YardName = model.Name,
                Price = model.Price,
                YardDescription = model.YardDescription,
                
            };
            _context.Yards.Add(yard);
            _context.SaveChanges();

            return Ok ("Add thành công");
        }
     
    }
}
