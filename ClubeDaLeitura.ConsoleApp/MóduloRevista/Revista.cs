using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

namespace ClubeDaLeitura.ConsoleApp.MóduloRevista;

public class Revista
{
    public int Id = 0;
    public string Titulo = string.Empty;
    public int NumeroEdicao = 0;
    public string AnoPublicacao;
    public CaixaTematica? Caixa;
    public string Status = string.Empty;
    public Revista(string titulo, int numeroEdicao, string anoPublicacao, string status)
    {
        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        AnoPublicacao = anoPublicacao;
        Caixa = null;
        Status = "Disponível";
    }
}