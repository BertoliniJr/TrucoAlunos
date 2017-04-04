using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco;
using Truco.InfoJogo;
using Truco.Auxiliares;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace CardGame
{

    class RodadaTruco : Rodada
    {
        //Eventos do truco

        private int NumCartas = 3;
        Carta Manilha;
        private int pontos=1;
        private IJogador[] jogadores;
        private int EquipeTrucante=-1;
        private int correu=-1;

        private Log log;

        List<Carta> ListaCartas;

        public int getNumCartas()
        {
            return NumCartas;
        }

        public RodadaTruco(List<Equipe> equipes) :base()
        {

            Jogo.getJogo().infoJogo = new InfoJogoTruco();
            (Jogo.getJogo().infoJogo as InfoJogoTruco).jogadores[0] = equipes[0].jogadores[0];
            (Jogo.getJogo().infoJogo as InfoJogoTruco).jogadores[1] = equipes[1].jogadores[0];
            (Jogo.getJogo().infoJogo as InfoJogoTruco).jogadores[2] = equipes[0].jogadores[1];
            (Jogo.getJogo().infoJogo as InfoJogoTruco).jogadores[3] = equipes[1].jogadores[1];

        }

        private bool validarTruco(Jogador jogador, EnumTruco pedido)
        {
            //Validando o truco
            if (jogadores.Where(x => Equipe.BuscaID(x.IDEquipe).PontosEquipe >= 12).Count() > 0)
            {
                log.logar($"Jogador {jogador} trucou na mão de doze. Perdeu");
                correu = jogador.IDEquipe;
                return false;
            }

            if (jogador.IDEquipe == EquipeTrucante)
            {
                log.logar($"Jogador {jogador} trucou, mas equipe já está trucando");
                return false;
            }

            if (this.pontos >= pedido.pontosTruco())
            {
                log.logar($"Jogador {jogador} pediu {pedido}, mas a partida já está valendo mais");
                return false;
            }

            if (EnumTruco.jogo.pontosTruco() == this.pontos)
            {
                log.logar("Partida já está valendo jogo");
                return false;
            }
            return true;
        }

        protected virtual void OlharTruco(Jogador jogador, EnumTruco pedido)
        {
            if (!validarTruco(jogador, pedido))
            {
                return;
            }
            log.logar($"{jogador} pedindo {pedido}");
            //Perguntando jogadores se aceitam
            Tuple<Jogador, Escolha> aceite = aceita(jogador, pedido);

            EnumTruco pedidoAtual = pedido;
            switch (aceite.Item2)
            {
                case Escolha.correr:
                    log.logar($"Equipe {Equipe.BuscaID(aceite.Item1.IDEquipe)} correu");
                    correu = aceite.Item1.IDEquipe;
                    break;
                case Escolha.aceitar:
                    this.pontos = pedido.pontosTruco();
                    EquipeTrucante = jogador.IDEquipe;
                    log.logar($"{aceite.Item1} aceitou o truco");
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
                                if (pedidoAtual == EnumTruco.jogo)
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

        private Tuple<Jogador, Escolha> aceita(Jogador jogador, EnumTruco pedido)
        {
            List<Tuple<Jogador, Escolha>> aceite = new List<Tuple<Jogador, Escolha>>();
            foreach (var item in jogadores)
            {
                if (item != jogador)
                    aceite.Add(new Tuple<Jogador, Escolha>(item, item.trucado(jogador, pedido, Manilha)));
            }
            var equip = aceite.Where(x => x.Item1.IDEquipe != jogador.IDEquipe).ToList();
            if (equip.Select(x => x.Item2).Contains(Escolha.aumentar))
                return equip.Where(x => x.Item2 == Escolha.aumentar).First();
            else if (equip.Select(x => x.Item2).Contains(Escolha.aceitar))
                return equip.Where(x => x.Item2 == Escolha.aceitar).First();
            else
                return equip.Where(x => x.Item2 == Escolha.correr).First();

        }



        private IJogador[] circulaVetor(IJogador[] jogadores)
        {
            IJogador aux = jogadores[0];

            for (int i = 0; i < jogadores.Length - 1; i++)
            {
                jogadores[i] = jogadores[i + 1];
            }
            jogadores[jogadores.Length - 1] = aux;

            return jogadores;
        }


        public override void rodar()
        {




            IJogador[] jogadoresParametro = circulaVetor((Jogo.getJogo().infoJogo as InfoJogoTruco).jogadores);

            // Inicialização dos sinais do truco
            jogadores = jogadoresParametro;
            this.ligaEventos();
            Baralho baralho=new Baralho();
            baralho.embaralhar();

            foreach (var jogador in jogadores)
            {
                jogador.NovaMao();
                for (int i = 0; i < 3; i++)
                {
                    jogador.receberCarta(baralho.pegarProxima());
                }
            }

            // variaveis de controle
            Dictionary<IEquipe, int> pontosMao = new Dictionary<IEquipe, int>();

            pontosMao.Add(jogadores[0].equipe, 0);
            pontosMao.Add(jogadores[1].equipe, 0);


            // Mão de doze
            if (jogadores[0].equipe.pontos >= 12 || jogadores[0].equipe.pontos >= 12)
            {
                pontos = 3;
                log.logar("Mão de 12");
                log.logar("");
            }

            int indempate = 0;
            //Loop das rodadas
            for (int i = 0; i < 3; i++)
            {
                #region loop da rodada
                ListaCartas = new List<Carta>();
                Carta maior1 = null;
                Carta maior2 = null;
                int imaior1 = 0;
                int imaior2 = 0;

                for (int j = 0; j < 4; j++)
                {
                    #region loop da mão
                    ListaCartas.Add(jogadores[j].jogar());
                    Carta X = ListaCartas.Last();
                    log.logar(jogadores[j].nome + " jogou {0}, peso: {1}", X.ToString(), X.getPeso);
                    novaCarta(X, jogadores[j]);

                    if (jogadores[j].equipe == pontosMao.Keys.First() && (ListaCartas[j].getPeso > maior1.getPeso)
                    {
                        maior1 = ListaCartas[j];
                        imaior1 = j;
                        indempate = j;
                    }
                    if (jogadores[j].equipe == pontosMao.Keys.Last() && (ListaCartas[j].getPeso > maior1.getPeso))
                    {
                        maior2 = ListaCartas[j];
                        imaior2 = j;
                        indempate = j;
                    }
                    if (correu > -1)
                    {
                        log.logar($"Equipe {Equipe.BuscaID(correu)} correu do truco.");
                        Equipe vencedora = Equipe.BuscaID(jogadores.Where(x => x.IDEquipe != correu).First().IDEquipe);
                        vencedora.GanharPontos(pontos);
                        log.logar("A {0}, ganhou a rodada !", vencedora.ToString());
                        desligaEventos();
                        return;
                    }
                    #endregion
                }

                if (maior1.getPeso == maior2.getPeso)
                {
                    if (i == 0)
                    {
                        pontosMao[pontosMao.Keys.First()] += 3;
                        pontosMao[pontosMao.Keys.Last()] += 3;
                    }
                    else
                    {
                        pontosMao[pontosMao.Keys.First()] += 2;
                        pontosMao[pontosMao.Keys.Last()] += 2;
                    }
                    log.logar("*Empate*");
                    jogadores = Reordenar(jogadores, indempate);
                }
                else
                {
                    if (maior1.getPeso > maior2.getPeso)
                    {
                        if (i == 0)
                        {
                            pontosMao[pontosMao.Keys.First()] += 3;
                            
                        }
                        else
                        {
                            pontosMao[pontosMao.Keys.First()] += 2;
                         
                        }
                        
                        log.logar("\nA equipe do jogador{0}, ganhou a mão.", jogadores[imaior1].nome);
                        log.logar("");
                        jogadores = Reordenar(jogadores, imaior1);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            pontosMao[pontosMao.Keys.Last()] += 3;
                           
                        }
                        else
                        {
                            pontosMao[pontosMao.Keys.Last()] += 2;
                        }
                        log.logar("\nA equipe do jogador{0}, ganhou a mão.", jogadores[imaior2].nome);
                        log.logar("");
                        jogadores = Reordenar(jogadores, imaior2);
                    }
                }

                if (pontosMao[pontosMao.Keys.First()] != pontosMao[pontosMao.Keys.Last()] && (pontosMao[pontosMao.Keys.First()] == 5 || pontosMao[pontosMao.Keys.Last()] == 5))
                    break;
                #endregion
            }

            if (correu == eqp2[0])
            {
                Equipe.BuscaID(eqp1[0]).GanharPontos(pontos);
                log.logar("A {0}, ganhou a rodada !", Equipe.BuscaID(eqp1[0]).ToString());
            }
            else if (correu == eqp1[0])
            {
                Equipe.BuscaID(eqp2[0]).GanharPontos(pontos);
                log.logar("A {0}, ganhou a rodada !", Equipe.BuscaID(eqp2[0]).ToString());
            }
            else
            {
                if (pontosMao[pontosMao.Keys.First()] > pontosMao[pontosMao.Keys.Last()])
                {
                    pontosMao.Keys.First().pontos+=pontos;
                    log.logar("A {0}, ganhou a rodada !", pontosMao.Keys.First().ToString());
                }
                else if (pontosMao[pontosMao.Keys.First()] < pontosMao[pontosMao.Keys.Last()])
                {
                    pontosMao.Keys.Last().pontos += pontos;
                    log.logar("A {0}, ganhou a rodada !", pontosMao.Keys.Last().ToString());
                }
                else
                {
                    log.logar("\n*Empate na rodada, ninguem ganhou pontos*");
                }
            }
            desligaEventos();
        }

        private void ligaEventos()
        {
            foreach (var jogador in jogadores)
            {
                jogador.truco += this.OlharTruco;
            }
        }

        private void desligaEventos()
        {
            foreach (var jogador in jogadores)
            {
                jogador.truco -= this.OlharTruco;
            }
        }

        private void novaCarta(Carta a, IJogador j)
        {
            foreach (var jogador in jogadores)
            {
                jogador.novaCarta(a, j);
            }
        }

        static IJogador[] Reordenar(IJogador[] jogadores, int k)
        {
            int i = 0;
            IJogador[] vet = new IJogador[jogadores.Length];
            while (i < jogadores.Length)
            {
                vet[i] = jogadores[k];
                k++; i++;
                if (k >= jogadores.Length) k = 0;

            }
            return vet;
        }

        public override bool fim()
        {
            return(equipes[0].pontos>=15 || equipes[1].pontos>=15);
        }
    }
}
