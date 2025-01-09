using Cadastro;
using System.Text.Json; // Importa o namespace Cadastro para a classe ClienteRepositorio

namespace ClienteRepo;

public class ClienteRepositorio // Classe criada para armazenar os clientes
{

    public List<Cliente> clientes = new List<Cliente>(); // Instanciando uma nova lista de clientes

    public void GravarDadosCliente()
    {

        var json = JsonSerializer.Serialize(clientes); // Serializa a lista de clientes em formato JSON

        File.WriteAllText("clients.txt", json); // Escreve o arquivo JSON no arquivo clientes.txt
    }

    public void LerDadosCliente()
    {
        if (File.Exists("clients.txt")) // Verifica se o arquivo existe
        {
            var dados = File.ReadAllText("clients.txt"); // Lê o arquivo clientes.txt

            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

            clientes.AddRange(clientesArquivo); // Adiciona os clientes do arquivo na lista de clientes se o arquivo não estiver vazio.
        }
    }

    public void ExcluirCliente() // Método para exluir um cliente da DB
    {
        Console.Clear();
        Console.Write("Informe o código do cliente a ser excluido: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo)); // Atráves do método FirstOrDefault que retorna o primeiro elemento da sequência que satisfaça uma condição específica ou um valor padrão se nenhum elemento for encontrado.

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado na DB! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        clientes.Remove(cliente); // Remove o cliente da lista de clientes

        Console.WriteLine("Cliente removido com sucesso! [Enter]"); // Mensagem para informar que o cliente foi removido

        Console.ReadKey();
    }

    public void EditarCliente() // Método para editar as informações do cliente
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo)); // Busca o cliente na lista de clientes por meio do ID informado pelo usuário final.

        if (cliente == null) 
        {
            Console.WriteLine("Cliente não encontrado na DB! [Enter]");
            Console.ReadKey();
            return;

        }

        ImprimirCliente(cliente); // Método que imprime os dados do cliente

        Console.Write("Nome do usuário: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var dataDeNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        cliente.Nome = nome;
        cliente.DataNascimento = dataDeNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now;

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        ImprimirCliente(cliente);
        Console.ReadKey();
    
    }

    
    public void CadastrarCliente() // Método para realizar o cadastro das informações do cliente...
    {
        Console.Clear();

        string nome = string.Empty; // Inicializando as variáveis com valores padrão
        DateOnly dataDeNascimento = default;
        decimal desconto = 0;

        try
        {
            Console.Write("Nome do cliente: ");
            nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome) || !nome.Replace(" ", "").All(char.IsLetter))
            {
                Console.WriteLine(" ");
                throw new Exception("Nome do cliente é obrigatório e deve conter apenas letras!"); // Método throw para lançar a exceção e não permitir entrada de outros valores além de letras para nome do cliente.
            }
            Console.Write(Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir nome: {ex.Message} [Enter]");
            Console.ReadKey();
            return;
        }

        try
        {
        
        Console.Write("Data de nascimento: ");
        dataDeNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir data de nascimento: {ex.Message} [Enter]");
            Console.ReadKey();
            return;
        }

        try
        {
        Console.Write("Desconto: ");
        desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir data de nascimento: {ex.Message} [Enter]");
            Console.ReadKey();
            return;
        }


        var cliente = new Cliente(); // Instancia um novo cliente
        cliente.Id = clientes.Count + 1; // Atribui um novo ID ao cliente ao tamanho da list +1
        cliente.Nome = nome;
        cliente.DataNascimento = dataDeNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now; // Atribui a data de cadastro do cliente na data atual

        clientes.Add(cliente); // Adiciona o novo cliente a lista de clientes

        Console.WriteLine("Cliente cadastrado com sucesso! [Enter]");
        ImprimirCliente(cliente); // Método que imprime os dados do cliente no console
        Console.ReadKey(); // Volta ao menu principal

    }

    public void ImprimirCliente(Cliente cliente) // Método que imprime os dados do cliente
    {
        Console.WriteLine("ID.........: " + cliente.Id);
        Console.WriteLine("Nome.........: " + cliente.Nome);
        Console.WriteLine("Desconto.........: " + cliente.Desconto.ToString("0.00")); // usa o método ToString para formatar o valor em 2 casas decimais.
        Console.WriteLine("Data de nascimento.........: " + cliente.DataNascimento);
        Console.WriteLine("Data cadastro..........: " + cliente.CadastradoEm); // Imprime a data de cadastro do cliente.
        Console.WriteLine("----------------------------------------------");
    }

    public void ExibirClientes() //Método para exibir a lista de clientes.
    {
        Console.Clear();
        foreach (var cliente in clientes) // Percorre a lista de clientes por completa
        {
            ImprimirCliente(cliente); //Método que imprime a lista de clientes
        }
        Console.ReadKey();
    }

}
