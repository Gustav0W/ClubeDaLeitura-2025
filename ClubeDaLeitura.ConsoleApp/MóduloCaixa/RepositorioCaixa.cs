using ClubeDaLeitura.ConsoleApp.Compartilhados;
using ClubeDaLeitura.ConsoleApp.MóduloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.MóduloCaixa
{
    public class RepositorioCaixa
    {
        CaixaTematica[] caixas = new CaixaTematica[10];
        int contadorCaixas = 0; 

        public ConsoleColor DefinirCor(ConsoleColor corEtiqueta)
        {
            char resposta = ' ';

            if (resposta == 'V')
                corEtiqueta = ConsoleColor.Red;

            else if (resposta == 'A')
                corEtiqueta = ConsoleColor.Blue;

            else if (resposta == 'C')
                corEtiqueta = ConsoleColor.Cyan;

            else if (resposta == 'R')
                corEtiqueta = ConsoleColor.Magenta;

            return corEtiqueta;
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
                else if (c.Id == idCaixa);
                return c;
            }
            return null;
        }
    }
}
