using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Interfaces;
using Truco.Enumeradores;
using Truco;
using Truco.Fábricas;
namespace CardGame
{
    class Mesa : IControler
    {
        private Baralho baralhoMesa;
        private Log log;
        private List<IJogador> gamers;
        private List<IEquipe> equipeMesa;

        #region Descartar
        //public List<Equipe> EquipeMesa
        //{
        //    get { return equipeMesa; }
        //    set { equipeMesa = value; }
        //}

        //public Baralho BaralhoMesa
        //{
        //    get { return baralhoMesa; }
        //    set { baralhoMesa = value; }
        //}

        //private IRodada rodadaMesa;

        //public IRodada RodadaMesa
        //{
        //    get { return rodadaMesa; }
        //    set { rodadaMesa = value; }
        //}



        //private Jogador[] posicoes;

        //

        //private void preencheMesa()
        //{
        //    posicoes = new Jogador[equipeMesa.Count * equipeMesa[0].JogadoresEquipe.Count];
        //    int cont = 0;
        //    int contEquipe = 0;

        //    foreach (var equipe in equipeMesa)
        //    {
        //        cont = contEquipe;
        //        foreach (var jogador in equipe.JogadoresEquipe)
        //        {
        //            posicoes[cont] = jogador;
        //            cont += equipeMesa.Count;
        //        }
        //        contEquipe++;
        //    }
        //}

        //private Jogador[] circulaVetor(Jogador[] jogadores)
        //{
        //    Jogador aux = jogadores[0];

        //    for (int i = 0; i < jogadores.Length - 1; i++)
        //    {
        //        jogadores[i] = jogadores[i + 1];
        //    }
        //    jogadores[jogadores.Length - 1] = aux;

        //    return jogadores;
        //}

        #endregion

        public Mesa(List<IJogador> jogadores)
        {
            gamers = jogadores;
            redistribuirEquipes();

        }

        public void AddJogador(IJogador jog)
        {
            gamers.Add(jog);
        }

        //Métodos Interface
        public void jogar()
        {
            IRodada rodada = FabricaRodada.CriarRodada();
            while(rodada.fim() == false)
            {
                rodada.rodar();
            }
           
        }

        public void setJogadores(List<IJogador> jogadores)
        {
            gamers = jogadores;
        }

        public void redistribuirEquipes()
        {

            EnumTipoJogo x = Jogo.getJogo().tipoJogo;
            if (x == EnumTipoJogo.truco || x == EnumTipoJogo.buraco)
            {

                List<IJogador> aux = gamers;
                Random rdn = new Random();

                List<IJogador> Eqp1 = new List<IJogador>();
                int aleatorio = rdn.Next(0, aux.Count);
                Eqp1.Add(aux[aleatorio]);
                aux.RemoveAt(aleatorio);

                aleatorio = rdn.Next(0, aux.Count);
                Eqp1.Add(aux[aleatorio]);
                aux.RemoveAt(aleatorio);

                List<IJogador> Eqp2 = aux;

                equipeMesa.Add(new Equipe(Eqp1));
                equipeMesa.Add(new Equipe(Eqp2));

            }
            else
            {
                List<IJogador> aux = gamers;
                Random rdn = new Random();
                int aleatorio;

                while(aux.Count > 0)
                {
                    aleatorio = rdn.Next(0, aux.Count);
                    Equipe unique = new Equipe(new List<IJogador>() { aux[aleatorio] });
                    aux.RemoveAt(aleatorio);
                    equipeMesa.Add(unique);
                }

            }


        }

        public void setEquipe(List<IEquipe> equipe)
        {
            this.equipeMesa = equipe;
        }
    }
}
