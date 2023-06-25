using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class PacienteCrud
    {
        private Hospital hospital;

        public PacienteCrud(Hospital hospital)
        {
            this.hospital = hospital;
        }
        public void AdicionarPaciente(Paciente paciente)
        {
            hospital.Pacientes.Add(paciente);
        }
        public void RemoverPaciente(Paciente paciente)
        {
            hospital.Pacientes.Remove(paciente);
        }
        public void ListarPaciente()
        {
            Console.WriteLine("Pacientes do Hospital");
            foreach (Paciente paciente in hospital.Pacientes)
            {
                paciente.Apresentar();
            }
        }
        public Paciente ProcuraPaciente(string nome)
        {
            return hospital.Pacientes.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        public void AlterarUmPaciente()
        {
            Console.WriteLine("Digite o nome Do Paciente Para Fazer a alteração");
            string buscaPaciente = Console.ReadLine();
            Paciente pacienteEntrado = ProcuraPaciente(buscaPaciente);

            if (buscaPaciente != null)
            {
                if (pacienteEntrado != null)
                {

                    Console.WriteLine($"Informe os Dados do Paciente {pacienteEntrado.Nome}");
                    Console.WriteLine();
                    Console.WriteLine("Novo Nome (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    string novoNome = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoNome))
                        pacienteEntrado.Nome = novoNome;

                    Console.WriteLine("Nova Idade (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novaIdadeStr = Console.ReadLine();
                    if (!int.TryParse(novaIdadeStr, out int novaIdade))
                    {
                        Console.WriteLine(" Idade invalido Idade não sera atualizado");
                    }
                    else
                    {
                        pacienteEntrado.Idade = novaIdade;

                    }

                    Console.WriteLine($"Novo Plano De Saúde (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoPlanoSaude = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoPlanoSaude))
                        pacienteEntrado.PlanoSaude = novoPlanoSaude;

                    Console.WriteLine($"Nova Genero (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoGenero = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoGenero))
                        pacienteEntrado.Genero = novoGenero;

                    Console.WriteLine("Novo CPF  (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoCPF = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoCPF))
                        pacienteEntrado.CPF = novoCPF;

                    Console.WriteLine("Novo Telefone (DEIXE OS ESPAÇOES EM BRANCO PARA MANTER OS DADOS JÁ EXISTENTES)");
                    Console.WriteLine();
                    string novoTelefone = Console.ReadLine();
                    if (!string.IsNullOrEmpty(novoTelefone))
                        pacienteEntrado.Telefone = novoTelefone;

                }
                else
                {
                    Console.WriteLine("Médico não Encontrado");

                }
            }
        }
    }
}
