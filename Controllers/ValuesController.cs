using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioAPI
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<Pessoa> pessoas = new List<Pessoa>();
        private static readonly List<Telefone> telefones = new List<Telefone>();

        [HttpPost]
        public IActionResult Save(Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            return Ok("Adicionado com sucesso!");
        }
        [HttpGet]
        public IActionResult GatByName(string nome)
        {
            var resultado = pessoas.Where(x => x.Nome.Contains(nome));
            if(nome == null || !resultado.Any())
            {
                return NotFound(new { mensagem = "Pessoa nao encontrada." });
            }
            return Ok(new { resultado });
        }
    }
    
}
