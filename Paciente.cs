using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Paciente : Pessoa
    {
        public string CPF { get; set; }
        public string PlanoSaude { get; set; }
        
        public Paciente(string nome, int idade, string genero,string telefone, string cpf,string planoSaude) : base(nome, idade,genero, telefone)
        {
            CPF = cpf;
            PlanoSaude = planoSaude;
        }
        public override void Apresentar()
        {
            Console.WriteLine($"===============Paciente===============\n" +
                $"Nome: {Nome}\n" +
                $"Idade: {Idade}\n" +
                $"Gênero: {Genero}\n" +
                $"Telefone: {Telefone}\n" +
                $"CPF: {CPF}\n" +
                $"Plano de Saúde: {PlanoSaude}\n" +
               $"=====================================");
        }
    }
}
