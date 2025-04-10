using System.ComponentModel;

namespace ClubeDaLeitura.ConsoleApp.MóduloAmigo;

public class Amigo
{
    public string Nome = " ";
    public string Responsavel = " ";
    public string Telefone = " ";
    
    public Amigo(string nome, string responsavel, string telefone)
    {
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
    }

    public Amigo CadastrarAmigo()
    {
        Console.WriteLine("Informe o nome: ");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Informe o nome do responsável: ");
        string responsavel = Console.ReadLine()!;
        Console.WriteLine("Informe o telefone FORMATO (XX) XXXXX-XXXX: ");
        string telefone = Console.ReadLine()!;

        Amigo novoAmigo = new Amigo(nome, responsavel, telefone);

        return novoAmigo;
    }

}
