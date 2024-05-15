using System.ComponentModel.DataAnnotations;

namespace RewardRunAPI.ViewModel
{
    public class TasksViewModel
    {
        [Required(ErrorMessage = "O campo 'Tarefa' é obrigatório.")]
        public string Task { get; set; }

        public string? Descricao { get; set; }

        [Display(Name = "Data de Entrega")]
        [Required(ErrorMessage = "O campo 'Data de Entrega' é obrigatório.")]
        [DataType(DataType.Date)] 
        public DateTime Dataentrega { get; set; }

        public int Pts { get; set; }
    }
}
