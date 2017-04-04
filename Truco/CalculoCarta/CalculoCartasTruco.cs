using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace Truco.CalculoCarta
{
    class CalculoCartasTruco : ICalculoCartas
    {
        public int getPeso()
        {
            int valorManilha = manilha.Valor == 13 ? 1 : manilha.Valor == 7 ? 10 : manilha.Valor + 1;

            int pesoICartas = ICartas.Valor - 3;
            if (pesoICartas < 1)
                pesoICartas = pesoICartas + 13;
            if (pesoICartas > 4)
                pesoICartas = pesoICartas - 3;

            if (ICartas.Valor == valorManilha)
            {
                pesoICartas = 10;

                switch (getNaipe())
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
