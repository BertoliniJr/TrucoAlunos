using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;

namespace Truco.Interfaces
{
    interface IJogar
    {
        EnumTipoJogo Jogo { get; set; }
        ICartas jogar();
    }
}
