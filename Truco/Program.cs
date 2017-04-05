using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using Truco.Auxiliares;
using Truco.Interfaces;
using Truco.Enumeradores;

namespace Truco
{
    class Program
    {
        static void Main(string[] args)
        {

            Jogo.getJogo().tipoJogo = EnumTipoJogo.truco;
            List<IJogador> Jogadores = new List<IJogador>();

            Jogadores.Add(new Jogador("Jog 1"));
            Jogadores.Add(new Jogador("Jog 2"));
            Jogadores.Add(new Jogador("Jog 3"));
            Jogadores.Add(new Jogador("Jog 4"));

            Mesa nova = new Mesa(Jogadores);

            nova.jogar();
        }
    }
}
