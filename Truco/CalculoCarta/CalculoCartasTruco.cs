using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;
using Truco.InfoJogo;
using Truco.Enumeradores;

namespace Truco.CalculoCarta
{
    class CalculoCartasTruco : ICalculoCartas
    {
        public int getPeso(ICartas carta)
        {
            InfoJogoTruco info = Jogo.getJogo().infoJogo as InfoJogoTruco;
            int valorManilha = info.manilha.getValor() == 13 ? 1 : info.manilha.getValor() == 7 ? 10 : info.manilha.getValor() + 1;

            int pesoICartas = carta.getValor() - 3;
            if (pesoICartas < 1)
                pesoICartas = pesoICartas + 13;
            if (pesoICartas > 4)
                pesoICartas = pesoICartas - 3;

            if (carta.getValor() == valorManilha)
            {
                pesoICartas = 10;

                switch (carta.Naipe)
                {
                    case Naipes.ouros:
                        pesoICartas = pesoICartas + 1;
                        break;
                    case Naipes.espadas:
                        pesoICartas = pesoICartas + 2;
                        break;
                    case Naipes.copas:
                        pesoICartas = pesoICartas + 3;
                        break;
                    case Naipes.paus:
                        pesoICartas = pesoICartas + 4;
                        break;
                }
            }
            return pesoICartas;        
        }
    }
}
