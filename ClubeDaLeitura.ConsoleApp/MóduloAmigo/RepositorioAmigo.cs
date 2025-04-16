using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloAmigo;

public class RepositorioAmigo
{
    List<Amigo> amigos = new List<Amigo>();
    public int contadorAmigos = 0;
    public void CadastrarAmigo(Amigo novoAmigo)
    {
        amigos.Add(novoAmigo);

        novoAmigo.Id = GeradorId.GerarIdAmigo();

        amigos[contadorAmigos++] = novoAmigo;
    }
    public bool EditarAmigo(int idAmigo, Amigo amigoEditado)
    {
        foreach (Amigo amigo in amigos)
        {
            if (amigo == null) continue;

            else if (amigo.Id == idAmigo)
            {
                amigo.Nome = amigoEditado.Nome;
                amigo.Responsavel = amigoEditado.Responsavel;
                amigo.Telefone = amigoEditado.Telefone;

                return true;
            }
        }
        return false;
    }
    public bool ExcluirAmigo(int idAmigo)
    {
        Amigo amigoEncontrado = amigos.Find(Amigo => Amigo.Id == idAmigo);

        if (amigoEncontrado == null)
        {
            Notificador.ExibirMensagem("Amigo não encontrado!", ConsoleColor.Red);

            return false;
        }

        amigos.Remove(amigoEncontrado);

        Notificador.ExibirMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);
        return true;
    }
    public Amigo SelecionarAmigoPorId(int idAmigo)
    {
        foreach (Amigo amigo in amigos)
        {
            if (amigo == null)
                continue;

            else if (amigo.Id == idAmigo)
                return amigo;
        }
        return null;
    }
    public void ExibirListaAmigos()
    {
        foreach (Amigo amigo in amigos)
        {
            if (amigo == null) continue;
            else
            {
                Console.Write($"\nId: {amigo.Id}\nNome: {amigo.Nome}\nResponsável: {amigo.Responsavel}\nTelefone:{amigo.Telefone}");
                Console.WriteLine("\n===============================================================");
            }
        }
    }
}