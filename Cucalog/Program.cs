using System;
using System.Collections.Generic;
using System.Text;
using Cucalog.Classes;
using Cucalog.Services;

namespace Cucalog
{
    class Program
    {
        // ==========================================
        // LISTAS DO SISTEMA
        // ==========================================

        static List<Cliente> clientes = new List<Cliente>();
        static List<Funcionario> funcionarios = new List<Funcionario>();
        static List<Veiculo> veiculos = new List<Veiculo>();
        static List<Encomenda> encomendas = new List<Encomenda>();
        static List<Entrega> entregas = new List<Entrega>();

        static DadosService dadosService = new DadosService();

        // ==========================================
        // PROGRAMA PRINCIPAL
        // ==========================================

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("============================================");
                Console.WriteLine("       CUCALOG - SISTEMA DE LOGÍSTICA");
                Console.WriteLine("============================================");
                Console.WriteLine("1  - Cadastrar cliente");
                Console.WriteLine("2  - Cadastrar funcionário");
                Console.WriteLine("3  - Cadastrar veículo");
                Console.WriteLine("4  - Cadastrar encomenda");
                Console.WriteLine("5  - Registrar entrega");
                Console.WriteLine("6  - Listar clientes");
                Console.WriteLine("7  - Listar funcionários");
                Console.WriteLine("8  - Listar veículos");
                Console.WriteLine("9  - Listar encomendas");
                Console.WriteLine("10 - Listar entregas");
                Console.WriteLine("11 - Consultar encomenda");
                Console.WriteLine("12 - Alterar status da entrega");
                Console.WriteLine("13 - Excluir cadastro");
                Console.WriteLine("14 - Salvar dados");
                Console.WriteLine("15 - Carregar dados");
                Console.WriteLine("0  - Sair");
                Console.WriteLine("============================================");

                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        CadastrarFuncionario();
                        break;

                    case 3:
                        CadastrarVeiculo();
                        break;

                    case 4:
                        CadastrarEncomenda();
                        break;

                    case 5:
                        RegistrarEntrega();
                        break;

                    case 6:
                        ListarClientes();
                        break;

                    case 7:
                        ListarFuncionarios();
                        break;

                    case 8:
                        ListarVeiculos();
                        break;

                    case 9:
                        ListarEncomendas();
                        break;

                    case 10:
                        ListarEntregas();
                        break;

                    case 11:
                        ConsultarEncomenda();
                        break;

                    case 12:
                        AlterarStatusEntrega();
                        break;

                    case 13:
                        ExcluirCadastro();
                        break;

                    case 14:
                        SalvarDados();
                        break;

                    case 15:
                        CarregarDados();
                        break;

