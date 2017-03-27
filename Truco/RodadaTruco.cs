using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    class RodadaTruco : IRodada
    {
        int pontos = 1;
        private int NumCartas = 3;
        Carta Manilha;

        List<Carta> ListaCartas;

        public int getNumCartas()
        {
            return NumCartas;
        }


        public RodadaTruco(Carta M)
        {
            Manilha = M;
        }

        public void Rodar(Jogador[] jogadores)
        {

            int[] eqp1 = new int[2];
            int[] eqp2 = new int[2];

            eqp1[0] = jogadores[0].IDEquipe;
            eqp2[0] = jogadores[1].IDEquipe;



            for (int i = 0; i < 3; i++)
            {
                List<Carta> ListaCartas = new List<Carta>();
                Carta maior = Manilha;
                int imaior = 0;


                for (int j = 0; j < 4; j++)
                {
                    ListaCartas.Add(jogadores[i].Jogar(ListaCartas, Manilha));

                    if (TrucoAuxiliar.comparar(ListaCartas[j], maior, Manilha) > 0)
                    {
                        maior = ListaCartas[j];
                        imaior = j;
                    }
                    else if (TrucoAuxiliar.comparar(ListaCartas[j], maior, Manilha) == 0)
                    {
                        eqp1[1] += 1;
                        eqp2[1] += 1;
                    }
                    if (jogadores[imaior].IDEquipe == eqp1[0])
                    {
                        eqp1[1] += 1;
                    }
                    else
                    {
                        eqp2[1] += 1;
                    }


                    Reordenar(jogadores, imaior);


                }
                if (eqp1[1] > eqp2[1])
                {
                    Equipe.BuscaID(eqp1[0]).GanharPontos(pontos);
                }
                else
                {
                    Equipe.BuscaID(eqp2[0]).GanharPontos(pontos);
                }
            }
        }

        static int[] Reordenar(Jogador[] jogadores, int k)

        {
            int i = 0;
            int[] vet = new int[jogadores.Length];
            while (i < jogadores.Length)
            {
                jogadores[i] = jogadores[k];
                k++; i++;
                if (k >= jogadores.Length) k = 0;

            }
            return vet;
        }
    }
}
