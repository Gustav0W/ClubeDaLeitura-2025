using ClubeDaLeitura.ConsoleApp.Compartilhados;

namespace ClubeDaLeitura.ConsoleApp.MóduloAmigo;

public class TelaAmigo
{
    public RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
    public TelaAmigo(RepositorioAmigo repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("|         CLUBE DO LIVRO         |");
        Console.WriteLine("|            GUSTAVO W           |");
        Console.WriteLine("==================================");
    }
    public string ExibirTelaAmigo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Gerenciando amigos       |");
        Console.WriteLine("==================================");
        Console.WriteLine("| 1 - Cadastrar Novo Amigo       |");
        Console.WriteLine("| 2 - Editar Cadastro de Amigo   |");
        Console.WriteLine("| 3 - Excluir Cadastro de Amigo  |");
        Console.WriteLine("| 4 - Visualizar Amigos          |");
        Console.WriteLine("| S - Voltar                     |");
        Console.WriteLine("==================================\n");
        Console.Write("Informe uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;

        return opcaoEscolhida;
    }
    public void CadastrarAmigo()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Cadastrando amigos       |");
        Console.WriteLine("==================================");

        Amigo novoAmigo = ObterDadosAmigo();


        repositorioAmigo.CadastrarAmigo(novoAmigo);

        Notificador.ExibirMensagem("Amigo cadastrado com sucesso!", ConsoleColor.Green);
    }
    public void EditarAmigo()
    {
        ExibirCabecalho();
        Console.WriteLine("|         Editando amigos        |");
        Console.WriteLine("==================================");

        VisualizarAmigos(false);

        Console.Write("Informe o ID do amigo que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoAntigo = repositorioAmigo.SelecionarAmigoPorId(idSelecionado);

        Amigo amigoEditado = ObterDadosAmigo();

        bool conseguiuEditar = repositorioAmigo.EditarAmigo(idSelecionado, amigoEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Ocorreu um erro durante a edição do amigo", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("O amigo foi editado com sucesso!", ConsoleColor.Green);


    }
    public void ExcluirAmigo()
    {
        ExibirCabecalho();
        Console.WriteLine("|         Excluindo amigos       |");
        Console.WriteLine("==================================");

        VisualizarAmigos(false);

        Console.Write("Digite o Id do amigo que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Amigo amigoSelecionado = repositorioAmigo.SelecionarAmigoPorId(idSelecionado);

        bool conseguiuExcluir = repositorioAmigo.ExcluirAmigo(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Não foi possível editar o amigo", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("Amigo excluído com sucesso!", ConsoleColor.Green);

    }
    public void VisualizarAmigos(bool exibirTitulo) 
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine("|       Visualizando amigos      |");
        Console.WriteLine("==================================");

        repositorioAmigo.ExibirListaAmigos();

        Notificador.ExibirMensagem("\nPressione ENTER para continuar... ", ConsoleColor.DarkYellow);
    }

    public Amigo ObterDadosAmigo()
    {
        Console.Write("Informe o nome: ");
        string nome = Console.ReadLine()!;
        Console.Write("Informe o nome do responsável: ");
        string responsavel = Console.ReadLine()!;
        Console.Write("Informe o telefone FORMATO (XX) XXXXX-XXXX: ");
        string telefone = Console.ReadLine()!;

        Amigo Amigo = new Amigo(nome, responsavel, telefone);

        return Amigo;
    }
}
