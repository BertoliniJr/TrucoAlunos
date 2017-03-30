using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;
using System.IO;

namespace Truco
{
    public class testeIlusionista
    {
        public void testePC()
        {
            
            int v1 = 0;
            int v2 = 0;


            for (int i = 0; i < 1000; i++)
            {

                Jogador jogador1 = new Jogador("Jogador 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new Jogador("Jogador 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe PC vs Equipe Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe PC ganhou {0}, {1}% ", v1 , (double)(v1)/(double)((v1+v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2 , (double)(v2)/(double)((v1+v2))* 100D);
            sw.WriteLine();
            sw.Close();

        }

        public void TesteJura()
        {
            
            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new JurandirOJogador("");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Jura vs Equipe Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Jura ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteJuvena()
        {
            


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Juvena 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new Juvenal("Juvena 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Juvena vs Equipe Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Juvena ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }
        
        public void TesteAlfa()
        {
           


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Juvena 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new JogadorEquipeAlfa("Juvena 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });
                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Alfa vs Equipe Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Alfa ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEJurandi()
        {
            


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1");
                Jogador jogador2 = new JurandirOJogador("");
                Jogador jogador3 = new Juvenal("Juvena 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Alfa e Juvenal vs Equipe Ilusionista e Jurandi");
            sw.WriteLine();
            sw.WriteLine("A equipe Alfa e Juvenal ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista e Jurandi ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEJuvenal()
        {
            

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1");
                Jogador jogador2 = new Juvenal("Juvena 2");
                Jogador jogador3 = new JurandirOJogador("");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Alfa e Jurandi vs Equipe Ilusionista e Juvenal");
            sw.WriteLine();
            sw.WriteLine("A equipe Alfa e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista e Juvenal ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEAlfa()
        {
            

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Juvena 1");
                Jogador jogador2 = new Juvenal("Alfa 2");
                Jogador jogador3 = new JurandirOJogador("");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Juvenal e Jurandi vs Equipe Ilusionista e Alfa");
            sw.WriteLine();
            sw.WriteLine("A equipe Juvenal e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista e Alfa ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEIlusionista()
        {
          

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new IlusionistaDaMesa("Ilusionista 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new IlusionistaDaMesa("Ilusionista 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Ilusionista e Ilusionista vs Equipe Ilusionista e Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Ilusionista 1 ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista 2 ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEJuJu()
        {


            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new Juvenal("Juvena 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new JurandirOJogador("");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });

                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Juvenal e Jurandi vs Equipe Ilusionista e Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Juvenal e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista  ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEJuraAlfa()
        {

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JurandirOJogador("");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new JogadorEquipeAlfa("Alfa 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Alfa e Jurandi vs Equipe Ilusionista e Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Alfa e Jurandi ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }

        public void TesteIlusionistaEAlfaeJuve()
        {

            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < 1000; i++)
            {
                Jogador jogador1 = new JogadorEquipeAlfa("Alfa 1");
                Jogador jogador2 = new IlusionistaDaMesa("Ilusionista 2");
                Jogador jogador3 = new Juvenal("Juvenal 3");
                Jogador jogador4 = new IlusionistaDaMesa("Ilusionista 4");

                Equipe equipe1 = new Equipe(new List<Jogador>() { jogador1, jogador3 });
                Equipe equipe2 = new Equipe(new List<Jogador>() { jogador2, jogador4 });

                Mesa mesaDeTruco = new Mesa(new List<Equipe>() { equipe1, equipe2 });


                mesaDeTruco.Jogar();
                if (mesaDeTruco.EquipeMesa[0].PontosEquipe >= 15)
                {
                    v1++;
                }
                else
                {
                    v2++;
                }
            }

            FileStream fs = new FileStream("Arquivo.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Equipe Juvenal e Alfa vs Equipe Ilusionista e Ilusionista");
            sw.WriteLine();
            sw.WriteLine("A equipe Juvenal e Alfa ganhou {0}, {1}% ", v1, (double)(v1) / (double)((v1 + v2)) * 100D);
            sw.WriteLine("A equipe Ilusionista 2 ganhou {0}, {1}% ", v2, (double)(v2) / (double)((v1 + v2)) * 100D);
            sw.WriteLine();
            sw.Close();
        }
    }


}
