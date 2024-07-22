using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Badminton_BE.Data;
using Badminton_BE.Models;
using Badminton_BE.Models.ViewModel;

namespace Badminton_BE.Controllers.Admin
{
    public static class HashingHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
              
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/GetAllAcc")]
        public IActionResult GetAll(int page = 1, int pageSize = 5)
        {
            
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 5;
            var totalCount = _context.Accounts.Count();
           
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (page > totalPages) page = totalPages;
            var accounts = _context.Accounts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var response = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                Accounts = accounts
            };

            return Ok(response);
        }


        [HttpGet("/GetAccById{id}")]
        public IActionResult GetById(int id)
        {
            var Acc = _context.Accounts.Find(id);
            if (Acc == null)
            {
                return BadRequest("Không thấy");
            }
            else
            {
                return Ok(Acc);
            }
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                var hashedPassword = HashingHelper.ComputeSha256Hash(model.Pass);
                var acc = _context.Accounts.FirstOrDefault(a => a.UName == model.UName && a.Pass == hashedPassword);
                if (acc != null && acc.Role == 1)
                {
                    return Ok("Thành công");
                }
                return BadRequest("Login fail");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/UpdateAccById")]
        public IActionResult UpdateById(int id, AccountViewModel model)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
            {
                return BadRequest("Không tìm thấy tài khoản");
            }

            acc.UName = model.UName;
            acc.Status = model.Status;
            acc.Name = model.Name;
            acc.Role = model.Role;
            acc.Addr = model.Addr;

            _context.SaveChanges();

            return Ok("Đã cập nhật thành công");
        }

        [HttpDelete("/DeleteAccById{id}")]
        public IActionResult DeleteById(int id)
        {
            var acc = _context.Accounts.Find(id);
            if (acc == null)
            {
                return BadRequest("Không tìm thấy");
            }
            _context.Accounts.Remove(acc);
            _context.SaveChanges();
            return Ok("Đã xóa thành công");
        }

        [HttpPost("/AddAccount")]
        public IActionResult AddAccount(AccountViewModel model)
        {
          

            var acc = new Account
            {
                UName = model.UName,
                Status = model.Status,
                Name = model.Name,
                Role = model.Role,
                Addr = model.Addr,
                Pass = HashingHelper.ComputeSha256Hash(model.Pass),
                Pass2 = HashingHelper.ComputeSha256Hash(model.Pass2)
            };

            _context.Accounts.Add(acc);
            _context.SaveChanges();

            return Ok("Tài khoản đã được thêm thành công.");
        }
    }
}
