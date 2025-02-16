using EnviGerenciator.Model;

public class ReadRemessaDto
{
    public int RemessaId {get; set;}
    
    public virtual ICollection<Objeto> Objetos { get; set; } = new List<Objeto>();
}