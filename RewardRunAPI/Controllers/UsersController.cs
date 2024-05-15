using Microsoft.AspNetCore.Mvc;
using RewardRunAPI.Model;
using RewardRunAPI.ViewModel;
using RewardRunAPI.Connections;
using System.Linq;

namespace RewardRunAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Users")]
    public class UsersController : ControllerBase
    {
        private readonly ConnectionContext _context;

        public UsersController(ConnectionContext context)
        {
            _context = context;
        }

        // POST: api/v1/Users
        [HttpPost]
        public IActionResult AddUser(UsersViewModel usersView)
        {
            var user = new Users(usersView.user, usersView.pts);
            _context.users.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        // GET: api/v1/Users
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.users.ToList();
            return Ok(users);
        }

        // GET: api/v1/Users/6
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.users.FirstOrDefault(u => u.iduser == id);
            if (user == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado
            }
            return Ok(user);
        }

        // DELETE: api/v1/Users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado
            }

            _context.users.Remove(user);
            _context.SaveChanges();

            return Ok(); // Retorna 200 OK se o usuário for excluído com sucesso
        }

        // PUT: api/v1/Users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UsersViewModel usersView)
        {
            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado
            }

            user.pts = usersView.pts;

            _context.SaveChanges();

            return Ok(user);
        }

        // PUT: api/v1/Users/{id}/UpdatePoints
        [HttpPut("{id}/UpdatePoints")]
        public IActionResult UpdateUserPoints(int id, UsersViewModel usersView)
        {
            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado
            }

            // Adiciona os pontos recebidos aos pontos existentes do usuário
            user.pts += usersView.pts;

            _context.SaveChanges();

            return Ok(user);
        }
    }
}
