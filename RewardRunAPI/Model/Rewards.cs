
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RewardRunAPI.Model
{

    [Table("rewards")]
    public class Rewards
    {

        [Key]
        public int idreward { get;  set; }

        public string reward { get;  set; }

        public int pts_necessarios { get;  set; }

        public Rewards(string reward, int pts_necessarios)
        {

            this.reward = reward;
            this.pts_necessarios = pts_necessarios;
        }
    }
}
