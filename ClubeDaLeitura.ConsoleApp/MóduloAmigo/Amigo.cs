using System.ComponentModel;

namespace ClubeDaLeitura.ConsoleApp.MóduloAmigo;

public class Amigo
{
    public int Id = 0;
    public string Nome = " ";
    public string Responsavel = " ";
    public string Telefone = " ";
    
    public Amigo(string nome, string responsavel, string telefone)
    {
        Nome = nome;
        Responsavel = responsavel;
        Telefone = telefone;
    }

}
