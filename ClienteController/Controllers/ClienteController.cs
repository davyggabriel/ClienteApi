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

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Cliente cliente)
        {
            var usuario = new Cliente(cliente.Nome, cliente.DataNascimento, cliente.Email, cliente.Cpf);

            //regras do negócio:
            if (!usuario.ValidacaoIdade())
                return UnprocessableEntity("Menor de idade não cria conta");
            if(!usuario.ValidacaoNome())
                return UnprocessableEntity("O nome pode ter de 1 a 255 caracteres");
            if (!usuario.ValidacaoEmail())
                return UnprocessableEntity("O e-mail para ser válido precisa contem @ e .com");
            if (!usuario.ValidacaoCpf())
                return UnprocessableEntity("O cpf precisa conter 11 caracteres");

            clientes.Add(usuario);
            return Created("", usuario);
        }

        [HttpGet("Listar")]
        public List<Cliente> Listar()
        {
            return clientes;
        }

        [HttpGet("Buscar por CPF")]
        public Cliente BuscaPorCpf(string cpf)
        {
            for(int i = 0; i < clientes.Count; i++)
            {
                if(clientes[i].Cpf == cpf)
                {
                    return clientes[i];
                }
            }
            return null;
        }

        [HttpPut("Alteração de Cadastro")]
        public void AlteracaoDeCadastro(string cpf, [FromBody] Cliente cliente)
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
        }

        [HttpDelete("Deletar Cadastro")]
        public void Deletar(string cpf)
        {
            for (int i = 0; i < clientes.Count; i++)
            {
                if (clientes[i].Cpf == cpf)
                {
                    clientes.Remove(clientes[i]);
                }
            }
        }
    }
}
