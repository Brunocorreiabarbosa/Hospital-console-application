using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class MenuHospital
    {
        public string opcao;
        private Hospital hospital;
        private PacienteCrud pacienteCrud;
        private MedicoCrud medicoCrud;
        private Paciente paciente;
        private Medico medico;

        public MenuHospital()
        {
            hospital = new Hospital();
            pacienteCrud = new PacienteCrud(hospital);
            medicoCrud = new MedicoCrud(hospital);
        }
        public void Execultar()
        {
            do
            {
                Console.WriteLine("       ========== Bem-Vindo ==========");
                Console.WriteLine("================================================");
                Console.WriteLine("" +
                    "= Digite o numero 1 para acidinar Paciente =====\n" +
                    "= Digite o numero 2 para consultar um Paciente =\n" +
                    "= Digite o numero 3 para alterar alguma alguma \n" +
                    "  informaçõa de paciene\n" +
                    "= Digite o numero 4 para remover um paciente ===\n" +
                    "= Digite o numero 5 para listar os pasiente ====\n" +
                    "= Digite o numero 6 para acidinar um medico ====\n" +
                    "= Digite o numero 7 para consultar um medico ===\n" +
                    "= Digite o numero 8 para alterar alguma alguma \n" +
                    "  informaçõa de Medico\n" +
                    "= Digite o numero 9 para remover um medico ====\n" +
                    "= digite o numero 10 para listar os medicos ====");
                Console.WriteLine("================================================");
                Console.WriteLine("");
                Console.Write("Digite uma Opção Desejada:");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        // Adicionar paciente
                        AdicionaPaciente();
                        break;
                    case "2":
                        //consultar Paciente
                        ConsultaPaciente();
                        break;
                    case "3":
                        //Alterar informção Paciente
                        pacienteCrud.AlterarUmPaciente();
                        break;
                    case "4":
                        //Remover paciente
                        RemoverPaciente();
                        break;
                    case "5":
                        // listar paciente
                        pacienteCrud.ListarPaciente();

                        break;
                    case "6":
                        //adicionar medico
                        AdicionarMedico();

                        break;
                    case "7":
                        // consultar medico
                        ConsultarMedico();

                        break;
                    case "8":
                        medicoCrud.AlterarUmMedico();
                        break;
                    case "9":
                        // remover medico
                        RemoverMedico();
                        pacienteCrud.ListarPaciente();
                        break;
                    case "10":
                        //listar medico
                        medicoCrud.ListarMedicos();
                        break;
                }
                Console.WriteLine();
            }
            while (opcao != "0");
        }



        public void AdicionaPaciente()
        {
            //receber os dados
            Console.WriteLine("Digite a Quantidade De Peciente Que Deseja Adicionar");
            int quantidadePas = int.Parse(Console.ReadLine());
            //para determinar quantos pacientes seram cadastrados no sistema
            for (int i = 0; i < quantidadePas; i++)
            {
                Console.WriteLine($"Digite o nome do(a) {i + 1}º paciente:");
                string pacNome = Console.ReadLine();
                Console.WriteLine($"DIgite a Idade do(a) {pacNome}:");
                int pacIdade = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite o genero do(a) {pacNome}:");
                string pacGenero = Console.ReadLine();
                Console.WriteLine($"Digite seu Telefone do(a) {pacNome}:");
                string pacTelefone = Console.ReadLine();
                Console.WriteLine($"Digite o CPF do(a) {pacNome}:");
                string pacCpf = Console.ReadLine();
                Console.WriteLine($"DIgite o Nome Do Plano Ne saúde do(a) {pacNome}: ");
                string pacPlanoSaude = Console.ReadLine();

                // criar um objeto paciente para as informações recebidas
                Paciente paciente = new Paciente(pacNome, pacIdade, pacGenero, pacTelefone, pacCpf, pacPlanoSaude);
                // agora voce adiciona as informações no objeto
                pacienteCrud.AdicionarPaciente(paciente);
            }
        }
        public void ConsultaPaciente()
        {
            Console.WriteLine("Digite o Nome do paciente Para Fazer Busca: ");
            string procuraPaciente = Console.ReadLine();

            /*nesse objeto irei buscar o paciente dentro da minha lista
            se encontra mostra se nao vai pro else*/

            Paciente pacienteEncontrado = pacienteCrud.ProcuraPaciente(procuraPaciente);

            if (pacienteEncontrado != null)
            {
                Console.WriteLine($"==========Paciente Econtrado==========\n" +
                    $"Nome: {pacienteEncontrado.Nome}\n" +
                    $"Idade: {pacienteEncontrado.Idade}\n" +
                    $"Gênero: {pacienteEncontrado.Genero}\n" +
                    $"Telefone: {pacienteEncontrado.Telefone}\n" +
                    $"CPF: {pacienteEncontrado.CPF}\n" +
                    $"Plano De Saude: {pacienteEncontrado.PlanoSaude}");
                Console.WriteLine($"======================================");
            }
            else
            {
                Console.WriteLine("Paciente Nao ENcontrado");
            }
        }
        public void RemoverPaciente()
        {
            // primeiro vamos digitar o nome do paciete e depois vamos procurar
            Console.WriteLine("DIgite O nome Do Paciente que Deseja remover");
            string removePaciente = Console.ReadLine();
            // vamos instanciar um novo objeto 
            Paciente pacienteRemover = pacienteCrud.ProcuraPaciente(removePaciente);

            if (pacienteRemover != null)
            {
                pacienteCrud.RemoverPaciente(pacienteRemover);
                Console.WriteLine("Paciente Removido com Sucesso !!!!");
                pacienteCrud.ListarPaciente();
            }
            else
            {
                Console.WriteLine("Paciente não Encontrado.");
            }
            pacienteCrud.ListarPaciente();
        }
        public void AdicionarMedico()
        {
            //Adicionar dados dos Medicos
            Console.WriteLine("DIgite a Quantidade De Medicos para cadastrar");
            int quantidadeMed = int.Parse(Console.ReadLine());

            //um for para determinar quantos medicos seram cadastrados no sistema
            for (int i = 0; i < quantidadeMed; i++)
            {
                Console.WriteLine($"Digite o nome do(a) {i + 1}º medico:");
                string medNome = Console.ReadLine();
                Console.WriteLine($"DIgite a Idade do(a) {medNome}:");
                int medIdade = int.Parse(Console.ReadLine());
                Console.WriteLine($"Digite o genero do(a) {medNome}: ");
                string medGenero = Console.ReadLine();
                Console.WriteLine($"Digite seu Telefone do(a) {medNome}:");
                string medTelefone = Console.ReadLine();
                Console.WriteLine($"Digite o CRN do(a) {medNome}:");
                string medCrn = Console.ReadLine();
                Console.WriteLine($"DIgite a Especialidade do(a) {medNome}: ");
                string medEspecialidade = Console.ReadLine();
                Console.WriteLine($"DIgite o Salario do(a) {medNome}: ");
                double medSalario = double.Parse(Console.ReadLine());

                // criar um objeto paciente para as informações recebidas
                Medico medico = new Medico(medNome, medIdade, medGenero, medTelefone, medCrn, medEspecialidade, medSalario);
                // adicione as informações no objeto
                medicoCrud.AdcionarMedico(medico);
            }
        }
        public void ConsultarMedico()
        {
            Console.WriteLine("Digite o nome Do Medico Para Fazer a Busca");
            string buscaMedico = Console.ReadLine();

            Medico medicoEntrado = medicoCrud.ProcurarMedico(buscaMedico);
            if (medicoEntrado != null)
            {
                Console.WriteLine($"==========MEdico Econtrado==========\n" +
                    $"Nome: {medicoEntrado.Nome}\n" +
                    $"Idade: {medicoEntrado.Idade}\n" +
                    $"Gênero: {medicoEntrado.Genero}\n" +
                    $"CRN: {medicoEntrado.CRN}\n" +
                    $"Telefone: {medicoEntrado.Telefone}\n" +
                    $"Especialidade {medicoEntrado.Especialidade}\n" +
                    $"Salario: {medicoEntrado.Salario}");
                Console.WriteLine($"======================================");
            }
            else
            {

                Console.WriteLine("Medico Nao ENcontrado");
            }
        }
        public void RemoverMedico()
        {
            // esse comando e para remover o medico se ele estive em nossa lista
            Console.WriteLine("DIgite o nome do medico para ser removido");
            string removemedico = Console.ReadLine();
            //vamos instanciar um novo objeto que vai passar por medico usando os atrivutos dele e usando
            //tamnem medicocrud utilizando o metodo de procurar o paciente
            Medico medicoRemover = medicoCrud.ProcurarMedico(removemedico);

            // agora vamos pergunar se encontrou se sim remove se nao manda uma msg de paciente nao encontrado

            if (medicoRemover != null)
            {
                medicoCrud.RemoverMedico(medicoRemover);
                Console.WriteLine("Medico Removido Com Sucesso!!!");
            }
            else
            {
                Console.WriteLine("Nenhum medico Encontrado");
            }
        }
        
    }
}
