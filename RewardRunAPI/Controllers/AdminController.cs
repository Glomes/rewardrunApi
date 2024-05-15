using Microsoft.AspNetCore.Mvc;
using RewardRunAPI.Model;
using RewardRunAPI.ViewModel;
using RewardRunAPI.Connections;
using System.Linq;

namespace RewardRunAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ConnectionContext _context;

        public AdminController(ConnectionContext context)
        {
            _context = context;
        }

        // POST: api/v1/Admin
        [HttpPost]
        public IActionResult AddAdmin(AdminViewModel adminView)
        {
            var admin = new Admin(adminView.admin, adminView.password);
            _context.admins.Add(admin);
            _context.SaveChanges();

            return Ok();
        }

        // GET: api/v1/Admin
        [HttpGet]
        public IActionResult GetAdmins()
        {
            var admins = _context.admins.ToList();
            return Ok(admins);
        }

        // PUT: api/v1/Admin/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, AdminViewModel adminView)
        {
            var admin = _context.admins.Find(id);

            if (admin == null)
            {
                return NotFound();
            }

            admin.admin = adminView.admin;
            admin.password = adminView.password;

            _context.SaveChanges();

            return Ok(admin);
        }

        // DELETE: api/v1/Admin/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            var admin = _context.admins.Find(id);

            if (admin == null)
            {
                return NotFound();
            }

            _context.admins.Remove(admin);
            _context.SaveChanges();

            return Ok();
        }
    }
}
