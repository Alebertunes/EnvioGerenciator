using Microsoft.AspNetCore.Mvc;
using EnviGerenciator.Data;
using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Controller;

[ApiController]
[Route("objetos")]
public class ObjetoController : ControllerBase
{
    private ObjetoContext _context;
    private IMapper _mapper;

    public ObjetoController(ObjetoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastraObjeto([FromBody] CreateObjetoDto objetoDto)
    {
        var objeto = _mapper.Map<Objeto>(objetoDto);
        if (objeto == null) return NotFound();
        _context.Add(objeto);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IEnumerable<ReadObjetoDto> BuscaObjeto()
    {
        return _mapper.Map<List<ReadObjetoDto>>(_context.objetos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult BuscaObjetoId(int id)
    {
        var objeto = _context.objetos.FirstOrDefault(obj => obj.ObjetoId == id);
        if (objeto == null) return NotFound();
        return Ok(objeto);
    }

    [HttpPut]
    public IActionResult AtualizaObjeto(int id, [FromBody] CreateObjetoDto objetoDto)
    {
        var objeto = _context.objetos.FirstOrDefault(obj => obj.ObjetoId == id);
        if (objeto == null) return NotFound();
        _mapper.Map(objetoDto, objeto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteObjeto(int id)
    {
        var objeto = _context.objetos.FirstOrDefault(obj => obj.ObjetoId == id);
        if (objeto == null) return NotFound();
        _context.Remove(objeto);
        _context.SaveChanges();
        return NoContent();
    }

}