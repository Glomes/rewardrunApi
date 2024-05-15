using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RewardRunAPI.Model
{
    [Table("tasks")]
    public class Tasks
    {
        [Key]
        public int Idtasks { get; set; }

        public string Task { get; set; }

        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dataentrega { get; set; }

        public int Pts { get; set; }

        public Tasks(string task, string descricao, DateTime dataentrega, int pts)
        {
            this.Task = task;
            this.Descricao = descricao;
            this.Dataentrega = dataentrega.Date;
            this.Pts = pts;



        }
    }
}
