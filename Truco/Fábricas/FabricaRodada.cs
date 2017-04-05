using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using Truco.Enumeradores;
using CardGame;

namespace Truco.Fábricas
{
    public static class FabricaRodada
    {
        public static IRodada CriarRodada(List<IEquipe> Eqp)
        {
            EnumTipoJogo jogo = (EnumTipoJogo)Jogo.getJogo().infoJogo;
            switch (jogo)
            {
                case EnumTipoJogo.truco:
                    return new RodadaTruco(Eqp);
                  
                case EnumTipoJogo.poker:
                    return new RodadaPoker(Eqp);

                case EnumTipoJogo.malmal:
                    return new RodadaMalmal(Eqp);

                case EnumTipoJogo.buraco:
                    throw new NotImplementedException();

                case EnumTipoJogo.pife:
                    throw new NotImplementedException();

                default:
                    break;
            }
            return null;
        }


    }
}
