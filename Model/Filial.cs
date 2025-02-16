using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnviGerenciator.Model;

public class Filial
{
    [Key]
    public int FilialId { get; set; }
    public string Estado { get; set; }
    public string Rua { get; set; }
    public string Cep { get; set; }
    public int Numero { get; set; }
    public ICollection<Remessa> Remessas {get; set;}
}