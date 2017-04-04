using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    public interface ILog
    {
        void logar(string msg, Truco.Enumeradores.TipoLog tipolog);
    }
}
