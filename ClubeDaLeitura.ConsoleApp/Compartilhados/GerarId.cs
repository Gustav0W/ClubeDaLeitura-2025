namespace ClubeDaLeitura.ConsoleApp.Compartilhados;

public static class GeradorId
{
    public static int IdAmigo = 0;
    public static int IdCaixa = 0;
    public static int GerarIdAmigo()
    {
        IdAmigo++;

        return IdAmigo;
    }
    public static int GerarIdCaixa()
    {
        IdCaixa++;
        return IdCaixa;
    }

}
