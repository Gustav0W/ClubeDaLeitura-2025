using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloRevista;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa
{
    public class RepositorioCaixa
    {
        RepositorioRevista repositorioRevista;
        public RepositorioRevista _repositorioRevista;

        public RepositorioCaixa() { }

        public void DefinirRepositorioRevista(RepositorioRevista repositorioRevista)
        {
            _repositorioRevista = repositorioRevista;
        }

        public RepositorioCaixa(RepositorioRevista repositorioRevista)
        {
            this.repositorioRevista = repositorioRevista;
        }

        List<CaixaTematica> caixas = new List<CaixaTematica>();

        int contadorCaixas = 0;

        public ConsoleColor DefinirCor(char resposta)
        {

            return resposta switch
            {
                'A' => ConsoleColor.Blue,
                'V' => ConsoleColor.Red,
                'C' => ConsoleColor.Cyan,
                'R' => ConsoleColor.Magenta,
                _ => ConsoleColor.White,
            };
        }
        public void CadastrarCaixa(CaixaTematica novaCaixa)
        {
            novaCaixa.Id = GeradorId.GerarIdCaixa();

            caixas[contadorCaixas++] = novaCaixa;
        }
        public void AdicionarCaixaNaLista(CaixaTematica novaCaixa)
        {
            caixas.Add(novaCaixa);
        }
        public bool EditarCaixa(int idCaixa, CaixaTematica caixaEditada)
        {
            foreach (CaixaTematica caixa in caixas)
            {
                if (caixa == null) continue;

                else if (caixa.Id == idCaixa)
                {
                    caixa.Titulo = caixaEditada.Titulo;
                    caixa.Etiqueta = caixaEditada.Etiqueta;
                    caixa.Raridade = caixaEditada.Raridade;

                    return true;
                }
            }
            return false;
        }
        public bool ExcluirCaixa(int idCaixa)
        {
            CaixaTematica caixaEncontrada = caixas.Find(Caixa => Caixa.Id == idCaixa)!;

            if (caixaEncontrada == null) return false;

            caixas.Remove(caixaEncontrada);
            return true;
        }
        public void ExibirListaDeCaixas()
        {
            foreach (CaixaTematica caixa in caixas)
            {
                if (caixa == null) continue;

                string raridadeEscrita = caixa.Raridade == 1 ? "Comum" : "Raro";

                Console.ForegroundColor = caixa.Cor;

                Console.Write($"\nId: {caixa.Id}\nTitulo: {caixa.Titulo}\nEtiqueta:{caixa.Etiqueta}\nEdição: {caixa.Raridade}\nDias de empréstimo: {caixa.DiasEmprestimo}");
                Console.WriteLine("\n===============================================================");

                Console.ResetColor();
            }
            Notificador.ExibirMensagem("Aperte ENTER para continuar...", ConsoleColor.DarkYellow);
        }
        public CaixaTematica ProcurarCaixa(int idCaixa)
        {
            CaixaTematica caixaEncontrada = caixas.Find(caixa => caixa.Id == idCaixa)!;
            if (caixaEncontrada != null)
            {
                return caixaEncontrada;
            }
            else
            {
                Notificador.ExibirMensagem("Não foi possível encontrar uma caixa", ConsoleColor.Red);
                return null!;
            }
        }
        public bool VerificarEtiqueta(CaixaTematica caixaVerificar)
        {
            foreach (CaixaTematica caixa in caixas)
            {
                if (caixa == null) continue;

                if (caixaVerificar.Etiqueta == caixa.Etiqueta)
                    return true;
            }
            return false;
        }
    }
}