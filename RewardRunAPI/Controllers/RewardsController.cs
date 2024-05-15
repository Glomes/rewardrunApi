using Microsoft.AspNetCore.Mvc;
using RewardRunAPI.Model;
using RewardRunAPI.ViewModel;
using RewardRunAPI.Connections;
using System.Linq;

namespace RewardRunAPI.Controllers
{
    [ApiController]
    [Route("api/v1/Reward")]
    public class RewardController : ControllerBase
    {
        private readonly ConnectionContext _context;

        public RewardController(ConnectionContext context)
        {
            _context = context;
        }

        // POST: api/v1/Reward
        [HttpPost]
        public IActionResult Add(RewardViewModel rewardView)
        {
            var reward = new Rewards(rewardView.reward, rewardView.pts_necessarios);
            _context.rewards.Add(reward);
            _context.SaveChanges();

            return Ok();
        }

        // GET: api/v1/Reward
        [HttpGet]
        public IActionResult Get()
        {
            var rewards = _context.rewards.ToList();
            return Ok(rewards);
        }
        // GET: api/v1/Reward/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var reward = _context.rewards.Find(id);

            if (reward == null)
            {
                return NotFound();
            }

            return Ok(reward);
        }


        // PUT: api/v1/Reward/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, RewardViewModel rewardView)
        {
            var reward = _context.rewards.Find(id);

            if (reward == null)
            {
                return NotFound();
            }

            reward.reward = rewardView.reward;
            reward.pts_necessarios = rewardView.pts_necessarios;

            _context.SaveChanges();

            return Ok(reward);
        }

        // DELETE: api/v1/Reward/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reward = _context.rewards.FirstOrDefault(r => r.idreward == id);

            if (reward == null)
            {
                return NotFound();
            }

            _context.rewards.Remove(reward);
            _context.SaveChanges();

            return Ok();
        }

    }
}
