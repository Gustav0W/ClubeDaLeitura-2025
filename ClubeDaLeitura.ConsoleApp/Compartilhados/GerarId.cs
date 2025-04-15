namespace ClubeDaLeitura.ConsoleApp.Compartilhados;

public static class GeradorId
{
    public static int IdAmigo = 0;
    public static int IdCaixa = 0;
    public static int IdRevista = 0;
    public static int IdEmprestimo = 0;

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
    public static int GerarIdRevista()
    {
        IdRevista++;
        return IdRevista;
    }
    public static int GerarIdEmprestimo()
    {
        IdEmprestimo++;
        return IdEmprestimo;    
    }

}
