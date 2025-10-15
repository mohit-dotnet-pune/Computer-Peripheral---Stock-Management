using System.ComponentModel.DataAnnotations;

namespace Computer_Peripheral___Stock_Management.Model
{
    public class Peripheral
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
