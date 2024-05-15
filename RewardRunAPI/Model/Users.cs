using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RewardRunAPI.Model
{

    [Table("users")]
    public class Users
    {

        [Key]
        public int iduser { get;  set; }

        public string user { get;  set; }

        public int pts { get;  set; }


        public Users(string user, int pts)
        {

            this.user = user;
            this.pts = pts;
        }

    }
}
