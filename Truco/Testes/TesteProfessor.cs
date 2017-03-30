using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using System.IO;

namespace Truco.Testes
{
    class TesteProfessor
    {
        public void testePC(Equipe equipe1, Equipe equipe2, string arquivo)
        {
            int v1 = 0;
            int v2 = 0;

            Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
            
            for (int i = 0; i < 1000; i++)
            {
                mesaDeTruco.Jogar();
                int temp = mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15 ? v1++ : v2++;
            }

            FileStream fs = new FileStream(arquivo, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe PC vs Equipe Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe PC ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();

        }
    }
}
