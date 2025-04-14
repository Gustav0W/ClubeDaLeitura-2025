//using ClubeDaLeitura.ConsoleApp.Compartilhados;
//using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
//using ClubeDaLeitura.ConsoleApp.MóduloCaixa;

//namespace ClubeDaLeitura.ConsoleApp.MóduloEmprestimo;

//public class TelaEmprestimo
//{
//    Amigo[] meusAmigos = new Amigo[10];
    
//    public void ExibirCabecalho()
//    {
//        Console.Clear();
//        Console.WriteLine("==================================");
//        Console.WriteLine("|         CLUBE DO LIVRO         |");
//        Console.WriteLine("|            GUSTAVO W           |");
//        Console.WriteLine("==================================");
//    }
//    public string ExibirTelaEmprestimo()
//    {
//        ExibirCabecalho();
//        Console.WriteLine("|      Gerenciando emprestimo     |");
//        Console.WriteLine("==================================");
//        Console.WriteLine("| 1 - Cadastrar Novo emprestimo  |");
//        Console.WriteLine("| 2 - Editar Emprestimo          |");
//        Console.WriteLine("| 3 - Excluir Emprestimo         |");
//        Console.WriteLine("| 4 - Visualizar Emprestimos     |");
//        Console.WriteLine("| S - Voltar                     |");
//        Console.WriteLine("==================================\n");
//        Console.Write("Informe uma opção válida: ");
//        string opcaoEscolhida = Console.ReadLine()!;
//        return opcaoEscolhida;
//    }
//    public void CadastrarNovoEmprestimo()
//    {
//        ExibirCabecalho();
//        Console.WriteLine("|       Anotando Emprestimo      |");
//        Console.WriteLine("==================================");

//        Emprestimo novoEmprestimo = ObterDadosEmprestimo();

//        repositorioEmprestimo.CadastrarEmprestimo(novoEmprestimo);

//        Notificador.ExibirMensagem("Novo emprestimo criado com sucesso!", ConsoleColor.Green);
//    }
//    public void EditarEmprestimo()
//    {
//        ExibirCabecalho();
//        Console.WriteLine("|       Editando Emprestimo      |");
//        Console.WriteLine("==================================");

//        VisualizarEmprestimo(false);

//        Console.Write("Digite o Id do emprestimo que deseja editar: ");
//        int idSelecionado = Convert.ToInt32(Console.ReadLine());

//        Emprestimo emprestimoAntigo = repositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado);
//        Emprestimo emprestimoEditado = ObterDadosEmprestimo();

//        bool conseguiuEditar = repositorioEmprestimo.EditarEmprestimo(idSelecionado, emprestimoEditado);

//        if (!conseguiuEditar)
//        {
//            Notificador.ExibirMensagem("Não foi possível editar o emprestimo", ConsoleColor.Red);

//            return;
//        }
//        Notificador.ExibirMensagem("O emprestimo foi editado com sucesso!", ConsoleColor.Green);
//    }
//    public void ExcluirEmprestimo()
//    {
//        ExibirCabecalho();
//        Console.WriteLine("|       Excluir emprestimo       |");
//        Console.WriteLine("==================================");

//        VisualizarEmprestimo(false);

//        Console.Write("Digite o Id do emprestimo que deseja excluir: ");
//        int idSelecionado = Convert.ToInt32(Console.ReadLine());

//        Emprestimo emprestiomoSelecionado = repositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado);

//        bool conseguiuExcluir = repositorioEmprestimo.ExcluirEmprestimo(idSelecionado);

//        if (!conseguiuExcluir)
//        {
//            Notificador.ExibirMensagem("Não foi possível excluir o emprestimo", ConsoleColor.Red);

//            return;
//        }
//        Notificador.ExibirMensagem("Emprestimo excluída com sucesso!", ConsoleColor.Green);
//    }
//    public void VisualizarEmprestimo(bool exibirTitulo)
//    {
//        if (exibirTitulo)
//            ExibirCabecalho();

//        Console.WriteLine("|     Visualizando emprestimo     |");
//        Console.WriteLine("==================================");

//        Emprestimo[] emprestimosRegistrados = repositorioEmprestimo.SelecionarEmprestimos();

//        for (int i = 0; i < emprestimosRegistrados.Length; i++)
//        {
//            Emprestimo e = emprestimosRegistrados[i];

//            if (e == null) continue;

//            Console.Write($"Id: {e.Id}\nTitulo: {ct.Titulo}\nRaridade: {raridadeEscrita}\n");
//            Console.WriteLine("-------------------------------------------------");

//        }
//        Notificador.ExibirMensagem("Aperte ENTER para continuar...", ConsoleColor.DarkYellow);
//    }
//    public Emprestimo ObterDadosEmprestimo()
//    {
//        Console.Write("Nome do amigo: ");
//        string nomeAmigo = Console.ReadLine()!;

//        Console.Write($"o Id da revista que {nomeAmigo} pegou: ");
//        int Id = Convert.ToInt32(Console.ReadLine())!;

//        Console.Write($"Informe a data que {nomeAmigo} pegou a revista(dd/MM/aaaa): ");
//        DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

//        Console.Write("Informe a data limite do empréstimo: ");
//        DateTime dataLimite = Convert.ToDateTime(Console.ReadLine());

//        Emprestimo emprestimo = new Emprestimo(nomeAmigo, Id, dataEmprestimo, dataLimite);

//        return emprestimo;
//    }
//}
