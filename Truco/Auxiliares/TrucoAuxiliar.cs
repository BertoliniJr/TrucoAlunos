using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame
{
    public static class TrucoAuxiliar
    {
        public static int comparar(Carta a, Carta b, Carta manilha)
        {
            int valorA = a == null ? 0 : gerarValorCarta(a, manilha);
            int valorB = b == null ? 0 : gerarValorCarta(b, manilha);

            return valorA - valorB;
        }

        public static int gerarValorCarta(Carta carta, Carta manilha)
        {
            int valorManilha = manilha.Valor == 13 ? 1 : manilha.Valor == 7 ? 10 : manilha.Valor + 1;

            int pesoCarta = carta.Valor - 3;
            if (pesoCarta < 1)
                pesoCarta = pesoCarta + 13;
            if (pesoCarta > 4)
                pesoCarta = pesoCarta - 3;

            if (carta.Valor == valorManilha)
            {
                pesoCarta = 10;

                switch (carta.Naipe)
                {
                    case Naipes.ouros:
                        pesoCarta = pesoCarta + 1;
                        break;
                    case Naipes.espadas:
                        pesoCarta = pesoCarta + 2;
                        break;
                    case Naipes.copas:
                        pesoCarta = pesoCarta + 3;
                        break;
                    case Naipes.paus:
                        pesoCarta = pesoCarta + 4;
                        break;
                }
            }

            return pesoCarta;
        }

        public static int pontosTruco(this Truco pedido)
        {
            switch (pedido)
            {
                case Truco.truco:
                    return 3;
                case Truco.seis:
                    return 6;
                case Truco.nove:
                    return 9;
                case Truco.doze:
                    return 12;
                case Truco.jogo:
                    return 15;
                default:
                    return 1;
            }
        }

        public static Truco proximo(this Truco pedido)
        {
            switch (pedido)
            {
                case Truco.truco:
                    return Truco.seis;
                case Truco.seis:
                    return Truco.nove;
                case Truco.nove:
                    return Truco.doze;
                case Truco.doze:
                    return Truco.jogo;
                default:
                    return Truco.truco;
            }
        }

        public static Truco? trucoPorPontos(this int valor)
        {
            switch (valor)
            {
                case 3:
                    return Truco.truco;
                case 6:
                    return Truco.seis;
                case 9:
                    return Truco.nove;
                case 12:
                    return Truco.doze;
                case 15:
                    return Truco.jogo;
                default:
                    return null;
            }
        }

        public static int valor(this Carta a, Carta manilha)
        {
            return gerarValorCarta(a, manilha);
        }

        public static int compara(this Carta a, Carta b, Carta manilha)
        {
            return comparar(a, b, manilha);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
}
