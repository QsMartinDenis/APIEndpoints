using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIendpoints.Entities
{
    public class Brand
    {
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required, Column(TypeName = "varchar(30)")]
        public string BrandName { get; set; }
    }
}
