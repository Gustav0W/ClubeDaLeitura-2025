namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa;

public class CaixaTematica
{
    public int Id = 0;
    public string Titulo = " ";
    public char Etiqueta = ' ';
    public byte Raridade = 0;

    public CaixaTematica(string titulo, char etiqueta, byte raridade) 
    {
        Titulo = titulo;
        Etiqueta = etiqueta;
        Raridade = raridade;
    }
}
