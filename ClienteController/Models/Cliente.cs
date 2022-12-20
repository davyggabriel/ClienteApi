using System.Reflection.Metadata.Ecma335;

namespace ClienteController.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public Idade DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public Cliente(string nome, Idade dataNascimento, string email, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Cpf = cpf;
        }

        public bool ValidacaoNome()
        {

        }

        public bool ValidacaoIdade()
        {

        }

        public bool ValidacaoEmail()
        {

        }

        public bool ValidacaoCpf()
        {

        }
    }
}
