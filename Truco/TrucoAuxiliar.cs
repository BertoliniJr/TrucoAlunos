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
            int valorA = gerarValorCarta(a, manilha);
            int valorB = gerarValorCarta(b, manilha);

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

            return pesoCarta;
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
