using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class MedicoCrud
    {
        private Hospital hospital;

        public MedicoCrud(Hospital hospital)
        {
            this.hospital = hospital;
        }
        public void AdcionarMedico(Medico medico)
        {
            hospital.Medicos.Add(medico);
        }
        public void RemoverMedico(Medico medico)
        {
            hospital.Medicos.Remove(medico);
        }
        public void ListarMedicos()
        {
            Console.WriteLine("Lista de medicos do Hospital");

            foreach (Medico medico in hospital.Medicos)
            {
                medico.Apresentar();
            }
        }
        public Medico ProcurarMedico(string nome)
        {
            return hospital.Medicos.Find(m => m.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        public void AlterarUmMedico()
        {
            Console.WriteLine("Digite o nome Do Medico Para Fazer a alteração");
            string buscaMedico = Console.ReadLine();
            Medico medicoEntrado = ProcurarMedico(buscaMedico);

            if (buscaMedico != null)
            {
                if (medicoEntrado != null)
                {

                    Console.WriteLine($"Informe os Dados do medico {medicoEntrado.Nome}");
                    Console.WriteLine();
                    Console.WriteLine("Novo Nome (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    string novoNome = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoNome))
                        medicoEntrado.Nome = novoNome;

                    Console.WriteLine("Nova Idade (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novaIdadeStr = Console.ReadLine();
                    if (!int.TryParse(novaIdadeStr, out int novaIdade))
                    {
                        Console.WriteLine(" Idade invalido Idade não sera atualizado");
                    }
                    else
                    {
                        medicoEntrado.Idade = novaIdade;

                    }

                    Console.WriteLine($"Nova Especialidade (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novaEspecialidade = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novaEspecialidade))
                        medicoEntrado.Especialidade = novaEspecialidade;

                    Console.WriteLine($"Nova Genero (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoGenero = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoGenero))
                        medicoEntrado.Genero = novoGenero;

                    Console.WriteLine("Nova o CRN  (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoCRN = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoCRN))
                        medicoEntrado.CRN = novoCRN;

                    Console.WriteLine("Novo Telefone (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoTelefone = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoTelefone))
                        medicoEntrado.Telefone = novoTelefone;

                    Console.WriteLine("Novo Salário (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoSalarioStr = Console.ReadLine();
                    if (!double.TryParse(novoSalarioStr, out double novoSalario))
                    {
                        Console.WriteLine(" valor invalido Salario não sera atualizado");
                    }
                    else
                    {
                        medicoEntrado.Salario = novoSalario;

                    }
                    Console.WriteLine("Alteração Realizada Com Sucesso !!!");
                }
                else
                {
                    Console.WriteLine("Médico não Encontrado");

                }
            }
        }
    }
}
