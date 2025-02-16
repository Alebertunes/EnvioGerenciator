using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EnviGerenciator.Model;
namespace EnviGerenciator.Model;
public class Remessa
{
    [Key]
    public int RemessaId {get; set;}
    public virtual ICollection<Objeto> Objetos { get; set; } = new List<Objeto>();
    [ForeignKey("FilialId")]
    public int FilialId { get; set; }
    public virtual Filial Filial { get; set; }
}


