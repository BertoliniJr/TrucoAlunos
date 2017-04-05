using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace Truco
{
    abstract class  Rodada : IRodada
    {
        
        protected List<IEquipe> equipes;

        private Rodada()
        {
        }

        public Rodada(List<IEquipe> equipe)
        {
            equipes = equipe;
        }

        public abstract bool fim();
        public abstract void rodar();
        
    }
}
