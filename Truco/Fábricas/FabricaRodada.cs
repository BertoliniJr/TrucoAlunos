using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using Truco.Enumeradores;

namespace Truco.Fábricas
{
    public static class FabricaRodada
    {
        public static IRodada CriarRodada()
        {
            EnumTipoJogo jogo = (EnumTipoJogo)Jogo.getJogo().infoJogo;
            switch (jogo)
            {
                case EnumTipoJogo.truco:
                    throw new NotImplementedException();
                  
                case EnumTipoJogo.poker:
                    throw new NotImplementedException();
                case EnumTipoJogo.malmal:
                    throw new NotImplementedException();
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
