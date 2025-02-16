using Microsoft.AspNetCore.Mvc;
using EnviGerenciator.Data;
using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Controller;

[ApiController]
[Route("filial")]
public class FilialController : ControllerBase
{
    private ObjetoContext _context;
    private IMapper _mapper;

    public FilialController(ObjetoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastraFilial([FromBody] CreateFilialDto filialDto)
    {
        Filial filial = _mapper.Map<Filial>(filialDto);
        if (filial == null) return NotFound();
        _context.Add(filial);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IEnumerable<ReadFilialDto> BuscaFilial()
    {
        return _mapper.Map<List<ReadFilialDto>>(_context.filiais.ToList());
    }

    [HttpGet("{estado}")]
    public IActionResult BuscaFilialId(string estado)
    {
        var filial = _context.filiais.FirstOrDefault(fil => fil.Estado == estado);
        if (filial == null) return NotFound();
        return Ok(filial);
    }

    [HttpPut]
    public IActionResult AtualizaFilial(int id, [FromBody] CreateFilialDto filialDto)
    {
        var filial = _context.filiais.FirstOrDefault(fil => fil.FilialId == id);
        if (filial == null) return NotFound();
        _mapper.Map(filialDto, filial);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult Deletefilial(int id)
    {
        var filial = _context.filiais.FirstOrDefault(fil => fil.FilialId == id);
        if (filial == null) return NotFound();
        _context.Remove(filial);
        _context.SaveChanges();
        return NoContent();
    }

}