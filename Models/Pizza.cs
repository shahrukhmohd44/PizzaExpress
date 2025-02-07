using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaExpress.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
