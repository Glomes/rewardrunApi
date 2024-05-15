using Microsoft.AspNetCore.Mvc;
using RewardRunAPI.Model;
using RewardRunAPI.ViewModel;
using RewardRunAPI.Connections;
using System.Linq;

namespace RewardRunAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ConnectionContext _context;

        public TasksController(ConnectionContext context)
        {
            _context = context;
        }

        // POST: api/v1/Tasks
        [HttpPost]
        public IActionResult Add(TasksViewModel tasksView)
        {
            var task = new Tasks(
                tasksView.Task,
                tasksView.Descricao,
                tasksView.Dataentrega,
                tasksView.Pts
            );

            _context.tasks.Add(task);
            _context.SaveChanges();

            return Ok();
        }

        // GET: api/v1/Tasks
        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _context.tasks.ToList();
            return Ok(tasks);
        }

        // GET: api/v1/Tasks/{id}
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _context.tasks.FirstOrDefault(t => t.Idtasks == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }


        // DELETE: api/v1/Tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _context.tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.tasks.Remove(task);
            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/v1/Tasks/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, TasksViewModel tasksView)
        {
            var task = _context.tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            task.Task = tasksView.Task;
            task.Descricao = tasksView.Descricao;
            task.Dataentrega = tasksView.Dataentrega;
            task.Pts = tasksView.Pts;

            _context.SaveChanges();

            return Ok(task);
        }
    }
}
    