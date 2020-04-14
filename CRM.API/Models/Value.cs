using System.ComponentModel.DataAnnotations;

namespace CRM.API.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}