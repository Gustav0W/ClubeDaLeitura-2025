namespace ClubeDaLeitura.ConsoleApp.Compartilhados;

public class MenuClube
{
    public string ExibirMenu()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("|         CLUBE DO LIVRO         |");
        Console.WriteLine("|            GUSTAVO W           |");
        Console.WriteLine("==================================");
        Console.WriteLine("| 1 - Gerenciar Amigos           |");
        Console.WriteLine("| 2 - Gerenciar Caixas           |");
        Console.WriteLine("| 3 - Gerenciar Revistas         |");
        Console.WriteLine("| 4 - Gerenciar Emprestimos      |");
        Console.WriteLine("| S - Sair do programa           |");
        Console.WriteLine("|________________________________|");
        Console.Write("Informe o que deseja: ");
        string opcaoEscolhida = Console.ReadLine()!;
        return opcaoEscolhida;
    }
}
