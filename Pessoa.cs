using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hospital
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }

        public Pessoa(string nome,int idade,string genero,string telefone)
        {
            Nome = nome;
            Idade = idade;
            Genero = genero;
            Telefone = telefone;
        }
        public abstract void Apresentar();
    }
}
