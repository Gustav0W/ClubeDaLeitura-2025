using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        

        TelaPrincipal menuClube = new TelaPrincipal();
        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
        TelaCaixaTematica telaCaixaTematica = new TelaCaixaTematica();
        TelaRevista telaRevista = new TelaRevista();

        List<Amigo> amigos = new List<Amigo>();

        while (true)
        {
            string opcaoPrincipal = menuClube.ExibirMenuPrincipal().ToUpper();

            if (opcaoPrincipal == "1")
            {
                string opcaoEscolhida = telaAmigo.ExibirTelaAmigo();
                switch (opcaoEscolhida)
                {
                    case "1":
                        telaAmigo.CadastrarAmigo();
                        break;
                    case "2":
                        telaAmigo.EditarAmigo();
                        break;
                    case "3":
                        telaAmigo.ExcluirAmigo();
                        break;
                    case "4":
                        telaAmigo.VisualizarAmigos(true);
                        break;
                }
            }
            else if (opcaoPrincipal == "2")
            {
                string opcaoEscolhida = telaCaixaTematica.ExibirTelaCaixa().ToUpper();
                switch (opcaoEscolhida)
                {
                    case "1":
                        telaCaixaTematica.CadastrarNovaCaixa();
                        break;
                    case "2":
                        telaCaixaTematica.EditarCaixa();
                        break;
                    case "3":
                        telaCaixaTematica.ExcluirCaixa();
                        break;
                    case "4":
                        telaCaixaTematica.VisualizarCaixas(true);
                        break;

                }
            }
            else if (opcaoPrincipal == "3")
            {
                string opcaoEscolhida = telaRevista.ExibirTelaRevistas().ToUpper();

                switch(opcaoEscolhida)
                {
                    case "1":
                        telaRevista.CadastrarRevista();
                        break;
                    case "2":
                        telaRevista.EditarRevista();
                        break;
                    case "3":
                        telaRevista.ExcluirRevista();
                        break;
                    case "4":
                        telaRevista.VisualizarRevista(true);
                        break;
                }
            }

            if (opcaoPrincipal == "S")
            {
                break;
            }
        } 
        
    }
}
