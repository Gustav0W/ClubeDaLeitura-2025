using ClubeDaLeitura.ConsoleApp.Compartilhados;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa
{
    public class RepositorioCaixa
    {
        CaixaTematica[] caixas = new CaixaTematica[10];
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
        public bool EditarCaixa(int idCaixa, CaixaTematica caixaEditada)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null) continue;

                else if (caixas[i].Id == idCaixa)
                {
                    caixas[i].Titulo = caixaEditada.Titulo;
                    caixas[i].Etiqueta = caixaEditada.Etiqueta;
                    caixas[i].Raridade = caixaEditada.Raridade;

                    return true;
                }
            }
            return false;
        }
        public bool ExcluirCaixa(int idCaixa)
        {
            for (int i = 0; i <= caixas.Length; i++)
            {
                if (caixas[i] == null) continue;

                else if (caixas[i].Id == idCaixa)
                {
                    caixas[i] = null;
                    return true;
                }
            }
            return false;
        }
        public CaixaTematica[] SelecionarCaixas()
        {
            return caixas;
        }
        public CaixaTematica SelecionarCaixaPorId(int idCaixa)
        {
            for (int i = 0; i < caixas.Length; i++)
            {
                CaixaTematica c = caixas[i];

                if (c == null)
                    continue;

                else if (c.Id == idCaixa)
                    return c;
            }
            return null;
        }
    }
}
