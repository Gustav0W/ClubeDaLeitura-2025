using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;

public class Emprestimo
{
    Amigo Amigo { get; set; }
    Revista Revista { get; set; }
    DateTime DataEmprestimo;
    DateTime DataRevista { get; set; }
}
