using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa;

public class CaixaTematica
{
    public int Id = 0;
    public string Titulo = " ";
    public string Etiqueta = " ";
    public byte Raridade = 0;
    public int DiasEmprestimo;
    public ConsoleColor Cor { get; set; }
    public List<Revista> RevistasNaCaixa = new List<Revista>();

    public CaixaTematica(string titulo, string etiqueta, byte raridade, ConsoleColor cor)
    {
        Titulo = titulo;
        Etiqueta = etiqueta;
        Raridade = raridade;
        Cor = cor;
    }
    public CaixaTematica()
    {
    }
    public string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Etiqueta))
            erros += "\nÉ obrigatório preencher o nome.\n";
        else
        {
            if (!Etiqueta.All(char.IsLetter))
                erros += "'Etiqueta' precisa conter apenas letras.\n";

            if (Etiqueta.Length > 50)
                erros += "'Etiqueta' não pode ter mais que 50 caracteres.\n";
        }

        if (string.IsNullOrWhiteSpace(Cor.ToString()))
            erros += "É obrigatório definir uma cor.\n";


        if (string.IsNullOrEmpty(Raridade.ToString()))
            erros += "O campo <Raridade> é obrigatório\n";
        else
            if (Raridade != 1 && Raridade != 2)
            erros += "O campo <Raridade> está inválido! Verifique novamente.";

        return erros;
    }
    public void DefinirDiasDeEmprestimo(int raridade)
    {
        if (raridade == 1) DiasEmprestimo = 7;
        if (raridade == 2) DiasEmprestimo = 3;
        
    }
    public void AdicionarRevista(Revista revista)
    {
        if (revista.Caixa != null)
        {
            Console.WriteLine("A revista já está associada a uma caixa.");
            return;
        }

        this.RevistasNaCaixa.Add(revista);
        revista.Caixa = this;
    }
    public void RemoverRevista(Revista revista)
    {
        if (revista.Caixa == null)
        {
            Notificador.ExibirMensagem("Essa revista já não está em nenhuma caixa", ConsoleColor.Red);
            return;
        }
        this.RevistasNaCaixa.Remove(revista);
        revista.Caixa = null;
    }
}