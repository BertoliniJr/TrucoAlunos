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
            int x = T1.Teste(new IlusionistaDaMesa("p1"), new IlusionistaDaMesa("p2"));
            
            TesteJurandir T2 = new TesteJurandir();
            int y = T2.Teste(new Juvenal("p1"), new Juvenal("p2"));

            TesteJurandir T3 = new TesteJurandir();
            int z = T3.Teste(new JogadorEquipeAlfa("p1"), new JogadorEquipeAlfa("p2"));

            Console.Clear();


            Console.WriteLine("Juranda teve um aproveitamento de {0}% contra IlusionistaDaMesa", x/10);
            Console.WriteLine("Juranda teve um aproveitamento de {0}% contra Juvenal", y/10);
            Console.WriteLine("Juranda teve um aproveitamento de {0}% contra EquipeAlfa", z/10);

            Console.ReadLine();
        }
    }
}
