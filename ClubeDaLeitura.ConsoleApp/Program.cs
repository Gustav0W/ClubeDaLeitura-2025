using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.Compartilhados;

namespace ClubeDaLeitura.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        MenuClube menuClube = new MenuClube();

        List<Amigo> amigos = new List<Amigo>();

        while (true)
        {
            string opcaoEscolhida = menuClube.ExibirMenu().ToUpper();

            switch (opcaoEscolhida) 
            {
                case "1":

                    break;

            }

            if (opcaoEscolhida == "S")
            {
                break;
            }
        } 
        
    }
}
