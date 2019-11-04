using System.ComponentModel.DataAnnotations;

namespace webAPI.Models {
    
    public class Textile {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Producer { get; set; }
        public string Designer { get; set; }
        public int Year { get; set; }
        public bool Condition { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}