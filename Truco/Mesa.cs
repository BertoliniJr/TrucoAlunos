﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Mesa
    {
        private Baralho baralhoMesa;
        

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
        
        public Mesa(List<Equipe> equipes)
        {
            equipeMesa = equipes;
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
            preencheMesa();
            baralhoMesa = new Baralho();
            int r = 1;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Iniciando Rodada {0}",r);
                Carta queimada = baralhoMesa.pegarProxima();
                Console.WriteLine("Carta queimada: {0} de {1}", queimada.Valor, queimada.Naipe);
                foreach (var equipe in equipeMesa)
                {
                    Console.Write(" /{0}: {1} Pontos/ ", equipe.ToString(),equipe.PontosEquipe );
                }
                Console.WriteLine("\n");

                rodadaMesa = new RodadaTruco(queimada);
                baralhoMesa.embaralhar();

                foreach (var jogador in posicoes)
                {
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
                        Console.WriteLine("Equipe dos jogadores {0} venceu", equipe.ToString());
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
