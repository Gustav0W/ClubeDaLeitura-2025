using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;

public class Emprestimo
{
    public int Id = 0;
    public Amigo Amigo;
    public Revista Revista;
    public DateTime Data;
    public string Situacao;
    public Emprestimo(Amigo amigo, Revista revista, string situacao)
    {
        Amigo = amigo;
        Revista = revista;
        Data = DateTime.Now;
        Situacao = situacao;
    }

    public string Validar()
    {
        string erros = "";

        if (Amigo == null)
            erros += "\nVocê tem que selecionar pelo menos menos um Amigo.\n";

        if (Revista == null)
            erros += "\nVocê tem que selecionar pelo menos uma Revista.";

        if (string.IsNullOrEmpty(Situacao))
            erros += "\nCampo 'Situação' é obrigatório.";
        else
        {
            if (Situacao != "Aberto" || Situacao != "Concluído")
                erros += "\nCampo 'Situação' precisa ser 'Aberto' ou 'Concluído'!";
        }
        return erros;
    }
    public DateTime ObterDataDevolucao()
    {
        return Data.AddDays(Revista.Caixa.DiasEmprestimo);
    }

    public void RegistrarDevolucao()
    {
        Situacao = "Concluído";
        Revista.Devolver();
    }
}