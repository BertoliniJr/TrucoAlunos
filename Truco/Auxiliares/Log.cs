using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco.Auxiliares
{
    public class Log : IDisposable
    {
        public void Dispose()
        {
            foreach (var item in caminho.Values)
            {
                item.WriteLine($"Fim da execução do truco as {System.DateTime.Now}");
                item.Dispose();
            }
        }

        private Dictionary<TipoLog, StreamWriter> caminho;

        public Log()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            caminho = new Dictionary<TipoLog, StreamWriter>();
            caminho.Add(TipoLog.logControle, new StreamWriter($"{desktop}\\logControleTruco.txt", false));
            caminho.Add(TipoLog.logErro, new StreamWriter($"{desktop}\\logErroTruco.txt", false));
            caminho.Add(TipoLog.logJogador, new StreamWriter($"{desktop}\\logJogadorTruco.txt", false));
            caminho.Add(TipoLog.logTeste, new StreamWriter($"{desktop}\\logTesteTruco.txt", false));

            foreach (var item in caminho.Values)
            {
                item.WriteLine($"Inicio de execução do truco as {System.DateTime.Now}");
                item.WriteLine();
            }
        }

        public void logar(string msg, TipoLog tipo = TipoLog.logControle)
        {
            caminho[tipo].WriteLine(msg);
        }

        
        public void logar(string msg, params object[] args)
        {
            caminho[TipoLog.logControle].WriteLine(String.Format(msg, args));
        }

        public void logar()
        {
            caminho[TipoLog.logControle].WriteLine();
        }

    }
}
