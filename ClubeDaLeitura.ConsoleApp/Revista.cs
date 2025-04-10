namespace ClubeDaLeitura.ConsoleApp;

public class Revista
{
    public string Titulo = string.Empty;
    public int NumeroEdicao = 0;
    public DateTime AnoPublicacao;
    public CaixaTematica CaixaTematica { get; set; }
}
