using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

namespace ClubeDaLeitura.ConsoleApp.MóduloRevista;

public class Revista
{
    public int Id = 0;
    public string Titulo = string.Empty;
    public int NumeroEdicao = 0;
    public string AnoPublicacao;

    public Revista(string titulo, int numeroEdicao, string anoPublicacao)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
    }
}