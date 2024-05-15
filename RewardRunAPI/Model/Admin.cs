using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RewardRunAPI.Model
{
    [Table("admin")]
    public class Admin
    {

        [Key]
        public int idadmin {  get; set; }
        
        public string admin {  get; set; }

        public string password { get; set; }

        public Admin(string admin, string password)
        {

            this.admin = admin;
            this.password = password;
        }
    }
}
