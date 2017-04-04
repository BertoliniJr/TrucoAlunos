using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Enumeradores;
using Truco.Interfaces;

namespace Truco
{
    public class Jogo : IJogo
    {
        private EnumTipoJogo _tipoJogo;
        private Object _infoJogo;

        private Jogo()
        {
            tipoJogo = EnumTipoJogo.truco;
            infoJogo = null;
        }
        
        public EnumTipoJogo tipoJogo
        {
            get
            {
                return _tipoJogo;
            }

            set
            {
                _infoJogo = value;
            }
        }

        public object infoJogo
        {
            get
            {
                return _infoJogo;
            }

            set
            {
                _infoJogo = value;
            }
        }

        private static Jogo _jogo;
        public static IJogo getJogo()
        {
            if (_jogo == null)
                _jogo = new Jogo();

            return _jogo;
        }
        
    }
}
