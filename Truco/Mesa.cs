﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;

namespace CardGame
{
    class Mesa
    {
        private Baralho baralhoMesa;
        private Log log;
        

        public Baralho BaralhoMesa
        {
            get { return baralhoMesa; }
            set { baralhoMesa = value; }
        }
        
        private IRodada rodadaMesa;

        public IRodada RodadaMesa
        {
            get { return rodadaMesa; }
            set { rodadaMesa = value; }
        }
        private List<Equipe> equipeMesa;

        public List<Equipe> EquipeMesa
        {
            get { return equipeMesa; }
            set { equipeMesa = value; }
        }

        private Jogador[] posicoes;
        
        public Mesa(List<Equipe> equipes, Log logar)
        {
            equipeMesa = equipes;
            equipes[0].Adversario = equipes[1];
            equipes[1].Adversario = equipes[0];
            log = logar;
        }
        private void preencheMesa()
        {
            posicoes = new Jogador[equipeMesa.Count * equipeMesa[0].JogadoresEquipe.Count];
            int cont = 0;
            int contEquipe = 0;

            foreach (var equipe in equipeMesa)
            {
                cont = contEquipe;
                foreach (var jogador in equipe.JogadoresEquipe)
                {
                    posicoes[cont] = jogador;
                    cont += equipeMesa.Count;
                }
                contEquipe++;
            }
        }

        public void Jogar()
        {
            foreach (var equipe in equipeMesa)
            {
                equipe.GanharPontos(-equipe.PontosEquipe);
            }

            preencheMesa();
            baralhoMesa = new Baralho();
            int r = 1;
            while (true)
            {
                baralhoMesa.embaralhar();

                log.logar();
                log.logar("--------------------");
                log.logar("Iniciando Rodada {0}",r);
                log.logar("--------------------");
                Carta queimada = baralhoMesa.pegarProxima();
                log.logar("\n:::::Carta queimada: {0} de {1}", queimada.nomeValor(), queimada.Naipe);
                foreach (var equipe in equipeMesa)
                {
                    Console.Write("\n*{0}: {1} Pontos* ", equipe.ToString(),equipe.PontosEquipe );
                }
                log.logar("\n");

                rodadaMesa = new RodadaTruco(queimada, log);

                foreach (var jogador in posicoes)
                {
                    jogador.NovaMao();
                    for (int i = 0; i < rodadaMesa.getNumCartas(); i++)
                    {
                        jogador.ReceberCarta(baralhoMesa.pegarProxima());
                    }
                }

                rodadaMesa.Rodar(posicoes);

                baralhoMesa.recolher();

                foreach (var equipe in equipeMesa)
                {
                    if (equipe.PontosEquipe >= 15)
                    {
                        log.logar("\n***** Equipe dos jogadores {0} venceu *****", equipe.ToString());
                        return;
                    }
                        
                }

                posicoes = circulaVetor(posicoes);
                r++;
            }
        }

        private Jogador[] circulaVetor(Jogador[] jogadores)
        {
            Jogador aux = jogadores[0];

            for (int i = 0; i < jogadores.Length-1; i++)
            {
                jogadores[i] = jogadores[i + 1];
            }
            jogadores[jogadores.Length - 1] = aux;

            return jogadores;
        }

    }
}
