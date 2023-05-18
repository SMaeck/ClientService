using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clientes.Infrastructure.Entities;

public partial class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Cuil { get; set; }
    public string TipoDocumento { get; set; }
    public int NroDocumento { get; set; }
    public bool? EsEmpleadoBna { get; set; }
    public string? PaisOrigen { get; set; }
}
