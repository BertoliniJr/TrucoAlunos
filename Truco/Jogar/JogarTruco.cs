using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.InfoJogo;
using Truco.Interfaces;

namespace Truco.Jogar
{
    class JogarTruco : IJogar
    {
        public event trucoseubosta truco;
        public delegate void trucoseubosta(IJogador jogador, EnumTruco truco);

        private InfoJogoTruco info;
        public EnumTipoJogo jogo { get; set; }

        public IJogador jogadorAtual { get; set; }
        private List<ICartas> maoJogador;
        public JogarTruco(IJogador jogador, List<ICartas> mao)
        {
            jogo = Jogo.getJogo().tipoJogo;
            info = Jogo.getJogo().infoJogo as InfoJogoTruco;
            maoJogador = mao;
            jogadorAtual = jogador;
        }

        public ICartas jogar()
        {

            // encontra maior da mesa
            if (maoJogador.Count == 3)
            {
                ordenar(maoJogador);
            }
            Carta maiorMesa = info.cartasRodada.LastOrDefault();
            for (int i = 0; i < info.cartasRodada.Count - 1; i++)
            {
                if (TrucoAuxiliar.comparar(info.cartasRodada[i], maiorMesa, info.manilha) > 0)
                {
                    maiorMesa = info.cartasRodada[i];
                }
            }
            //descarta
            ICartas carta = maoJogador[0];
            if (maiorMesa == null)
            {
                maoJogador.RemoveAt(0);
                return carta;
            }
            else
            {
                for (int i = 0; i < maoJogador.Count; i++)
                {
                    carta = maoJogador[i];
                    if (TrucoAuxiliar.comparar(carta, maiorMesa, info.manilha) > 0)
                    {
                        maoJogador.RemoveAt(i);
                        return carta;
                    }
                }
                carta = maoJogador[0];
                maoJogador.RemoveAt(0);
                return carta;
            }
        }

        protected void ordenar(List<ICartas> mao)
        {
            mao = mao.OrderBy(x => TrucoAuxiliar.gerarValorICartas(x, info.manilha)).ToList();
        }

        public virtual void novaCarta(ICartas carta, IJogador jogador)
        {
            if (jogador.equipe.identificador != jogadorAtual.equipe.identificador
                && ((ICartas)carta).valor(info.manilha) < 2
                && maoJogador.Count > 0
                && maoJogador.Max(a => a.valor(info.manilha)) > 10)
                truco(jogadorAtual, EnumTruco.truco);
        }

        public virtual Escolha trucado(Jogador trucante, EnumTruco valor, ICartas manilha)
        {
            return Escolha.aceitar;
        }

        protected void trucar(IJogador jogador, EnumTruco pedido)
        {
            truco(jogador, pedido);
        }
    }
}
