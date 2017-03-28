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
            TesteJurandir T1 = new TesteJurandir();
            TesteJurandir T2 = new TesteJurandir();
            TesteJurandir T3 = new TesteJurandir();
            int x = T1.Teste(new IlusionistaDaMesa("p1"), new IlusionistaDaMesa("p2"));
            int y = T2.Teste(new Juvenal("p1"), new Juvenal("p2"));
            int z = T3.Teste(new JogadorEquipeAlfa("p1"), new JogadorEquipeAlfa("p2"));
            Console.WriteLine("Jurandir teve " + x / 10 + "% de aproveitamento contra o Ilusonista");
            Console.WriteLine("Jurandir teve " + y / 10 + "% de aproveitamento contra o Juvenal");
            Console.WriteLine("Jurandir teve " + z / 10 + "% de aproveitamento contra o Alfa");

        }
    }
}
