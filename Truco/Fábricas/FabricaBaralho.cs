using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using Truco.Enumeradores;
using Truco.Baralhos;

namespace Truco.Fábricas
{
    class FabricaBaralho
    {
        public static IBaralho CriarBaralho(IJogo jogo)
        {
            if(jogo.tipoJogo == EnumTipoJogo.truco)
            {
                IBaralho baralho = new BaralhoTruco();
                return baralho;
            }
            return null;            
        }
    }
}
