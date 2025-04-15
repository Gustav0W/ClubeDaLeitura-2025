using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;

public class Emprestimo
{
    public int Id = 0;
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataLimite { get; set; }
    public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo, DateTime dataLimite)
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = dataEmprestimo;
        DataLimite = dataLimite;
    }
}
