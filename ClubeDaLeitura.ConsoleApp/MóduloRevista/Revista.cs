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
        Status = "Disponível";
        Caixa = null;
    }

    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Titulo))
            erros += "\nO campo 'Título' é obrigatório.\n";
        else
        {
            if (Titulo.Length < 2 || Titulo.Length > 100)
                erros += "O campo 'Titulo' precisa conter ao menos 2 caracteres e não pode ter mais que 100 caracteres.\n";
        }

        if (string.IsNullOrWhiteSpace(NumeroEdicao.ToString()))
            erros += "O campo 'Número de Edição' é obrigatório.\n";
        else
        {
            if (NumeroEdicao < 0)
                erros += "O campo 'Número de Edição' precisa ser um número positivo.\n";
        }

        if (string.IsNullOrWhiteSpace(AnoPublicacao))
            erros += "O campo 'Ano de Publicação' é obrigatório.\n";

        return erros;
    }
    public void Emprestar()
    {
        Status = "Emprestada";
    }
    public void Devolver()
    {
        Status = "Disponível";
    }
}