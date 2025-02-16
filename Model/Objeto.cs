using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviGerenciator.Model;

public class Objeto
{
    [Key]
    public int ObjetoId { get; set; }
    public string Descricao { get; set; }
    public string Patrimonio { get; set; }
    [ForeignKey("RemessaId")]
    public int RemessaId { get; set; }
    public virtual Remessa? Remessa {get; set;}
}