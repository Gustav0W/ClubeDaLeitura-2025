using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa;

public class CaixaTematica
{
    public int Id = 0;
    public string Titulo = " ";
    public char Etiqueta = ' ';
    public byte Raridade = 0;
    public ConsoleColor Cor {  get; set; }
    public List<Revista> Revistas { get; set; } = new List<Revista>();

    public CaixaTematica(string titulo, char etiqueta, byte raridade, ConsoleColor cor) 
    {
        Titulo = titulo;
        Etiqueta = etiqueta;
        Raridade = raridade;
        Cor = cor;
    }
    public CaixaTematica()
    {
    }
}
