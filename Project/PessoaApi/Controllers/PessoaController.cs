using Microsoft.AspNetCore.Mvc;
using PessoaApi.Entities;

namespace PessoaApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class PessoaController : ControllerBase
{
    public static List<Pessoa> pessoas;

    public PessoaController()
    {
        if (pessoas == null || pessoas.Count == 0)
            pessoas = new Pessoa().CriarPessoas();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> Get()
    {
        if (pessoas == null)
            return NotFound();

        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<Pessoa> Get(int id)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
            return NotFound();

        return Ok(pessoa);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Pessoa pessoa)
    {
        pessoa.Id = pessoas.Count + 1;
        pessoas.Add(pessoa);

        return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

        if (pessoa == null)
            return NotFound();

        pessoas.Remove(pessoa);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Pessoa pessoa)
    {
        var existingPessoa = pessoas.FirstOrDefault(p => p.Id == id);

        if (existingPessoa == null)
            return NotFound();

        existingPessoa.Nome = pessoa.Nome;
        existingPessoa.Idade = pessoa.Idade;

        return NoContent();
    }

}