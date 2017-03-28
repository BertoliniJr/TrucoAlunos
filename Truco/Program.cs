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
            int x = TesteJurandir.Teste1(new IlusionistaDaMesa("p1"));
            Console.WriteLine(x);
         