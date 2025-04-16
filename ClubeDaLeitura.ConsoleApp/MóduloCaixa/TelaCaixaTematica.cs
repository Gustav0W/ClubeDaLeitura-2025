using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa;

public class TelaCaixaTematica
{
    RepositorioCaixa repositorioCaixa;

    public TelaCaixaTematica(RepositorioCaixa repositorioCaixa)
    {
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
    public string ExibirTelaCaixa()
    {
        ExibirCabecalho();
        Console.WriteLine("|       Gerenciando caixas       |");
        Console.WriteLine("==================================");
        Console.WriteLine("| 1 - Cadastrar Nova Caixa       |");
        Console.WriteLine("| 2 - Editar Caixa               |");
        Console.WriteLine("| 3 - Excluir Caixa              |");
        Console.WriteLine("| 4 - Visualizar Caixas          |");
        Console.WriteLine("| 5 - Ver revistas na Caixa      |");
        Console.WriteLine("| S - Voltar                     |");
        Console.WriteLine("==================================\n");
        Console.Write("Informe uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;
        return opcaoEscolhida;
    }
    public void CadastrarNovaCaixa()
    {
        ExibirCabecalho();
        Console.WriteLine("|        Cadastrando caixa       |");
        Console.WriteLine("==================================");

        CaixaTematica novaCaixa = ObterDadosCaixa();

        string erros = novaCaixa.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine(erros);
            Console.Write("\nPara tentar novamente, pressione uma tecla qualquer");
            Console.ReadKey();
            CadastrarNovaCaixa();
            return;
        }

        if (repositorioCaixa.VerificarEtiqueta(novaCaixa))
        {
            Console.WriteLine("\nExiste uma caixa com a mesma etiqueta");
            Console.Write("Para tentar novamente, pressione uma tecla qualquer");
            Console.ReadKey();
            CadastrarNovaCaixa();
            return;
        }

        repositorioCaixa.AdicionarCaixaNaLista(novaCaixa);
        repositorioCaixa.CadastrarCaixa(novaCaixa);

        Notificador.ExibirMensagem("Nova Caixa criada com sucesso!", ConsoleColor.Green);
    }
    public void EditarCaixa()
    {
        ExibirCabecalho();
        Console.WriteLine("|          Editando caixa        |");
        Console.WriteLine("==================================");

        VisualizarCaixas(false);

        Console.Write("Digite o Id da caixa que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        CaixaTematica caixaAntiga = repositorioCaixa.ProcurarCaixa(idSelecionado);
        CaixaTematica caixaEditado = ObterDadosCaixa();

        bool conseguiuEditar = repositorioCaixa.EditarCaixa(idSelecionado, caixaEditado);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Não foi possível editar a caixa", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("A caixa foi editada com sucesso!", ConsoleColor.Green);
    }
    public void ExcluirCaixa()
    {
        ExibirCabecalho();
        Console.WriteLine("|           Excluir caixa        |");
        Console.WriteLine("==================================");

        VisualizarCaixas(false);

        Console.Write("Digite o Id da caixa que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        CaixaTematica caixaSelecionada = repositorioCaixa.ProcurarCaixa(idSelecionado);

        bool conseguiuExcluir = repositorioCaixa.ExcluirCaixa(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Não foi possível excluir a caixa", ConsoleColor.Red);

            return;
        }
        Notificador.ExibirMensagem("Caixa excluída com sucesso!", ConsoleColor.Green);
    }
    public void VisualizarCaixas(bool exibirTitulo)
    {
        if (exibirTitulo)
            ExibirCabecalho();

        Console.WriteLine("|       Visualizando caixas      |");
        Console.WriteLine("==================================");

        repositorioCaixa.ExibirListaDeCaixas();
    }
    public void ExibirRevistasNaCaixa()
    {
        VisualizarCaixas(true);

        Console.Write("Informe o Id da caixa que deseja ver: ");
        if (!int.TryParse(Console.ReadLine(), out int idSelecionado))
        {
            Notificador.ExibirMensagem("Id informado é inválido", ConsoleColor.Red);
            return;
        }

        CaixaTematica caixaSelecionada = repositorioCaixa.ProcurarCaixa(idSelecionado);
        if (caixaSelecionada == null)
        {
            Notificador.ExibirMensagem("Caixa não encontrada", ConsoleColor.Red);
            return;
        }

        Console.WriteLine($"\nRevistas registradas na caixa {caixaSelecionada.Titulo}");
        Console.WriteLine("==================================");

        foreach (Revista revista in caixaSelecionada.RevistasNaCaixa)
        {
            Console.WriteLine($"Id: {revista.Id}");
            Console.WriteLine($"Título: {revista.Titulo}");
            Console.WriteLine($"Número da Edição: {revista.NumeroEdicao}");
            Console.WriteLine($"Ano de Publicação: {revista.AnoPublicacao}");
            Console.WriteLine("----------------------------------");
        }
        Notificador.ExibirMensagem("Pressione ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public CaixaTematica ObterDadosCaixa()
    {
        Console.Write("Nome da caixa: ");
        string nome = Console.ReadLine()!;

        Console.Write("Etiqueta da caixa: ");
        string etiqueta = Console.ReadLine()!;

        Console.Write("Cor da caixa (A - Azul | V - Vermelho | C - Ciano | R - Rosa): ");
        char Cor = Convert.ToChar(Console.ReadLine()!.ToUpper());

        Console.Write("Digite a raridade da caixa(1 - comum | 2 - raro): ");
        if (!byte.TryParse(Console.ReadLine(), out byte raridade))
        {
            Notificador.ExibirMensagem("Número inválido, tente novamente.\nAperte ENTER para continuar", ConsoleColor.Red);
        }

        ConsoleColor cor = repositorioCaixa.DefinirCor(Cor);
        
        CaixaTematica Caixa = new CaixaTematica(nome, etiqueta, raridade, cor);
        Caixa.DefinirDiasDeEmprestimo(raridade);

        return Caixa;
    }

}