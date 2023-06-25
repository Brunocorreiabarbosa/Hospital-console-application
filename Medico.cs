using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Medico : Pessoa
    {
        
        public string CRN { get; set; }
        public string Especialidade { get; set; }
        public double Salario { get; set; }

        public Medico(string nome, int idade, string genero,string telefone, string crn, string especialidade,double salario) : base(nome, idade, genero,telefone)
        {
            CRN = crn;
            Especialidade = especialidade;
            Salario = salario;
        }
        public override void Apresentar()
        {
            Console.WriteLine($"===============Medico===============\n" +
                 $"Nome: {Nome}\n" +
                 $"Idade: {Idade}\n" +
                 $"Gênero: {Genero}\n" +
                 $"Telefone: {Telefone}\n"+
                 $"CRN: {CRN}\n" +
                 $"Especialidade: {Especialidade}\n" +
                 $"Salario: R$:{Salario}\n" +
                 $"=====================================");
        }
    }
    
}
