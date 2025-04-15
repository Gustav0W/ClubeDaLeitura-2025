using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

namespace ClubeDaLeitura.ConsoleApp.MóduloRevista;

public class TelaRevista
{
    RepositorioRevista repositorioRevista;
    RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("|         CLUBE DO LIVRO         |");
        Console.WriteLine("|            GUSTAVO W           |");
        Console.WriteLine("==================================");
    }
    public string ExibirTelaRevistas()
    {
        ExibirCabecalho();
        Console.WriteLine("|      Gerenciando revistas      |");
        Console.WriteLine("==================================");
        Console.WriteLine("| 1 - Cadastrar Nova Revista     |");
        Console.WriteLine("| 2 - Editar Revista             |");
        Console.WriteLine("| 3 - Excluir Revista            |");
        Console.WriteLine("| 4 - Visualizar Revista         |");
        Console.WriteLine("| 5 - Adicionar Revista em caixa |");
        Console.WriteLine("| S - Voltar                     |");
        Console.WriteLine("==================================\n");
        Console.Write("Informe uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;
        return opcaoEscolhida;
    }
    public void CadastrarRevista()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Cadastrando revista      |");
        Console.WriteLine("==================================");

        Revista novaRevista = ObterDadosRevista();

        repositorioRevista.AdicionarNaLista(novaRevista);
        repositorioRevista.CadastrarRevista(novaRevista);

        Notificador.ExibirMensagem("Nova revista cadastrada e adicionada a lista de revistas!", ConsoleColor.Green);
    }
    public void EditarRevista()
    {
        ExibirCabecalho();
        Console.WriteLine("|        Editando revista        |");
        Console.WriteLine("==================================");

        VisualizarRevista(false);

        Console.Write("Digite o Id da revista que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Revista revistaAntiga = repositorioRevista.SelecionarRevistaPorId(idSelecionado);
        Revista revistaEditada = ObterDadosRevista();

        bool conseguiuEditar = repositorioRevista.EditarRevista(idSelecionado, revistaEditada);
        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Não foi possível editar a revista...", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("Revista editada com sucesso!!", ConsoleColor.Green);
    }
    public void ExcluirRevista()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Excluindo revista        |");
        Console.WriteLine("==================================");

        VisualizarRevista(false);

        Console.Write("Digite o Id da revista que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioRevista.ExcluirRevista(idSelecionado);
        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Não foi possível excluir a revista", ConsoleColor.Red);
            return;
        }
        Notificador.ExibirMensagem("Revista excluída com sucesso", ConsoleColor.Green);
    }
    public void VisualizarRevista(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine("|      Visualizando revistas     |");
        Console.WriteLine("==================================");

        repositorioRevista.ExibirListaRevista();

        Notificador.ExibirMensagem("Pressione ENTER para continuar... ", ConsoleColor.DarkYellow);
    }
    public Revista ObterDadosRevista()
    {
        Console.Write("Digite o titulo da revista: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Informe o número da edição: ");
        int numeroEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Informe o ano de publicação: ");
        string anoPublicacao = Console.ReadLine()!;

        Revista novaRevista = new Revista(titulo, numeroEdicao, anoPublicacao);

        return novaRevista;
    }
    public void AdicionarRevistaNaCaixa()
    {
        Console.Write("Informe o Id da revista: ");
        if (!int.TryParse(Console.ReadLine()!, out int idRevista)) {
            Notificador.ExibirMensagem("Id digitado inválido!", ConsoleColor.Red);
        }
        Revista revistaEncontrada = repositorioRevista.ProcurarRevista(idRevista);
        Console.Write("Informe o Id da caixa que terá a revista adicionada: ");
        if (!int.TryParse(Console.ReadLine()!, out int idCaixa))
        {
            Notificador.ExibirMensagem("Id digitado inválido!", ConsoleColor.Red);
        }
        CaixaTematica caixaEncontrada = repositorioCaixa.SelecionarCaixaPorId(idCaixa);
            repositorioRevista.AdicionarRevistaNaCaixa(revistaEncontrada, caixaEncontrada);

        Notificador.ExibirMensagem("Revista adicionada com sucesso à caixa!", ConsoleColor.Green);
    }

}
