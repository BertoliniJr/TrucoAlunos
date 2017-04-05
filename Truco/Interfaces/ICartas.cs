using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    public interface ICartas
    {
        Truco.Enumeradores.Naipes Naipe { get; }
        ICalculoCartas calculo { set; }
        int getValor();
        int getPeso();
        
    }
}
