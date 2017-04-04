using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace Truco.Jogar
{
    class JogarBuraco : JogarAbstrato
    {
        public EnumTipoJogo Jogo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public JogarBuraco(IJogador jogador, List<ICartas> mao) : base(jogador, mao)
        {

        }

        public override ICartas jogar()
        {
            throw new NotImplementedException();
        }
    }
}
