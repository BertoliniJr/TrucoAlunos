using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    interface IControler
    {
        void jogar();
        void setJogadores(List<IJogador> jogadores);
        void setEquipe(List<IEquipe> equipe);
        void redistribuirEquipes();
    }
}
