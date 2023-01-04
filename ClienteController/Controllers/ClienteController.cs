using ClienteController.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ClienteController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public static List<Cliente> clientes = new List<Cliente>();

        [HttpPost("cadastrar")]
        public ActionResult<Cliente> Cadastrar([FromBody] Cliente cliente)
        {
            var usuario = new Cliente(cliente.Nome, cliente.DataNascimento, cliente.Email, cliente.Cpf);

            if (!usuario.ValidacaoIdade())
                return UnprocessableEntity("Menor de idade não cria conta");

            clientes.Add(usuario);
            return Created("", usuario);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            return Ok(clientes);
        }

        [HttpGet("busca-por-cpf/ {cpf}")]
        public ActionResult<Cliente> BuscaPorCpf(string cpf)
        {
            Cliente clienteRetornar = null;
            foreach (Cliente cliente in clientes)
            {
                if(cliente.Cpf == cpf)
                {
                    clienteRetornar = cliente;
                }
            }
            return Ok(clienteRetornar);
        }

        [HttpPut("alteracao-cadastro/ {cpf}")]
        public ActionResult AlteracaoDeCadastro(string cpf, [FromBody] Cliente cliente)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Cpf == cpf)
                {
                    clientes[i].Email = cliente.Email;
                    clientes[i].Cpf = cliente.Cpf;
                    clientes[i].Nome = cliente.Nome;
                    clientes[i].DataNascimento = cliente.DataNascimento;
                }
            }
            return Accepted();
        }

        [HttpDelete("deletar-cadastro/ {cpf}")]
        public ActionResult Deletar(string cpf)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Cpf == cpf)
                {
                    clientes.Remove(clientes[i]);
                }
            }
            return Accepted();
        }
    }
}
