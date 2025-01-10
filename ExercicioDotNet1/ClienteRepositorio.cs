using Cadastro;
using System.Diagnostics.Metrics;
using System.Text.Json; 

namespace ClienteRepo;

public class ClienteRepositorio 
{

    public List<Cliente> clientes = new List<Cliente>();

    public void GravarDadosCliente()
    {

        var json = JsonSerializer.Serialize(clientes);

        File.WriteAllText("clientes.txt", json);
    }

    public void LerDadosCliente() 
    {
        if (File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");

            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);

            clientes.AddRange(clientesArquivo); 
        }
    }

    public void ExcluirCliente() 
    {
        Console.Clear();
        Console.Write("Informe o código do cliente a ser excluido: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo)); 

        if (cliente == null) 
        {
            Console.WriteLine("Cliente não encontrado na DB!");
            Console.WriteLine("[Enter pra voltar ao menu principal]");
            Console.ReadKey();
            return;
        }

        ImprimirCliente(cliente);

        clientes.Remove(cliente); 

        Console.WriteLine("Cliente removido com sucesso!");
        Console.WriteLine("[Enter pra voltar ao menu principal]");
        Console.ReadKey();
    }

    public void EditarCliente() 
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(p => p.Id == int.Parse(codigo)); 

        if (cliente == null) 
        {
            Console.WriteLine("Cliente não encontrado na DB!");
            Console.WriteLine("[Enter pra voltar ao menu principal]");
            Console.ReadKey();
            return;

        }

        ImprimirCliente(cliente);

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

        Console.WriteLine("Cliente editado com sucesso!");
        Console.WriteLine("[Enter pra voltar ao menu principal]");
        ImprimirCliente(cliente);
        Console.ReadKey();
    
    }

    
    public void CadastrarCliente() 
    {
        Console.Clear();

        string nome = string.Empty;
        DateOnly dataDeNascimento = default;
        decimal desconto = 0;

        try
        {
            Console.Write("Nome do cliente: ");
            nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome) || !nome.Replace(" ", "").All(char.IsLetter))
            {
                Console.WriteLine(" ");
                throw new Exception("Nome do cliente é obrigatório e deve conter apenas letras!");
            }
            Console.Write(Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir nome: {ex.Message}");
            Console.WriteLine("[Enter pra voltar ao menu principal]");
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
            Console.WriteLine($"Erro ao inserir data de nascimento: {ex.Message}");
            Console.WriteLine("[Enter pra voltar ao menu principal]");
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
            Console.WriteLine($"Erro ao inserir data de nascimento: {ex.Message}");
            Console.WriteLine("[Enter pra voltar ao menu principal]");
            Console.ReadKey();
            return;
        }


        var cliente = new Cliente();
        cliente.Id = clientes.Count + 1;
        cliente.Nome = nome;
        cliente.DataNascimento = dataDeNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now; 

        clientes.Add(cliente);

        Console.WriteLine("Cliente cadastrado com sucesso!");
        Console.WriteLine("[Enter pra voltar ao menu principal]");
        ImprimirCliente(cliente);
        Console.ReadKey();

    }

    public void ImprimirCliente(Cliente cliente)
    {
        Console.WriteLine("ID.........: " + cliente.Id);
        Console.WriteLine("Nome.........: " + cliente.Nome);
        Console.WriteLine("Desconto.........: " + cliente.Desconto.ToString("0.00") + " R$");
        Console.WriteLine("Data de nascimento.........: " + cliente.DataNascimento);
        Console.WriteLine("Data cadastro.........: " + cliente.CadastradoEm); 
        Console.WriteLine("----------------------------------------------");
    }

    public void ExibirClientes()
    {
        Console.Clear();
        foreach (var cliente in clientes) 
        {
            ImprimirCliente(cliente); 
        }
        Console.ReadKey();
    }

}
