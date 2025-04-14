using ClubeDaLeitura.ConsoleApp.Compartilhados;

namespace ClubeDaLeitura.ConsoleApp.MóduloAmigo;

public class RepositorioAmigo
{
    Amigo[] amigos = new Amigo[10];
    public int contadorAmigos = 0;
    public void CadastrarAmigo(Amigo novoAmigo)
    {
        novoAmigo.Id = GeradorId.GerarIdAmigo();

        amigos[contadorAmigos++] = novoAmigo;
    }
    public bool EditarAmigo (int idAmigo, Amigo amigoEditado)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            else if (amigos[i].Id == idAmigo)
            {
                amigos[i].Nome = amigoEditado.Nome;
                amigos[i].Responsavel = amigoEditado.Responsavel;
                amigos[i].Telefone = amigoEditado.Telefone;

                return true;
            }
        }
        return false;
    }
    public bool ExcluirAmigo(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            if (amigos[i] == null) continue;

            else if (amigos[i].Id == idAmigo)
            {
                amigos[i] = null;

                return true;
            }
        }

        return false;
    }
    public Amigo[] SelecionarAmigos()
    {
        return amigos;
    }
    public Amigo SelecionarAmigoPorId(int idAmigo)
    {
        for (int i = 0; i < amigos.Length; i++)
        {
            Amigo a = amigos[i];

            if (a == null)
                continue;
            else if (a.Id == idAmigo) ;
                return a;
        }

        return null;
    }
}