                    case 0:
                        Console.WriteLine("\nSistema encerrado.");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!");
                        Pausar();
                        break;
                }

            } while (opcao != 0);
        }

        // ==========================================
        // CADASTRAR CLIENTE
        // ==========================================

        static void CadastrarCliente()
        {
            Console.Clear();

            Console.WriteLine("========== CADASTRO DE CLIENTE ==========");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("CPF: ");
            string cpf = Console.ReadLine() ?? "";

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine() ?? "";

            Console.Write("E-mail: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine() ?? "";

            Cliente cliente = new Cliente(
                nome,
                cpf,
                telefone,
                email,
                endereco
            );

            clientes.Add(cliente);

            Console.WriteLine("\nCliente cadastrado com sucesso!");

            Pausar();
        }

        // ==========================================
        // CADASTRAR FUNCIONÁRIO
        // ==========================================

        static void CadastrarFuncionario()
        {
            Console.Clear();

            Console.WriteLine("========== CADASTRO DE FUNCIONÁRIO ==========");

            Console.Write("Nome: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("CPF: ");
            string cpf = Console.ReadLine() ?? "";

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine() ?? "";

            Console.Write("E-mail: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Cargo: ");
            string cargo = Console.ReadLine() ?? "";

            Funcionario funcionario = new Funcionario(
                nome,
                cpf,
                telefone,
                email,
                cargo
            );

            funcionarios.Add(funcionario);

            Console.WriteLine("\nFuncionário cadastrado com sucesso!");

            Pausar();
        }

        // ==========================================
        // CADASTRAR VEÍCULO
        // ==========================================

        static void CadastrarVeiculo()
        {
            Console.Clear();

            Console.WriteLine("========== CADASTRO DE VEÍCULO ==========");

            Console.Write("Placa: ");
            string placa = Console.ReadLine() ?? "";

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? "";

            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? "";

            Console.Write("Ano: ");

            int ano;

            if (!int.TryParse(Console.ReadLine(), out ano))
            {
                Console.WriteLine("\nAno inválido!");
                Pausar();
                return;
            }

            Console.Write("Capacidade em kg: ");

            double capacidade;

            if (!double.TryParse(Console.ReadLine(), out capacidade))
            {
                Console.WriteLine("\nCapacidade inválida!");
                Pausar();
                return;
            }

            Veiculo veiculo = new Veiculo(
                placa,
                modelo,
                marca,
                ano,
                capacidade
            );

            veiculos.Add(veiculo);

            Console.WriteLine("\nVeículo cadastrado com sucesso!");

            Pausar();
        }

        // ==========================================
        // CADASTRAR ENCOMENDA
        // ==========================================

        static void CadastrarEncomenda()
        {
            Console.Clear();

            Console.WriteLine("========== CADASTRO DE ENCOMENDA ==========");

            if (clientes.Count == 0)
            {
                Console.WriteLine(
                    "É necessário cadastrar um cliente primeiro."
                );

                Pausar();
                return;
            }

            Console.WriteLine("\nClientes cadastrados:");

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + " - " +
                    clientes[i].Nome +
                    " | CPF: " +
                    clientes[i].CPF
                );
            }

            Console.Write("\nEscolha o cliente responsável: ");

            int indiceCliente;

            if (!int.TryParse(
                Console.ReadLine(),
                out indiceCliente))
            {
                Console.WriteLine("\nOpção inválida!");
                Pausar();
                return;
            }

            if (indiceCliente < 1 ||
                indiceCliente > clientes.Count)
            {
                Console.WriteLine("\nCliente inválido!");
                Pausar();
                return;
            }

            Cliente clienteSelecionado =
                clientes[indiceCliente - 1];

            Console.Write("\nDescrição da encomenda: ");
            string descricao = Console.ReadLine() ?? "";

            Console.Write("Peso em kg: ");

            double peso;

            if (!double.TryParse(
                Console.ReadLine(),
                out peso))
            {
                Console.WriteLine("\nPeso inválido!");
                Pausar();
                return;
            }

            // ------------------------------------------
            // ENDEREÇO DE ORIGEM
            // ------------------------------------------

            Console.WriteLine("\n----- ENDEREÇO DE ORIGEM -----");

            Console.Write("Rua: ");
            string ruaOrigem = Console.ReadLine() ?? "";

            Console.Write("Número: ");
            string numeroOrigem = Console.ReadLine() ?? "";

            Console.Write("Bairro: ");
            string bairroOrigem = Console.ReadLine() ?? "";

            Console.Write("Cidade: ");
            string cidadeOrigem = Console.ReadLine() ?? "";

            Console.Write("CEP: ");
            string cepOrigem = Console.ReadLine() ?? "";

            Endereco origem = new Endereco(
                ruaOrigem,
                numeroOrigem,
                bairroOrigem,
                cidadeOrigem,
                cepOrigem
            );

            // ------------------------------------------
            // ENDEREÇO DE DESTINO
            // ------------------------------------------

            Console.WriteLine("\n----- ENDEREÇO DE DESTINO -----");

            Console.Write("Rua: ");
            string ruaDestino = Console.ReadLine() ?? "";

            Console.Write("Número: ");
            string numeroDestino = Console.ReadLine() ?? "";

            Console.Write("Bairro: ");
            string bairroDestino = Console.ReadLine() ?? "";

            Console.Write("Cidade: ");
            string cidadeDestino = Console.ReadLine() ?? "";

            Console.Write("CEP: ");
            string cepDestino = Console.ReadLine() ?? "";

            Endereco destino = new Endereco(
                ruaDestino,
                numeroDestino,
                bairroDestino,
                cidadeDestino,
                cepDestino
            );

            int codigo = encomendas.Count + 1;

            Encomenda encomenda = new Encomenda(
                codigo,
                descricao,
                peso,
                origem,
                destino,
                clienteSelecionado
            );

            encomendas.Add(encomenda);

            Console.WriteLine(
                "\nEncomenda cadastrada com sucesso!"
            );

            Console.WriteLine(
                "Código da encomenda: " + codigo
            );

            Pausar();
        }

        // ==========================================
        // REGISTRAR ENTREGA
        // ==========================================

        static void RegistrarEntrega()
        {
            Console.Clear();

            Console.WriteLine("========== REGISTRAR ENTREGA ==========");

            if (encomendas.Count == 0)
            {
                Console.WriteLine(
                    "É necessário cadastrar uma encomenda primeiro."
                );

                Pausar();
                return;
            }

            if (veiculos.Count == 0)
            {
                Console.WriteLine(
                    "É necessário cadastrar um veículo primeiro."
                );

                Pausar();
                return;
            }

            if (funcionarios.Count == 0)
            {
                Console.WriteLine(
                    "É necessário cadastrar um funcionário primeiro."
                );

                Pausar();
                return;
            }

            // ------------------------------------------
            // ESCOLHER ENCOMENDA
            // ------------------------------------------

            Console.WriteLine("\n----- ENCOMENDAS -----");

            foreach (Encomenda encomenda in encomendas)
            {
                Console.WriteLine(
                    "Código: " +
                    encomenda.Codigo +
                    " | Descrição: " +
                    encomenda.Descricao
                );
            }

            Console.Write("\nDigite o código da encomenda: ");

            int codigoEncomenda;

            if (!int.TryParse(
                Console.ReadLine(),
                out codigoEncomenda))
            {
                Console.WriteLine("Código inválido!");
                Pausar();
                return;
            }

            Encomenda encomendaSelecionada = null;

            foreach (Encomenda encomenda in encomendas)
            {
                if (encomenda.Codigo == codigoEncomenda)
                {
                    encomendaSelecionada = encomenda;
                    break;
                }
            }

            if (encomendaSelecionada == null)
            {
                Console.WriteLine(
                    "Encomenda não encontrada!"
                );

                Pausar();
                return;
            }

            // ------------------------------------------
            // ESCOLHER VEÍCULO
            // ------------------------------------------

            Console.WriteLine("\n----- VEÍCULOS -----");

            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) +
                    " - " +
                    veiculos[i].Placa +
                    " | " +
                    veiculos[i].Modelo
                );
            }

            Console.Write("\nEscolha o veículo: ");

            int indiceVeiculo;

            if (!int.TryParse(
                Console.ReadLine(),
                out indiceVeiculo))
            {
                Console.WriteLine("Opção inválida!");
                Pausar();
                return;
            }

            if (indiceVeiculo < 1 ||
                indiceVeiculo > veiculos.Count)
            {
                Console.WriteLine("Veículo inválido!");
                Pausar();
                return;
            }

            Veiculo veiculoSelecionado =
                veiculos[indiceVeiculo - 1];

            // ------------------------------------------
            // ESCOLHER FUNCIONÁRIO
            // ------------------------------------------

            Console.WriteLine("\n----- FUNCIONÁRIOS -----");

            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) +
                    " - " +
                    funcionarios[i].Nome +
                    " | " +
                    funcionarios[i].Cargo
                );
            }

            Console.Write(
                "\nEscolha o funcionário responsável: "
            );

            int indiceFuncionario;

            if (!int.TryParse(
                Console.ReadLine(),
                out indiceFuncionario))
            {
                Console.WriteLine("Opção inválida!");
                Pausar();
                return;
            }

            if (indiceFuncionario < 1 ||
                indiceFuncionario > funcionarios.Count)
            {
                Console.WriteLine("Funcionário inválido!");
                Pausar();
                return;
            }

            Funcionario funcionarioSelecionado =
                funcionarios[indiceFuncionario - 1];

            int codigoEntrega = entregas.Count + 1;

            Entrega entrega = new Entrega(
                codigoEntrega,
                encomendaSelecionada,
                veiculoSelecionado,
                funcionarioSelecionado,
                DateTime.Now,
                "Pendente"
            );

            entregas.Add(entrega);

            Console.WriteLine(
                "\nEntrega registrada com sucesso!"
            );

            Console.WriteLine(
                "Código da entrega: " + codigoEntrega
            );

            Pausar();
        }

        // ==========================================
        // LISTAR CLIENTES
        // ==========================================

        static void ListarClientes()
        {
            Console.Clear();

            Console.WriteLine(
                "========== CLIENTES CADASTRADOS =========="
            );

            if (clientes.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum cliente cadastrado."
                );
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    cliente.ExibirDados();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // LISTAR FUNCIONÁRIOS
        // ==========================================

        static void ListarFuncionarios()
        {
            Console.Clear();

            Console.WriteLine(
                "========== FUNCIONÁRIOS CADASTRADOS =========="
            );

            if (funcionarios.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum funcionário cadastrado."
                );
            }
            else
            {
                foreach (
                    Funcionario funcionario
                    in funcionarios)
                {
                    funcionario.ExibirDados();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // LISTAR VEÍCULOS
        // ==========================================

        static void ListarVeiculos()
        {
            Console.Clear();

            Console.WriteLine(
                "========== VEÍCULOS CADASTRADOS =========="
            );

            if (veiculos.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum veículo cadastrado."
                );
            }
            else
            {
                foreach (Veiculo veiculo in veiculos)
                {
                    veiculo.ExibirDados();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // LISTAR ENCOMENDAS
        // ==========================================

        static void ListarEncomendas()
        {
            Console.Clear();

            Console.WriteLine(
                "========== ENCOMENDAS CADASTRADAS =========="
            );

            if (encomendas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma encomenda cadastrada."
                );
            }
            else
            {
                foreach (Encomenda encomenda in encomendas)
                {
                    encomenda.ExibirDados();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // LISTAR ENTREGAS
        // ==========================================

        static void ListarEntregas()
        {
            Console.Clear();

            Console.WriteLine(
                "========== ENTREGAS CADASTRADAS =========="
            );

            if (entregas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma entrega cadastrada."
                );
            }
            else
            {
                foreach (Entrega entrega in entregas)
                {
                    entrega.ExibirDados();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // CONSULTAR ENCOMENDA
        // ==========================================

        static void ConsultarEncomenda()
        {
            Console.Clear();

            Console.WriteLine(
                "========== CONSULTAR ENCOMENDA =========="
            );

            if (encomendas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma encomenda cadastrada."
                );

                Pausar();
                return;
            }

            Console.Write(
                "Digite o código da encomenda: "
            );

            int codigo;

            if (!int.TryParse(
                Console.ReadLine(),
                out codigo))
            {
                Console.WriteLine(
                    "Código inválido!"
                );

                Pausar();
                return;
            }

            Encomenda encontrada = null;

            foreach (Encomenda encomenda in encomendas)
            {
                if (encomenda.Codigo == codigo)
                {
                    encontrada = encomenda;
                    break;
                }
            }

            if (encontrada == null)
            {
                Console.WriteLine(
                    "Encomenda não encontrada."
                );
            }
            else
            {
                encontrada.ExibirDados();
            }

            Pausar();
        }

        // ==========================================
        // ALTERAR STATUS DA ENTREGA
        // ==========================================

        static void AlterarStatusEntrega()
        {
            Console.Clear();

            Console.WriteLine(
                "========== ALTERAR STATUS =========="
            );

            if (entregas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma entrega cadastrada."
                );

                Pausar();
                return;
            }

            foreach (Entrega entrega in entregas)
            {
                Console.WriteLine(
                    "Código: " +
                    entrega.Codigo +
                    " | Status: " +
                    entrega.Status
                );
            }

            Console.Write(
                "\nDigite o código da entrega: "
            );

            int codigo;

            if (!int.TryParse(
                Console.ReadLine(),
                out codigo))
            {
                Console.WriteLine(
                    "Código inválido!"
                );

                Pausar();
                return;
            }

            Entrega entregaSelecionada = null;

            foreach (Entrega entrega in entregas)
            {
                if (entrega.Codigo == codigo)
                {
                    entregaSelecionada = entrega;
                    break;
                }
            }

            if (entregaSelecionada == null)
            {
                Console.WriteLine(
                    "Entrega não encontrada!"
                );

                Pausar();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("1 - Pendente");
            Console.WriteLine("2 - Em transporte");
            Console.WriteLine("3 - Entregue");

            Console.Write(
                "Escolha o novo status: "
            );

            int opcaoStatus;

            if (!int.TryParse(
                Console.ReadLine(),
                out opcaoStatus))
            {
                Console.WriteLine(
                    "Opção inválida!"
                );

                Pausar();
                return;
            }

            string novoStatus;

            switch (opcaoStatus)
            {
                case 1:
                    novoStatus = "Pendente";
                    break;

                case 2:
                    novoStatus = "Em transporte";
                    break;

                case 3:
                    novoStatus = "Entregue";
                    break;

                default:
                    Console.WriteLine(
                        "Opção inválida!"
                    );

                    Pausar();
                    return;
            }

            entregaSelecionada.AlterarStatus(
                novoStatus
            );

            Console.WriteLine(
                "\nStatus alterado com sucesso!"
            );

            Pausar();
        }

        // ==========================================
        // MENU DE EXCLUSÃO
        // ==========================================

        static void ExcluirCadastro()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR CADASTRO =========="
            );

            Console.WriteLine("1 - Excluir cliente");
            Console.WriteLine("2 - Excluir funcionário");
            Console.WriteLine("3 - Excluir veículo");
            Console.WriteLine("4 - Excluir encomenda");
            Console.WriteLine("5 - Excluir entrega");
            Console.WriteLine("0 - Voltar");

            Console.Write(
                "\nEscolha uma opção: "
            );

            int opcao;

            if (!int.TryParse(
                Console.ReadLine(),
                out opcao))
            {
                Console.WriteLine(
                    "Opção inválida!"
                );

                Pausar();
                return;
            }

            switch (opcao)
            {
                case 1:
                    ExcluirCliente();
                    break;

                case 2:
                    ExcluirFuncionario();
                    break;

                case 3:
                    ExcluirVeiculo();
                    break;

                case 4:
                    ExcluirEncomenda();
                    break;

                case 5:
                    ExcluirEntrega();
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine(
                        "Opção inválida!"
                    );

                    Pausar();
                    break;
            }
        }

        // ==========================================
        // EXCLUIR CLIENTE
        // ==========================================

        static void ExcluirCliente()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR CLIENTE =========="
            );

            if (clientes.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum cliente cadastrado."
                );

                Pausar();
                return;
            }

            for (int i = 0; i < clientes.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) +
                    " - " +
                    clientes[i].Nome +
                    " | CPF: " +
                    clientes[i].CPF
                );
            }

            Console.Write(
                "\nEscolha o cliente: "
            );

            int indice;

            if (!int.TryParse(
                Console.ReadLine(),
                out indice))
            {
                Console.WriteLine(
                    "Opção inválida!"
                );

                Pausar();
                return;
            }

            if (indice < 1 ||
                indice > clientes.Count)
            {
                Console.WriteLine(
                    "Cliente inválido!"
                );

                Pausar();
                return;
            }

            Cliente cliente = clientes[indice - 1];

            Console.Write(
                "\nDeseja excluir " +
                cliente.Nome +
                "? (S/N): "
            );

            string confirmacao =
                Console.ReadLine() ?? "";

            if (confirmacao.ToUpper() == "S")
            {
                clientes.Remove(cliente);

                Console.WriteLine(
                    "\nCliente excluído com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "\nExclusão cancelada."
                );
            }

            Pausar();
        }

        // ==========================================
        // EXCLUIR FUNCIONÁRIO
        // ==========================================

        static void ExcluirFuncionario()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR FUNCIONÁRIO =========="
            );

            if (funcionarios.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum funcionário cadastrado."
                );

                Pausar();
                return;
            }

            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) +
                    " - " +
                    funcionarios[i].Nome +
                    " | Cargo: " +
                    funcionarios[i].Cargo
                );
            }

            Console.Write(
                "\nEscolha o funcionário: "
            );

            int indice;

            if (!int.TryParse(
                Console.ReadLine(),
                out indice))
            {
                Console.WriteLine(
                    "Opção inválida!"
                );

                Pausar();
                return;
            }

            if (indice < 1 ||
                indice > funcionarios.Count)
            {
                Console.WriteLine(
                    "Funcionário inválido!"
                );

                Pausar();
                return;
            }

            Funcionario funcionario =
                funcionarios[indice - 1];

            Console.Write(
                "\nDeseja excluir " +
                funcionario.Nome +
                "? (S/N): "
            );

            string confirmacao =
                Console.ReadLine() ?? "";

            if (confirmacao.ToUpper() == "S")
            {
                funcionarios.Remove(funcionario);

                Console.WriteLine(
                    "\nFuncionário excluído com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "\nExclusão cancelada."
                );
            }

            Pausar();
        }

        // ==========================================
        // EXCLUIR VEÍCULO
        // ==========================================

        static void ExcluirVeiculo()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR VEÍCULO =========="
            );

            if (veiculos.Count == 0)
            {
                Console.WriteLine(
                    "Nenhum veículo cadastrado."
                );

                Pausar();
                return;
            }

            for (int i = 0; i < veiculos.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) +
                    " - " +
                    veiculos[i].Placa +
                    " | " +
                    veiculos[i].Modelo
                );
            }

            Console.Write(
                "\nEscolha o veículo: "
            );

            int indice;

            if (!int.TryParse(
                Console.ReadLine(),
                out indice))
            {
                Console.WriteLine(
                    "Opção inválida!"
                );

                Pausar();
                return;
            }

            if (indice < 1 ||
                indice > veiculos.Count)
            {
                Console.WriteLine(
                    "Veículo inválido!"
                );

                Pausar();
                return;
            }

            Veiculo veiculo =
                veiculos[indice - 1];

            Console.Write(
                "\nDeseja excluir o veículo " +
                veiculo.Placa +
                "? (S/N): "
            );

            string confirmacao =
                Console.ReadLine() ?? "";

            if (confirmacao.ToUpper() == "S")
            {
                veiculos.Remove(veiculo);

                Console.WriteLine(
                    "\nVeículo excluído com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "\nExclusão cancelada."
                );
            }

            Pausar();
        }

        // ==========================================
        // EXCLUIR ENCOMENDA
        // ==========================================

        static void ExcluirEncomenda()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR ENCOMENDA =========="
            );

            if (encomendas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma encomenda cadastrada."
                );

                Pausar();
                return;
            }

            foreach (Encomenda encomenda in encomendas)
            {
                Console.WriteLine(
                    "Código: " +
                    encomenda.Codigo +
                    " | " +
                    encomenda.Descricao
                );
            }

            Console.Write(
                "\nDigite o código da encomenda: "
            );

            int codigo;

            if (!int.TryParse(
                Console.ReadLine(),
                out codigo))
            {
                Console.WriteLine(
                    "Código inválido!"
                );

                Pausar();
                return;
            }

            Encomenda encontrada = null;

            foreach (Encomenda encomenda in encomendas)
            {
                if (encomenda.Codigo == codigo)
                {
                    encontrada = encomenda;
                    break;
                }
            }

            if (encontrada == null)
            {
                Console.WriteLine(
                    "Encomenda não encontrada!"
                );
            }
            else
            {
                Console.Write(
                    "\nDeseja excluir esta encomenda? (S/N): "
                );

                string confirmacao =
                    Console.ReadLine() ?? "";

                if (confirmacao.ToUpper() == "S")
                {
                    encomendas.Remove(encontrada);

                    Console.WriteLine(
                        "\nEncomenda excluída com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "\nExclusão cancelada."
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // EXCLUIR ENTREGA
        // ==========================================

        static void ExcluirEntrega()
        {
            Console.Clear();

            Console.WriteLine(
                "========== EXCLUIR ENTREGA =========="
            );

            if (entregas.Count == 0)
            {
                Console.WriteLine(
                    "Nenhuma entrega cadastrada."
                );

                Pausar();
                return;
            }

            foreach (Entrega entrega in entregas)
            {
                Console.WriteLine(
                    "Código: " +
                    entrega.Codigo +
                    " | Status: " +
                    entrega.Status
                );
            }

            Console.Write(
                "\nDigite o código da entrega: "
            );

            int codigo;

            if (!int.TryParse(
                Console.ReadLine(),
                out codigo))
            {
                Console.WriteLine(
                    "Código inválido!"
                );

                Pausar();
                return;
            }

            Entrega encontrada = null;

            foreach (Entrega entrega in entregas)
            {
                if (entrega.Codigo == codigo)
                {
                    encontrada = entrega;
                    break;
                }
            }

            if (encontrada == null)
            {
                Console.WriteLine(
                    "Entrega não encontrada!"
                );
            }
            else
            {
                Console.Write(
                    "\nDeseja excluir esta entrega? (S/N): "
                );

                string confirmacao =
                    Console.ReadLine() ?? "";

                if (confirmacao.ToUpper() == "S")
                {
                    entregas.Remove(encontrada);

                    Console.WriteLine(
                        "\nEntrega excluída com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "\nExclusão cancelada."
                    );
                }
            }

            Pausar();
        }

        // ==========================================
        // SALVAR DADOS
        // ==========================================

        static void SalvarDados()
        {
            Console.Clear();

            Console.WriteLine(
                "========== SALVAR DADOS =========="
            );

            StringBuilder dados =
                new StringBuilder();

            dados.AppendLine(
                "===== CUCALOG - DADOS DO SISTEMA ====="
            );

            dados.AppendLine();

            // ------------------------------------------
            // CLIENTES
            // ------------------------------------------

            dados.AppendLine(
                "===== CLIENTES ====="
            );

            foreach (Cliente cliente in clientes)
            {
                dados.AppendLine(
                    cliente.Nome + "|" +
                    cliente.CPF + "|" +
                    cliente.Telefone + "|" +
                    cliente.Email + "|" +
                    cliente.Endereco
                );
            }

            // ------------------------------------------
            // FUNCIONÁRIOS
            // ------------------------------------------

            dados.AppendLine(
                "===== FUNCIONARIOS ====="
            );

            foreach (Funcionario funcionario
                in funcionarios)
            {
                dados.AppendLine(
                    funcionario.Nome + "|" +
                    funcionario.CPF + "|" +
                    funcionario.Telefone + "|" +
                    funcionario.Email + "|" +
                    funcionario.Cargo
                );
            }

            // ------------------------------------------
            // VEÍCULOS
            // ------------------------------------------

            dados.AppendLine(
                "===== VEICULOS ====="
            );

            foreach (Veiculo veiculo in veiculos)
            {
                dados.AppendLine(
                    veiculo.Placa + "|" +
                    veiculo.Modelo + "|" +
                    veiculo.Marca + "|" +
                    veiculo.Ano + "|" +
                    veiculo.Capacidade
                );
            }

            // ------------------------------------------
            // ENCOMENDAS
            // ------------------------------------------

            dados.AppendLine(
                "===== ENCOMENDAS ====="
            );

            foreach (Encomenda encomenda
                in encomendas)
            {
                dados.AppendLine(
                    encomenda.Codigo + "|" +
                    encomenda.Descricao + "|" +
                    encomenda.Peso + "|" +
                    encomenda.ClienteResponsavel.CPF
                );

                dados.AppendLine(
                    "ORIGEM|" +
                    encomenda.Origem.Rua + "|" +
                    encomenda.Origem.Numero + "|" +
                    encomenda.Origem.Bairro + "|" +
                    encomenda.Origem.Cidade + "|" +
                    encomenda.Origem.CEP
                );

                dados.AppendLine(
                    "DESTINO|" +
                    encomenda.Destino.Rua + "|" +
                    encomenda.Destino.Numero + "|" +
                    encomenda.Destino.Bairro + "|" +
                    encomenda.Destino.Cidade + "|" +
                    encomenda.Destino.CEP
                );
            }

            // ------------------------------------------
            // ENTREGAS
            // ------------------------------------------

            dados.AppendLine(
                "===== ENTREGAS ====="
            );

            foreach (Entrega entrega in entregas)
            {
                dados.AppendLine(
                    entrega.Codigo + "|" +
                    entrega.Encomenda.Codigo + "|" +
                    entrega.Veiculo.Placa + "|" +
                    entrega.FuncionarioResponsavel.CPF + "|" +
                    entrega.DataEntrega.ToString(
                        "dd/MM/yyyy HH:mm:ss"
                    ) + "|" +
                    entrega.Status
                );
            }

            dadosService.Salvar(
                dados.ToString()
            );

            Pausar();
        }

        // ==========================================
        // CARREGAR DADOS
        // ==========================================

        static void CarregarDados()
        {
            Console.Clear();

            Console.WriteLine(
                "========== CARREGAR DADOS =========="
            );

            string dados =
                dadosService.Carregar();

            if (string.IsNullOrEmpty(dados))
            {
                Pausar();
                return;
            }

            Console.WriteLine(
                "Arquivo de dados encontrado."
            );

            Console.WriteLine();

            Console.WriteLine(
                "Conteúdo salvo:"
            );

            Console.WriteLine(
                "------------------------------------------"
            );

            Console.WriteLine(dados);

            Console.WriteLine(
                "------------------------------------------"
            );

            Console.WriteLine();

            Console.WriteLine(
                "Os dados foram carregados do arquivo."
            );

            Pausar();
        }

        // ==========================================
        // PAUSAR
        // ==========================================

        static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine(
                "Pressione ENTER para continuar..."
            );

            Console.ReadLine();
        }
    }
}