using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    class RodadaTruco : IRodada
    {
        //Eventos do truco
        public event novacarta novaCarta;
        public delegate void novacarta(Carta a, Jogador j);

        private int NumCartas = 3;
        Carta Manilha;
        private int pontos;
        private Jogador[] jogadores;
        private int EquipeTrucante;
        private int correu;

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

        protected virtual void OlharTruco(Jogador jogador, Truco pedido)
        {
            //Validando o truco
            if (jogador.IDEquipe == EquipeTrucante)
            {
                Console.WriteLine($"Jogador {jogador} trucou, mas equipe já está trucando");
                return;
            }

            if (this.pontos <= pedido.pontosTruco())
            {
                Console.WriteLine($"Jogador {jogador} pediu {pedido}, mas a partida já está valendo mais");
            }

            if (Truco.jogo.pontosTruco() == this.pontos)
            {
                Console.WriteLine("Partida já está valendo jogo");
                return;
            }
            if (this.pontos == Truco.doze.pontosTruco())
            {
                Console.WriteLine($"Jogador {jogador} trucou na mão de 12, vai correr da mão");
                this.correu = jogador.IDEquipe;
                return;
            }

            //Perguntando jogadores se aceitam
            Tuple<Jogador, Escolha> aceite = aceita(jogador, pedido);

            Truco pedidoAtual = pedido;
            switch (aceite.Item2)
            {
                case Escolha.correr:
                    correu = aceite.Item1.IDEquipe;
                    break;
                case Escolha.aceitar:
                    this.pontos = pedido.pontosTruco();
                    EquipeTrucante = jogador.IDEquipe;
                    break;
                case Escolha.aumentar:
                    #region aumentar
                    while (true)
                    {
                        this.pontos = pedidoAtual.pontosTruco();
                        pedidoAtual = pedidoAtual.proximo();
                        aceite = aceita(aceite.Item1, pedidoAtual);
                        switch (aceite.Item2)
                        {
                            case Escolha.correr:
                                correu = aceite.Item1.IDEquipe;
                                return;
                            case Escolha.aceitar:
                                this.pontos = pedidoAtual.pontosTruco();
                                EquipeTrucante = jogador.IDEquipe;
                                return;
                            case Escolha.aumentar:
                                if (pedidoAtual == Truco.jogo)
                                {
                                    this.pontos = 15;
                                    EquipeTrucante = aceite.Item1.IDEquipe;
                                    return;
                                }
                                break;
                        }
                    }
                #endregion
                default:
                    break;
            }
        }

        private Tuple<Jogador, Escolha> aceita (Jogador jogador, Truco pedido)
        {
            List<Tuple<Jogador, Escolha>> aceite = new List<Tuple<Jogador, Escolha>>();
            foreach (var item in jogadores)
            {
                if (item != jogador)
                    aceite.Add(new Tuple<Jogador, Escolha>(item, item.trucado(jogador, pedido)));
            }
            var equip = aceite.Where(x => x.Item1.IDEquipe != jogador.IDEquipe).ToList();
            if (equip.Select(x => x.Item2).Contains(Escolha.aumentar))
                return equip.Where(x => x.Item2 == Escolha.aumentar).First();
            else if (equip.Select(x => x.Item2).Contains(Escolha.aceitar))
                return equip.Where(x => x.Item2 == Escolha.aceitar).First();
            else
                return equip.Where(x => x.Item2 == Escolha.correr).First();

        }

        public void Rodar(Jogador[] jogadoresParametro)
        {
            // Inicialização dos sinais do truco
            jogadores = jogadoresParametro;
            foreach (var jogador in jogadores)
            {
                jogador.truco += this.OlharTruco;
                this.novaCarta += jogador.novaCarta;
            }

            // variaveis de controle
            int[] eqp1 = new int[2];
            int[] eqp2 = new int[2];
            eqp1[0] = jogadores[0].IDEquipe;
            eqp2[0] = jogadores[1].IDEquipe;

            // Mão de doze
            if(Equipe.BuscaID(eqp1[0]).PontosEquipe>=12 || Equipe.BuscaID(eqp2[0]).PontosEquipe >= 12)
            {
                pontos = 3;
                Console.WriteLine("Mão de 12");
                Console.WriteLine("");
            }

                int indempate = 0;
            //Loop das rodadas
            for (int i = 0; i < 3  ; i++)
            {
                ListaCartas = new List<Carta>();
                Carta maior1 = null;
                Carta maior2 = null;
                int imaior1 = 0;
                int imaior2 = 0;

                for (int j = 0; j < 4; j++)
                {
                    #region loop da mão
                    ListaCartas.Add(jogadores[j].Jogar(ListaCartas, Manilha));
                    novaCarta(ListaCartas.Last(), jogadores[j]);
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
                    #endregion
                }

                if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) == 0)
                {
                    eqp1[1] += 1;
                    eqp2[1] += 1;
                    Console.WriteLine("*Empate*");
                    jogadores = Reordenar(jogadores, indempate);
                }
                else
                {
                    if (TrucoAuxiliar.comparar(maior1, maior2, Manilha) > 0)
                    {
                        eqp1[1] += 1;
                        Console.WriteLine("\nA equipe do jogador{0}, ganhou a mão.", jogadores[imaior1].nome);
                        Console.WriteLine("");
                        jogadores = Reordenar(jogadores, imaior1);
                    }
                    else
                    {
                        eqp2[1] += 1;
                        Console.WriteLine("\nA equipe do jogador{0}, ganhou a mão.", jogadores[imaior2].nome);
                        Console.WriteLine("");
                        jogadores = Reordenar(jogadores, imaior2);
                    }
                }

                if (eqp1[1] != eqp2[1] && (eqp1[1] == 2 || eqp2[1] == 2))
                    break;
                                
            }
            if (eqp1[1] > eqp2[1])
            {
                Equipe.BuscaID(eqp1[0]).GanharPontos(pontos);
                Console.WriteLine("A {0}, ganhou a rodada !", Equipe.BuscaID(eqp1[0]).ToString());
            }
            else if (eqp1[1] < eqp2[1])
            {
                Equipe.BuscaID(eqp2[0]).GanharPontos(pontos);
                Console.WriteLine("A {0}, ganhou a rodada !", Equipe.BuscaID(eqp2[0]).ToString());
            }
            else
            {
                Console.WriteLine("\n*Empate na rodada, ninguem ganhou pontos*");
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
