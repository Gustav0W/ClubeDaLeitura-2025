using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

namespace ClubeDaLeitura.ConsoleApp.MóduloRevista;

public class RepositorioRevista
{
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
    public Revista SelecionarRevistaPorId(int idRevista)
    {
        foreach (Revista revista in revistas)
        {
            if (revista == null)
                continue;

            else if (revista.Id == idRevista)
                return revista;
        }
        return null;
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
        Revista revistaEncontrada = revistas.Find(Revista =>  Revista.Id == idRevista);

        if (revistaEncontrada == null)
        {
            Notificador.ExibirMensagem("Revista não encontrada!", ConsoleColor.Red);

            return false;
        }

        revistas.Remove(revistaEncontrada);
        return true;

    }
    public void ExibirListaRevista()
    {
        foreach (Revista revista in revistas)
        {
            if (revista == null) continue;
            else
            {
                Console.Write($"Id: {revista.Id}\nTitulo: {revista.Titulo}\nEdição: {revista.NumeroEdicao}\nAno de publicação:{revista.AnoPublicacao}");
            }
        }
    }
}
