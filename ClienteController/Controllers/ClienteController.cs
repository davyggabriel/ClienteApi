using ClienteController.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public static List<Cliente> clientes = new List<Cliente>();
        [HttpPost("Cadastrar")]
        public void Cadastrar([FromBody] Cliente cliente)
        {

        }

        [HttpGet("Listar")]
        public List<Cliente> Listar()
        {

        }

        [HttpGet("Buscar por CPF")]
        public List<Cliente> BuscaPorCpf()
        {

        }

        [HttpPut("Alteração de Cadastro")]
        public void AlteracaoDeCadastro()
        {

        }

        [HttpDelete("Deletar Cadastro")]
        public void Deletar()
        {

        }

    }
}
