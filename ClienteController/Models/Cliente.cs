using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace ClienteController.Models
{
    public class Cliente
    {
        [MaxLength(255,ErrorMessage = "Máximo 255 caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Formato do E-mail Inválido")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "Cpf mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Cpf máximo 11 caracteres")]
        public string Cpf { get; set; }

        public Cliente(string nome, DateTime dataNascimento, string email, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Cpf = cpf;
        }

        public bool ValidacaoIdade()
        {
            var dataAtual = DateTime.UtcNow;
            var idade = dataAtual - this.DataNascimento;
            var anos = idade.TotalDays;

            if (anos >= 6570)
            {
                return true;
            }
            else return false;
        }
    }
}
