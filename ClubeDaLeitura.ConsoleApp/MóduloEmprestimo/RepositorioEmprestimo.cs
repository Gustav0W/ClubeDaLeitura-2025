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
        //novoEmprestimo.Revista.Emprestar();
        //novoEmprestimo.Amigo.BuscarEmprestimo(novoEmprestimo);
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
                return true;
            }
        }
        return false;
    }
    public bool ExcluirEmprestimo(int idEmprestimo)
    {
        Emprestimo emprestimoEncontrado = emprestimos.Find(Emprestimo => Emprestimo.Id == idEmprestimo)!;

        if (emprestimoEncontrado == null)
        {
            Notificador.ExibirMensagem("Registo de empréstimo não encontrado!", ConsoleColor.Red);

            return false;
        }

        emprestimos.Remove(emprestimoEncontrado);
        return true;
    }
    public bool VerificarEmprestimoAtivo(Amigo amigoEncontrado)
    {
        if (amigoEncontrado.Emprestimos == null)
            return false;

        foreach (Emprestimo emprestimo in amigoEncontrado.Emprestimos)
        {
            if (emprestimo == null) continue;

            if (emprestimo.Situacao == "Aberto") return true;
        }
        return false;
    }
    public bool VerificarDevolucao(Emprestimo emprestimoEncontrado)
    {
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo == null) continue;

            if (emprestimoEncontrado.Id == emprestimo.Id && emprestimoEncontrado.Situacao == "Concluído");
            return true;
        }
        return false;
    }
    public void VerificarAtraso(List<Emprestimo> emprestimosCadastrados)
    {
        foreach (Emprestimo emprestimo in emprestimosCadastrados)
        {
            if (emprestimo == null) continue;

            if (emprestimo.Situacao == "Concluído") continue;

            if (DateTime.Now > emprestimo.ObterDataDevolucao())
                emprestimo.Situacao = "Atrasado";
        }
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
        return null!;
    }
    public void ExibirListaEmprestimo()
    {
        foreach (Emprestimo emprestimo in emprestimos)
        {
            if (emprestimo == null) continue;
            else
            {
                Console.Write($"Id: {emprestimo.Id}\nAmigo que pegou: {emprestimo.Amigo.Nome}\n" +
                    $"Revista: {(emprestimo.Revista.Titulo)}\nData Devolução: {emprestimo.ObterDataDevolucao().ToShortDateString()}\nData Limite:");
                Console.Write("\n=============================================================\n");
            }
        }
    }
}