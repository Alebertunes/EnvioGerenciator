using Microsoft.AspNetCore.Mvc;
using EnviGerenciator.Data;
using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Controller;

[ApiController]
[Route("Remessas")]
public class RemessaController : ControllerBase
{
    private ObjetoContext _context;
    private IMapper _mapper;

    public RemessaController(ObjetoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastraRemessa([FromBody] CreateRemessaDto RemessaDto)
    {
        var remessa = _mapper.Map<Remessa>(RemessaDto);
        if (remessa == null) return NotFound();
        _context.Add(remessa);
        _context.SaveChanges();
        return Created();
    }

    [HttpGet]
    public IEnumerable<ReadRemessaDto> BuscaRemessa()
    {
        return _mapper.Map<List<ReadRemessaDto>>(_context.remessas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult BuscaRemessaId(int id)
    {
        var remessa = _context.remessas.FirstOrDefault(obj => obj.RemessaId == id);
        if (remessa == null) return NotFound();
        return Ok(remessa);
    }

    [HttpPut]
    public IActionResult AtualizaRemessa(int id, [FromBody] CreateRemessaDto remessaDto)
    {
        var remessa = _context.remessas.FirstOrDefault(obj => obj.RemessaId == id);
        if (remessa == null) return NotFound();
        _mapper.Map(remessaDto, remessa);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteRemessa(int id)
    {
        var remessa = _context.remessas.FirstOrDefault(obj => obj.RemessaId == id);
        if (remessa == null) return NotFound();
        _context.Remove(remessa);
        _context.SaveChanges();
        return NoContent();
    }

}