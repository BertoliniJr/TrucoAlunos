using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    class RodadaTruco : IRodada
    {
        public event EventHandler novaCarta;
        private int NumCartas = 3;
        Carta Manilha;
        private int pontos;
        private Jogador[] jogadores;

        List<Carta> ListaCartas;

        public int getNumCartas()
        {
            return NumCartas;
        }


        public RodadaTruco(Carta M)
        {
            Manilha = M;
            pontos = 1;
        }

        protected virtual void OlharTruco(object jogador, EventArgs e)
        {
        }

        private Escolha aceita (Jogador jogador, Truco pedido)
        {
            Dictionary<Jogador, Escolha> aceite = new Dictionary<Jogador, Escolha>();
            foreach (var item in jogadores)
            {
                if (item != jogador)
                    aceite.Add(item, item.trucado(jogador as Jogador, pedido));
            }

        }

        public void Rodar(Jogador[] jogadoresParametro)
        {
            jogadores = jogadoresParametro;
            foreach (var jogador in jogadores)
            {
                jogador.truco += this.OlharTruco;
                this.novaCarta += jogador.novaCarta;
            }
            int[] eqp1 = new int[2];
            int[] eqp2 = new int[2];
            eqp1[0] = jogadores[0].IDEquipe;
            eqp2[0] = jogadores[1].IDEquipe;

            if(Equipe.BuscaID(eqp1[0]).PontosEquipe>=12 || Equipe.BuscaID(eqp2[0]).PontosEquipe >= 12)
            {
                pontos = 3;
                Console.WriteLine("Mão de 12");
            }

                int indempate = 0;
            for (int i = 0; i < 3  ; i++)
            {
                ListaCartas = new List<Carta>();
                Carta maior1 = null;
                Carta maior2 = null;
                int imaior1 = 0;
                int imaior2 = 0;


                for (int j = 0; j < 4; j++)
                {
                    ListaCartas.Add(jogadores[j].Jogar(ListaCartas, Manilha));
                    novaCarta(jogadores[j], EventArgs.Empty);
                    Carta X = ListaCartas.Last();
                    Console.WriteLine(jogadores[j].nome + " jogou {0}, peso: {1}", X.ToString(), TrucoAuxiliar.gerarValorCarta(X, Manilha) );

                    if (jogadores[j].IDEquipe == eqp1[0] && TrucoAuxiliar.comparar(ListaCartas[j], maior1, Manilha) > 0)
                    {
                        maior1 = ListaCartas[j];
                        imaior1 = j;
                        indempate = j;
                    }
                    if (jogadores[j].IDEquipe == eqp2[0] && TrucoAuxiliar.comparar(ListaCartas[j], maior2, Manilha) > 0)
                    {
                        maior2 = ListaCartas[j];
                        imaior2 = j;
                        indempate = j;
                    }
                    
                }
                if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) == 0)
                {
                    eqp1[1] += 1;
                    eqp2[1] += 1;
                    Console.WriteLine("Empate");
                    jogadores = Reordenar(jogadores, indempate);
                }
                else
                {
                    if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) > 0)
                    {
                        eqp1[1] += 1;
                        Console.WriteLine("A equipe do jogador{0}, ganhou a mão", jogadores[imaior1].nome);
                        jogadores = Reordenar(jogadores, imaior1);
                    }
                    else
                    {
                        eqp2[1] += 1;
                        Console.WriteLine("A equipe do jogador{0}, ganhou a mão", jogadores[imaior2].nome);
                        jogadores = Reordenar(jogadores, imaior2);
                    }
                }

                if (eqp1[1] != eqp2[1] && (eqp1[1] == 2 || eqp2[1] == 2))
                    break;
                                
            }
            if (eqp1[1] > eqp2[1])
            {
                Equipe.BuscaID(eqp1[0]).GanharPontos(pontos);
                Console.WriteLine("A {0}, ganhou a rodada", Equipe.BuscaID(eqp1[0]).ToString());
            }
            else if (eqp1[1] < eqp2[1])
            {
                Equipe.BuscaID(eqp2[0]).GanharPontos(pontos);
                Console.WriteLine("A {0}, ganhou a rodada", Equipe.BuscaID(eqp2[0]).ToString());
            }
            else
            {
                Console.WriteLine("Empate na rodada, ninguem ganhou pontos");
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
