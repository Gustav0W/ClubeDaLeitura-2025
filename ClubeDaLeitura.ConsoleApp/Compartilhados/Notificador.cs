namespace ClubeDaLeitura.ConsoleApp.Compartilhados;

internal class Notificador
{
    public static void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;

        Console.Write($"\n{mensagem}");

        Console.ResetColor();

        Console.ReadLine();
    }
}
