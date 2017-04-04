using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Interfaces
{
    public interface IEquipe
    {
        int pontos { get; set; }
        List<IJogador> jogadores { get; set; }
        string identificador { get; }
    }
}
