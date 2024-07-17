using Badminton_BE.Data;
using Microsoft.AspNetCore.Mvc;

namespace Badminton_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Acc = _context.Accounts.ToList();
            return Ok( Acc );
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var Acc = _context.Accounts.Find(id);
            if (Acc == null) {
                return BadRequest("Không thấy");
            }
            else {
                return Ok(Acc);
            } 
        }
    }
}
