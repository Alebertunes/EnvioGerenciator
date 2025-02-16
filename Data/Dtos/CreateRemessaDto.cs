using System.ComponentModel.DataAnnotations;
using EnviGerenciator.Model;

public class CreateRemessaDto
{
    public int RemessaId {get; set;}
    public virtual ICollection<Objeto> Objetos { get; set; } = new List<Objeto>();
    public int FilialId { get; set; }
    public virtual Filial? Filial { get; set; }

}