using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniDemo.Model
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }
    }

}
