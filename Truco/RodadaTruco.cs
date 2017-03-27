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
                ListaCartas = new List<Carta>();
                Carta maior1 = Manilha;
                Carta maior2 = Manilha;
                int imaior1 = 0;
                int imaior2 = 0;


                for (int j = 0; j < 4; j++)
                {
                    ListaCartas.Add(jogadores[j].Jogar(ListaCartas, Manilha));
                    Carta X = ListaCartas.Last();
                    Console.WriteLine(jogadores[j].nome + " jogou {0}, peso: {1}", X.ToString(), TrucoAuxiliar.gerarValorCarta(X, Manilha) );

                    if (jogadores[j].IDEquipe == eqp1[0] && TrucoAuxiliar.comparar(ListaCartas[j], maior1, Manilha) > 0)
                    {
                        maior1 = ListaCartas[j];
                        imaior1 = j;
                    }
                    if (jogadores[j].IDEquipe == eqp2[0] && TrucoAuxiliar.comparar(ListaCartas[j], maior1, Manilha) > 0)
                    {
                        maior2 = ListaCartas[j];
                        imaior2 = j;
                    }
                }
                if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) == 0)
                {
                    Console.WriteLine("Empate");
                    eqp1[1] += 1;
                    eqp2[1] += 1;
                    Reordenar(jogadores, imaior2);
                }
                else
                {
                    if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) > 0)
                    {
                        eqp1[1] += 1;
                        Console.WriteLine("A equipe do jogador{0}, ganhou a mão", jogadores[imaior1].nome);
                        Reordenar(jogadores, imaior1);
                    }
                    else
                    {
                        eqp2[1] += 1;
                        Console.WriteLine("A equipe do jogador{0}, ganhou a mão", jogadores[imaior2].nome);
                        jogadores = Reordenar(jogadores, imaior2);
                    }
                }
                
            }
            if (eqp1[1] > eqp2[1])
            {
                Equipe.BuscaID(eqp1[0]).GanharPontos(pontos);
                Console.WriteLine("A equipe de id = {0}, ganhou a rodada", eqp1[0]);
            }
            else
            {
                Equipe.BuscaID(eqp2[0]).GanharPontos(pontos);
                Console.WriteLine("A equipe de id = {0}, ganhou a rodada", eqp2[0]);
            }
        }

        static Jogador[] Reordenar(Jogador[] jogadores, int k)

        {
            int i = 0;
            Jogador[] vet = new Jogador[jogadores.Length];
            while (i < jogadores.Length)
            {
                vet[i] = jogadores[k];
                k++; i++;
                if (k >= jogadores.Length) k = 0;

            }
            return vet;
        }
    }
}
