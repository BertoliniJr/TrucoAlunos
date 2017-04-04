using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace Truco
{
    class RodadaPoker : Rodada
    {
        public RodadaPoker(List<IEquipe> equipe) : base(equipe)
        {
        }

        public override bool fim()
        {
            throw new NotImplementedException();
        }

        public override void rodar()
        {
            throw new NotImplementedException();
        }
    }
}
