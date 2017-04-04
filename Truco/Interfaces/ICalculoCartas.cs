using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    public interface ICalculoCartas
    {
        int getPeso(ICartas carta);
    }
}
