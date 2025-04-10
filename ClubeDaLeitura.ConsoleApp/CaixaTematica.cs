namespace ClubeDaLeitura.ConsoleApp;

public class CaixaTematica
{
    public string Etiqueta = " ";
    public DateTime Prazo = default;
    public byte Raridade = 0;

    public CaixaTematica(string etiqueta, DateTime prazo, byte raridade) 
    { 
        Etiqueta = etiqueta;
        Prazo = prazo;
        Raridade = raridade;
    }
}
