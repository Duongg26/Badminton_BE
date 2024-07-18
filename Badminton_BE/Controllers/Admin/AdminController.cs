using Azure.Messaging;
using Badminton_BE.Data;
using Badminton_BE.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Badminton_BE.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
       private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("/GetAll")]
        public IActionResult GetAll()
        {
            var Acc = _context.Accounts.ToList();
            return Ok( Acc );
        }
        [HttpGet("/GetById{id}")]
        public IActionResult GetById(int id) {
            var Acc = _context.Accounts.Find(id);
            if (Acc == null) {
                return BadRequest("Không thấy");
            }
            else {
                return Ok(Acc);
            } 
        }
        [HttpPost("/login")]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                var acc = _context.Accounts.FirstOrDefault(a => a.UName == model.UName && a.Pass == model.Pass);
                if (acc != null&& acc.Role==1)
                {
                   return BadRequest("Thành công");
                    
                }
                return BadRequest("Login fail");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("/UpdateById")]
        public IActionResult UpdateById(int id, AccountViewModel model)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
            {
                return NotFound("Không tìm thấy tài khoản");
            }

            acc.UName = model.UName;
            acc.Status = model.Status;
            acc.Name = model.Name;
            acc.Role = model.Role;
            acc.Addr = model.Addr;

            _context.SaveChanges();

            return Ok("Đã cập nhật thành công");
        }

        [HttpDelete("/DeleteById{id}")]
        public IActionResult DeleteById(int id)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
            {
                return BadRequest("Không tìm thâys");
            }
            _context.Accounts.Remove(acc);
            _context.SaveChanges();
            return BadRequest("Thành công");
        }
        
    }
}
