using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Interfaces;
using Truco.Enumeradores;

namespace CardGame
{
    class Mesa: IControler
    {
        private Baralho baralhoMesa;
        private Log log;
        private List<IJogador> gamers;

        public List<Equipe> EquipeMesa
        {
            get { return equipeMesa; }
            set { equipeMesa = value; }
        }

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

      
        private Jogador[] posicoes;
        
        public Mesa(List<IJogador> jogadores, EnumTipoJogo tipoJogo)
        {
            gamers = jogadores;
            if(tipoJogo == EnumTipoJogo.truco || tipoJogo == EnumTipoJogo.buraco)
            {
                List<IJogador> EquipeUm = new List<IJogador>() { jogadores[0], jogadores[2]};
                EquipeMesa.Add(new Equipe(EquipeUm));
                List<IJogador> EquipeDois = new List<IJogador>() { jogadores[1], jogadores[3] };
                EquipeMesa.Add(new Equipe(EquipeDois));
            }

            else 
            { 
                foreach(Jogador x in jogadores)
                {
                    List<Jogador> jogs = new List<Jogador>() { x };
                    EquipeMesa.Add(new CardGame.Equipe(jogs));
                }
            }

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

        //Métodos Interface
        public void jogar()
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

       
        public void setJogadores(List<IJogador> jogadores)
        {
            gamers = jogadores;  
        }

        public void setEquipe(List<Equipe> equipe)
        {
            equipeMesa = equipe;
        }

        public void redistribuirEquipes()
        {
            Random rdn = new Random();
            EquipeMesa = new List<Equipe>();
            rdn.Next(0, gamers.Count);  
        }
    }
}
