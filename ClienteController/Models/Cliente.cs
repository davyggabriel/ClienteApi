using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace ClienteController.Models
{
    public class Cliente
    {
        [MaxLength(255,ErrorMessage = "Máximo 255 caracteres")]
        public string Nome { get; set; }

        public Idade DataNascimento { get; set; }

        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Formato do E-mail Inválido")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "Cpf mínimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Cpf máximo 11 caracteres")]
        public string Cpf { get; set; }

        public Cliente(string nome, Idade dataNascimento, string email, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Cpf = cpf;
        }

        public bool ValidacaoIdade()
        {
            //int anoAtual = DateTime.UtcNow.Year;
            //int mesAtual = DateTime.UtcNow.Month;
            //int diaAtual = DateTime.UtcNow.Day;
            //var calculo = (365 * anoAtual + 30 * mesAtual + diaAtual) - (365 * this.DataNascimento.Ano + 30 * this.DataNascimento.Mes + this.DataNascimento.Dia);
            //var idade = calculo / 365;

            //if (idade >= 18)
            //{
            //    return true;
            //}
            //else return false;
            int idade = DateTime.Now.Year - DataNascimento.Ano;
            if (idade >= 18)
                return true;

            return false;
        }
    }
}
