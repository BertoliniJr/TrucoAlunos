using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    public interface IJogador
    {
        string nome { get; }
        IEquipe equipe { get; set; }

        void jogar();
        void receberCarta(ICartas carta);
        void novaMao();
    }
}
