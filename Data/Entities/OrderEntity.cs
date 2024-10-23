using Pizzeria.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Data.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string CustomerName { get; set; }
        [Required]
        public required string CustomerPhone { get; set; }
        [Required]
        public required string CustomerAddress { get; set; }
        [Required]
        public required string PizzaType { get; set; }
        [Required]
        public required string Toppings { get; set; }
        [Required]
        public required string PizzaSize { get; set; }
        [Required]
        public required string Status { get; set; }
    }
}