namespace ClubeDaLeitura.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Amigo amigo1 = new Amigo("José Cleber Vicente", "Pai do José", "(49) 99954-1509");
        List<Amigo> amigos = new List<Amigo>();
        Console.Write(amigo1.Nome);
        
    }
}
