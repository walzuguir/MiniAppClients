using ClienteRepo; // Importa o namespace ClienteRepo para a classe Program para instanciar a classe ClienteRepositorio

namespace AppClientes; // Namespace da aplicação

class Program // Classe principal do programa que gerenci interação do usuário com o sistema de cadastro
{

    static ClienteRepositorio _clienteRepositorio = new ClienteRepositorio(); // Instanciando a classe ClienteRepositorio

    static void Main(string[] args) // Método principal da class Program
    {
        while (true) // Mantem a aplicação em execução contínua...
        {
            Menu(); //Exibe o menu principal apartir do método Menu()

            Console.ReadKey();
        }
    }

    static void Menu() // Menu principal
    {
        Console.Clear();

        Console.WriteLine("Cadastro de clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Exibir Clientes");
        Console.WriteLine("3 - Editar Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        EscolherOpcao(); // Chama o método EscolherOpcao para o usuário escolher uma opção através do menu principal.
    }

    static void EscolherOpcao() // Método para ler o input do usuário e chamar o método correspondente
    {
        Console.WriteLine("Escolha uma opção válida: ");
        try
        {
        
        var opcao = Console.ReadLine(); // Lê a opção escolhida pelo usuário

        switch (int.Parse(opcao)) // Estrutura de repetição SWITCH para verificar a opção escolhida pelo usuário
        {
            case 1:
                {
                    _clienteRepositorio.CadastrarCliente();
                    Menu();
                    break;
                }
            case 2:
                {
                    _clienteRepositorio.ExibirClientes();
                    Menu();
                    break;
                }
            case 3:
                {
                    _clienteRepositorio.EditarCliente();
                    Menu();
                    break;
                }
            case 4:
                {
                    _clienteRepositorio.ExcluirCliente();
                    Menu();
                    break;
                }
            case 5:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    break;
                }
        }
        }catch(FormatException) 
        { 
        Console.WriteLine("Opção inválida, por favor digite uma opção entre 1 e 5!"); 
        }
    }

}