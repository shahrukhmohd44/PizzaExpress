using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaExpress.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
