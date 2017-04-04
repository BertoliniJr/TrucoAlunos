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
    class JogarTruco : JogarAbstrato
    {
        public event trucoseubosta truco;
        public delegate void trucoseubosta(IJogador jogador, EnumTruco truco);

        private InfoJogoTruco info;

        public JogarTruco(IJogador jogador, List<ICartas> mao) : base (jogador, mao)
        {
            info = Jogo.getJogo().infoJogo as InfoJogoTruco;
        }

        public override ICartas jogar()
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

        public virtual void novaCarta(ICartas carta, IJogador jogador)
        {
            if (jogador.equipe.identificador != jogadorAtual.equipe.identificador
                && ((ICartas)carta).getPeso() < 2
                && maoJogador.Count > 0
                && maoJogador.Max(a => a.getPeso()) > 10)
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
