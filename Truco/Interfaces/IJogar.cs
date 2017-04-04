using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;

namespace Truco.Interfaces
{
    public interface IJogar
    {
        EnumTipoJogo jogo { get; set; }
        ICartas jogar();
        IJogador jogadorAtual { get; set; }
    }
}
