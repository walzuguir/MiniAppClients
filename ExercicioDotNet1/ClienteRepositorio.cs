using Cadastro; // Importa o namespace Cadastro para a classe ClienteRepositorio

namespace ClienteRepo;

public class ClienteRepositorio // Classe criada para armazenar os clientes
{

    public List<Cliente> clientes = new List<Cliente>(); // Instanciando uma nova lista de clientes

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

    
    public void CadastrarCliente() // Método para efetivar o cadastro das informações do cliente...
    {
        Console.Clear();

        Console.Write("Nome do cliente: ");
        
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var dataDeNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var cliente = new Cliente(); // Instancia um novo cliente
        cliente.Id = clientes.Count + 1; // Atribui um novo ID ao cliente que é relativo ao tamanho da lista +1
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
