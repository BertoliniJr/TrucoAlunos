using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace Truco.InfoJogo
{
    public class InfoJogoTruco
    {
        private ICartas _manilha;
        private IJogador[] _jogadores;
        public List<ICartas> cartasRodada;

        public InfoJogoTruco()
        {
            _jogadores = new IJogador[4];
            cartasRodada = new List<ICartas>();
        }

        public ICartas manilha
        {
            get
            {
                return _manilha;
            }

            set
            {
                _manilha = value;
            }
        }

        public IJogador[] jogadores
        {
            get
            {
                return _jogadores;
            }

            set
            {
                _jogadores = value;
            }
        }

    }
}
