using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;
public class TelaEmprestimo
{
    public RepositorioEmprestimo repositorioEmprestimo;
    public RepositorioAmigo repositorioAmigo;
    public RepositorioRevista repositorioRevista;
    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

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
        Console.WriteLine("| 5 - Registrar Devolução        |");
        Console.WriteLine("| S - Voltar                     |");
        Console.WriteLine("==================================\n");
        Console.Write("Informe uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if (opcaoEscolhida == null)
            return null!;
        else
            return opcaoEscolhida.Trim().ToUpper();
    }
    public void CadastrarNovoEmprestimo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Anotando Emprestimo      |");
        Console.WriteLine("==================================");

        Emprestimo novoEmprestimo = ObterDadosEmprestimo();

        if (novoEmprestimo == null) return;

        string erros = novoEmprestimo.Validar();

        if (erros.Length > 0)
        {
            Notificador.ExibirMensagem(erros, ConsoleColor.Red);
            Console.WriteLine("\nPressione qualquer tecla para tentar novamente");
            Console.ReadKey();
            CadastrarNovoEmprestimo();
            return;
        }

        this.repositorioEmprestimo.AdicionarNaListaEmprestimo(novoEmprestimo);
        this.repositorioEmprestimo.CadastrarEmprestimo(novoEmprestimo);

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

        Emprestimo emprestimoAntigo = repositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado);
        Emprestimo emprestimoEditado = ObterDadosEmprestimo();

        bool conseguiuEditar = repositorioEmprestimo.EditarEmprestimo(idSelecionado, emprestimoEditado);

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

        bool conseguiuExcluir = repositorioEmprestimo.ExcluirEmprestimo(idSelecionado);

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

        repositorioEmprestimo.ExibirListaEmprestimo();
        Console.WriteLine("\n===========================================");

        Notificador.ExibirMensagem("Aperte ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public Emprestimo ObterDadosEmprestimo()
    {

        repositorioAmigo.ExibirListaAmigos();

        if (repositorioAmigo.ExibirListaAmigos == null)
            return null!;

        //Pegar ID do AMIGO
        Console.Write("Digite o Id do amigo: ");
        if (!int.TryParse(Console.ReadLine(), out int idAmigo))
        {
            Notificador.ExibirMensagem("Id inválido", ConsoleColor.Red);
            return null!;
        }
        
        Amigo amigoEscolhido = repositorioAmigo.SelecionarAmigoPorId(idAmigo);

        if (repositorioEmprestimo.VerificarEmprestimoAtivo(amigoEscolhido))
        {
            Notificador.ExibirMensagem("\nEsse amigo já está com um empréstimo aberto", ConsoleColor.Red);
            return null!;
        }

        //Pegar ID da REVISTAAAAAAAAAAA
        repositorioRevista.ExibirListaRevista();

        if (repositorioRevista.ExibirListaRevista == null)
            return null!;

        Console.Write($"Digite o Id da revista que {amigoEscolhido.Nome} pegou: ");
        if (!int.TryParse(Console.ReadLine(), out int idRevista))
        {
            Notificador.ExibirMensagem("Id inválido", ConsoleColor.Red);
            return null!;
        }

        Revista revistaEscolhida = repositorioRevista.ProcurarRevista(idRevista);

        if (revistaEscolhida == null)
        {
            Notificador.ExibirMensagem("Revista não encontrada!", ConsoleColor.Red);
        }
        if (repositorioRevista.VerificarRevistaDisponivel(revistaEscolhida))
        {
            Console.WriteLine("\nEssa revista não está disponível", ConsoleColor.Red);
            return null!;
        }

        Emprestimo emprestimo = new Emprestimo(amigoEscolhido, revistaEscolhida!, "Aberto");

        return emprestimo;
    }

}