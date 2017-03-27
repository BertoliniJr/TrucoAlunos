using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Equipe
    {
        private List<Jogador> jogadoresEquipe;

        public List<Jogador> JogadoresEquipe
        {
            get { return jogadoresEquipe; }
            set { jogadoresEquipe = value; }
        }
        private int pontosEquipe;

        public int PontosEquipe
        {
            get { return pontosEquipe; }
        }

        private static List<Equipe> listaEquipes = new List<Equipe>();

        public Equipe(List<Jogador> jogadores)
        {
            jogadoresEquipe = jogadores;
            pontosEquipe = 0;
            
            Equipe.listaEquipes.Add(this);

            foreach (var jogador in jogadores)
            {
                jogador.IDEquipe = listaEquipes.Count - 1;
            }
        }

        public void GanharPontos(int p)
        {
            pontosEquipe += p;
        }
        
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
