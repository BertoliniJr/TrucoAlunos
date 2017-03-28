using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace Truco
{
    class Program
    {
        static void Main(string[] args)
        {
            testeIlusionista ti = new testeIlusionista();

            ti.testePC();
            ti.TesteJuvena();
            ti.TesteJura();
            ti.TesteAlfa();
            ti.TesteIlusionistaEJuvenal();
            ti.TesteIlusionistaEJurandi();
            ti.TesteIlusionistaEJuraAlfa();
            ti.TesteIlusionistaEJuJu();
            ti.TesteIlusionistaEIlusionista();
            ti.TesteIlusionistaEAlfaeJuve();
            ti.TesteIlusionistaEAlfa();
        }
    }
}
