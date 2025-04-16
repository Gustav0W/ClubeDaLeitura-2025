using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

namespace ClubeDaLeitura.ConsoleApp.MóduloRevista;

public class RepositorioRevista
{
    public RepositorioCaixa repositorioCaixa;

    public RepositorioRevista(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    List<Revista> revistas = new List<Revista>();
    int contadorRevistas = 0;

    public void AdicionarNaLista(Revista novaRevista)
    {
        revistas.Add(novaRevista);
    }
    public void CadastrarRevista(Revista novaRevista)
    {
        novaRevista.Id = GeradorId.GerarIdRevista();

        revistas[contadorRevistas++] = novaRevista;
    }
    public bool EditarRevista(int idRevista, Revista revistaEditada)
    {
        foreach (Revista revista in revistas)
        {
            if (revista == null) continue;

            else if (revista.Id == idRevista)
            {
                revista.Titulo = revistaEditada.Titulo;
                revista.NumeroEdicao = revistaEditada.NumeroEdicao;
                revista.AnoPublicacao = revistaEditada.AnoPublicacao;

                return true;
            }
        }
        return false;
    }
    public bool ExcluirRevista(int idRevista)
    {
        Revista revistaEncontrada = revistas.Find(Revista => Revista.Id == idRevista)!;

        if (revistaEncontrada == null)
        {
            Notificador.ExibirMensagem("Revista não encontrada!", ConsoleColor.Red);

            return false;
        }

        revistas.Remove(revistaEncontrada);

        Notificador.ExibirMensagem("Revista excluída com sucesso!", ConsoleColor.Green);
        return true;

    }
    public void ExibirListaRevista()
    {
        foreach (Revista revista in revistas)
        {
            if (revista == null) continue;
            else
            {
                Console.Write($"\nId: {revista.Id}\nTitulo: {revista.Titulo}\nEdição: {revista.NumeroEdicao}\nAno de publicação:{revista.AnoPublicacao}");
                Console.WriteLine("\n===============================================================");
            }
        }
    }
    public Revista ProcurarRevista(int idRevista)
    {
        Revista revistaEncontrada = revistas.Find(revista => revista.Id == idRevista)!;
        return revistaEncontrada;
    }
    public void AdicionarRevistaNaCaixa(Revista revistaEncontrada, CaixaTematica caixaEncontrada)
    {
        if (revistaEncontrada == null || caixaEncontrada == null)
            return;

        if (caixaEncontrada.RevistasNaCaixa == null)
            caixaEncontrada.RevistasNaCaixa = new List<Revista>();

        caixaEncontrada.RevistasNaCaixa.Add(revistaEncontrada);
    }

}