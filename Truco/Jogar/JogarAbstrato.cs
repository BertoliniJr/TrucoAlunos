using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace Truco.Jogar
{
    abstract class JogarAbstrato : IJogar
    {
        public EnumTipoJogo jogo { get; set; }

        public IJogador jogadorAtual { get; set; }
        protected List<ICartas> maoJogador;

        public JogarAbstrato(IJogador jogador, List<ICartas> mao)
        {
            jogo = Jogo.getJogo().tipoJogo;
            maoJogador = mao;
            jogadorAtual = jogador;
        }

        public abstract ICartas jogar();

        protected virtual void ordenar(List<ICartas> mao)
        {
            mao = mao.OrderBy(x => x.getPeso()).ToList();
        }
    }
}
