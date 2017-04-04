using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace CardGame
{
    class Equipe : IEquipe
    {
        private List<IJogador> jogadoresEquipe;
        private Equipe adversario;
        private int pontosEquipe;
        private static List<Equipe> listaEquipes = new List<Equipe>();

        //public List<Jogador> JogadoresEquipe
        //{
        //    get { return jogadoresEquipe; }
        //    set { jogadoresEquipe = value; }
        //}

        //public int PontosEquipe
        //{
        //    get { return pontosEquipe; }
        //}

        internal Equipe Adversario
        {
            get
            {
                return adversario;
            }

            set
            {
                adversario = value;
            }
        }

        public int pontos
        {
            get
            {
                return pontosEquipe;
            }

            set
            {
                pontosEquipe += value;
            }
        }

        public List<IJogador> jogadores
        {
            get
            {
                return jogadoresEquipe;
            }

            set
            {
                foreach (var jogador in value)
                {
                    jogador.equipe = this;
                }
                jogadoresEquipe = value;
            }
        }

        public string identificador
        {
            get;
        }

        public Equipe(List<IJogador> jogadores)
        {
            jogadoresEquipe = jogadores;
            pontosEquipe = 0;
            
            Equipe.listaEquipes.Add(this);

            //foreach (var jogador in jogadores)
            //{
            //    jogador.IDEquipe = listaEquipes.Count - 1;
            //}
        }

        //public void GanharPontos(int p)
        //{
        //    pontosEquipe += p;
        //}
        
        public static Equipe BuscaID(int id)
        {
            return listaEquipes[id];
        }

        public override string ToString()
        {
            string equipe = $"Equipe {listaEquipes.IndexOf(this) + 1} composta por " + string.Join(", ", jogadoresEquipe.Select(a => a.nome));
            return equipe;
        }
    }
}
