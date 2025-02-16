using EnviGerenciator.Model;

namespace EnviGerenciator.Dto;

public class CreateObjetoDto
{
    public string Descricao { get; set; }
    public string Patrimonio { get; set; }
    public int RemessaId { get; set; }
    public virtual Remessa? Remessa {get; set;}
}