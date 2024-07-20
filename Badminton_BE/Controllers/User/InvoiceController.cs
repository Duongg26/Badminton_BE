using Badminton_BE.Data;
using Microsoft.AspNetCore.Mvc;

namespace Badminton_BE.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly DataContext _context;
        public InvoiceController(DataContext context)
        {
            _context = context;
        }
        //[HttpGet("/GetInvoiceById")]
        //public IActionResult GetInvoiceByAccountId(int accountId)
        //{
        //    var invoices = _context.Invoices.Where(i => i.AccountId == accountId).ToList();
        //    if (invoices == null || !invoices.Any())
        //    {
        //        return NotFound("Không tìm thấy hóa đơn cho tài khoản này");
        //    }
        //    return Ok(invoices);
        //}
    
    }
}
