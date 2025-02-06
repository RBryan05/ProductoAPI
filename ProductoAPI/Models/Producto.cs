using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Producto")]
public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    public decimal Precio { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Stock { get; set; }
}