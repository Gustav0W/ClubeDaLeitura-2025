using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;
public class TelaEmprestimo
{
    public static RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
    public static RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
    public static RepositorioRevista repositorioRevista = new RepositorioRevista(repositorioCaixa);

    public RepositorioAmigo RepositorioAmigo;
    public RepositorioRevista RepositorioRevista;
    public RepositorioEmprestimo RepositorioEmprestimo;
    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    { 
        RepositorioAmigo = repositorioAmigo;
        RepositorioRevista = repositorioRevista;
        RepositorioEmprestimo = repositorioEmprestimo;
    }

    public TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
    public static TelaCaixaTematica telaCaixa = new TelaCaixaTematica();
    public TelaRevista exibirTelaRevista = new TelaRevista(repositorioRevista, repositorioCaixa, telaCaixa);

    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("|         CLUBE DO LIVRO         |");
        Console.WriteLine("|            GUSTAVO W           |");
        Console.WriteLine("==================================");
    }
    public string ExibirTelaEmprestimo()
    {
        ExibirCabecalho();
        Console.WriteLine("|      Gerenciando emprestimo     |");
        Console.WriteLine("==================================");
        Console.WriteLine("| 1 - Cadastrar Novo emprestimo  |");
        Console.WriteLine("| 2 - Editar Emprestimo          |");
        Console.WriteLine("| 3 - Excluir Emprestimo         |");
        Console.WriteLine("| 4 - Visualizar Emprestimos     |");
        Console.WriteLine("| S - Voltar                     |");
        Console.WriteLine("==================================\n");
        Console.Write("Informe uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;
        return opcaoEscolhida;
    }
    public void CadastrarNovoEmprestimo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Anotando Emprestimo      |");
        Console.WriteLine("==================================");

        Emprestimo novoEmprestimo = ObterDadosEmprestimo();

        RepositorioEmprestimo.AdicionarNaListaEmprestimo(novoEmprestimo);
        RepositorioEmprestimo.CadastrarEmprestimo(novoEmprestimo);

        Notificador.ExibirMensagem("Novo emprestimo criado com sucesso!", ConsoleColor.Green);
    }
    public void EditarEmprestimo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Editando Emprestimo      |");
        Console.WriteLine("==================================");

        VisualizarEmprestimo(false);

        Console.Write("Digite o Id do emprestimo que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Emprestimo emprestimoAntigo = RepositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado);
        Emprestimo emprestimoEditado = ObterDadosEmprestimo();

        bool conseguiuEditar = RepositorioEmprestimo.EditarEmprestimo(idSelecionado, emprestimoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Não foi possível editar o emprestimo", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("O emprestimo foi editado com sucesso!", ConsoleColor.Green);
    }
    public void ExcluirEmprestimo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Excluir emprestimo       |");
        Console.WriteLine("==================================");

        VisualizarEmprestimo(false);

        Console.Write("Digite o Id do emprestimo que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = RepositorioEmprestimo.ExcluirEmprestimo(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Não foi possível excluir o emprestimo", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("Emprestimo excluída com sucesso!", ConsoleColor.Green);
    }
    public void VisualizarEmprestimo(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine("|     Visualizando emprestimo     |");
        Console.WriteLine("==================================");

        RepositorioEmprestimo.ExibirListaEmprestimo();
        Console.WriteLine("\n===========================================");

        Notificador.ExibirMensagem("Aperte ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public Emprestimo ObterDadosEmprestimo()
    {
        repositorioAmigo.ExibirListaAmigos();
        //Pegar ID do AMIGO
        Console.Write("Digite o Id do amigo: ");
        if (!int.TryParse(Console.ReadLine(), out int idAmigo))
        {
            Notificador.ExibirMensagem("Id inválido", ConsoleColor.Red);
            return null!;
        }

        Amigo amigoEscolhido = RepositorioAmigo.SelecionarAmigoPorId(idAmigo);
        

        //Pegar ID da REVISTAAAAAAAAAAA
        RepositorioRevista.ExibirListaRevista();

        Console.Write($"Digite o Id da revista que {amigoEscolhido.Nome} pegou: ");
        if (!int.TryParse(Console.ReadLine(), out int idRevista))
        {
            Notificador.ExibirMensagem("Id inválido", ConsoleColor.Red);
            return null!;
        }

        Revista revistaEscolhida = RepositorioRevista.ProcurarRevista(idRevista);
        if (revistaEscolhida == null)
        {
            Notificador.ExibirMensagem("Revista não encontrada!", ConsoleColor.Red);
        }

        Console.Write($"Informe a data que {amigoEscolhido.Nome} pegou a revista(dd/MM/aaaa): ");
        DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Informe a data limite do empréstimo: ");
        DateTime dataLimite = Convert.ToDateTime(Console.ReadLine());

        Emprestimo emprestimo = new Emprestimo(amigoEscolhido, revistaEscolhida!, dataEmprestimo, dataLimite);

        return emprestimo;
    }
}
