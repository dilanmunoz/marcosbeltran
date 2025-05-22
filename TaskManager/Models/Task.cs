using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Title { get; set; }
        
        [MaxLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres")]
        public string Description { get; set; }
        
        [Required]
        public Priority Priority { get; set; }
        
        [Required]
        public bool IsCompleted { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
    }
}