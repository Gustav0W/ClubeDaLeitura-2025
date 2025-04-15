using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;
using System.ComponentModel;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;

public class RepositorioEmprestimo
{
    public RepositorioAmigo repositorioAmigo;
    public RepositorioRevista repositorioRevista;

    public RepositorioEmprestimo(RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    List<Emprestimo> emprestimos = new List<Emprestimo>();
    public int contadorEmprestimos = 0;

    public void AdicionarNaListaEmprestimo(Emprestimo novoEmprestimo)
    {
        emprestimos.Add(novoEmprestimo);
    }
    public void CadastrarEmprestimo(Emprestimo novoEmprestimo)
    {
        novoEmprestimo.Id = GeradorId.GerarIdEmprestimo();

        emprestimos[contadorEmprestimos++] = novoEmprestimo;
    }
    public bool EditarEmprestimo(int idEmprestimo, Emprestimo emprestimoEditado)
    {
        foreach (Emprestimo emprestimo in emprestimos) 
        {
            if (emprestimo == null) continue;

            else if (emprestimo.Id == idEmprestimo)
            {
                emprestimo.Amigo = emprestimoEditado.Amigo;
                emprestimo.Revista = emprestimoEditado.Revista;
                emprestimo.DataEmprestimo = emprestimoEditado.DataEmprestimo;
                emprestimo.DataLimite = emprestimoEditado.DataLimite;

                return true;
            }
        }
        return false;
    }
    public bool ExcluirEmprestimo(int idEmprestimo)
    {
        Emprestimo emprestimoEncontrado = emprestimos.Find(Emprestimo => Emprestimo.Id == idEmprestimo);

        if (emprestimoEncontrado == null)
        {
            Notificador.ExibirMensagem("Registo de empréstimo não encontrado!", ConsoleColor.Red);

            return false;
        }

        emprestimos.Remove(emprestimoEncontrado);
        return true;
    }
    public Emprestimo SelecionarEmprestimoPorId(int idEmprestimo)
    {
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo == null)
                continue;

            else if (emprestimo.Id == idEmprestimo)
                return emprestimo;
        }
        return null;
    }
    public void ExibirListaEmprestimo()
    {
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo == null) continue;
            else
            {
                Console.Write($"Id: {emprestimo.Id}\nAmigo que pegou: {emprestimo.Amigo.Nome}\n" +
                    $"Revista: {(emprestimo.Revista.Titulo)}\nData que pegou: {emprestimo.DataEmprestimo}\nData Limite: {emprestimo.DataLimite}");
            }
        }
    }
}
