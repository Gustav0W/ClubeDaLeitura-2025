using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa;

public class TelaCaixaTematica
{
    RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
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

        CaixaTematica caixaAntiga = repositorioCaixa.SelecionarCaixaPorId(idSelecionado);
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

        CaixaTematica caixaSelecionada = repositorioCaixa.SelecionarCaixaPorId(idSelecionado);

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

        CaixaTematica[] caixasRegistradas = repositorioCaixa.SelecionarCaixas();

        for (int i = 0; i < caixasRegistradas.Length; i++)
        {
            string raridadeEscrita = " ";
            CaixaTematica ct = caixasRegistradas[i];

            if (ct == null) continue;

            if (ct.Raridade == 1)
                raridadeEscrita = "Comum";
            else
                raridadeEscrita = "Raro";

            Console.Write($"Id: {ct.Id}\nTitulo: {ct.Titulo}\nRaridade: {raridadeEscrita}\n");
            Console.WriteLine("-------------------------------------------------");

        }
        Notificador.ExibirMensagem("Aperte ENTER para continuar...", ConsoleColor.DarkYellow);
    }
    public CaixaTematica ObterDadosCaixa()
    {
        Console.Write("Nome da caixa: ");
        string nome = Console.ReadLine()!;

        Console.Write("Cor da caixa (A - Azul | V - Vermelho | C - Ciano | R - Rosa): ");
        char corEtiqueta = Convert.ToChar(Console.ReadLine()!);

        Console.Write("Digite a raridade da caixa(1 - comum | 2 - raro): ");
        if (!byte.TryParse(Console.ReadLine(), out byte raridade))
        {
            Notificador.ExibirMensagem("Número inválido, tente novamente.\nAperte ENTER para continuar", ConsoleColor.Red);
        }
        
        CaixaTematica Caixa = new CaixaTematica(nome, corEtiqueta, raridade);

        return Caixa;
    }

    

}
