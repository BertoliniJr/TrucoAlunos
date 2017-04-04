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
        public static IBaralho CriarBaralho()
        {
            switch (Jogo.getJogo().tipoJogo)
            {
                case EnumTipoJogo.truco:
                    IBaralho baralhoTruco = new BaralhoTruco();
                    return baralhoTruco;
                    
                case EnumTipoJogo.poker:
                    IBaralho baralhoPoker = new BaralhoPoker();
                    return baralhoPoker;
                   
                case EnumTipoJogo.malmal:
                    IBaralho baralhoMalMal = new BaralhoMalMal();
                    return baralhoMalMal;
                    
                case EnumTipoJogo.buraco:
                    IBaralho baralhoBuraco = new BaralhoBuraco();
                    return baralhoBuraco;

                case EnumTipoJogo.pife:
                    IBaralho baralhoPife = new BaralhoPife();
                    return baralhoPife;

                default:
                    break;
            }


            if(Jogo.getJogo().tipoJogo == EnumTipoJogo.truco)
            {
                
            }
            return null;            
        }
    }
}
