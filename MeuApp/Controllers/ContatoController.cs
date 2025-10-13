using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuApp.Context;
using MeuApp.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MeuApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContexto _context;
        public ContatoController(AgendaContexto contexto)
        {
            _context = contexto;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }

        //Get obter numero por Id
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }


        //Get obter numero por Nome
        [HttpGet("ObterporNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome != null && x.Nome.Contains(nome))
            .ToList();

            return Ok(contatos);
        }

        //Put atualizar numero por Id
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();

            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);

            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        //Deletar numero por Id
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}