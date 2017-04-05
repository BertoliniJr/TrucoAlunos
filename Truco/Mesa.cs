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


        /// <summary>
        /// Cosntrutor generico de mesa onde os jogadores e as equipes ainda não foram declaradas
        /// </summary>
        public Mesa()
        {
            gamers = new List<IJogador>();
            equipeMesa = new List<IEquipe>();
        }

        /// <summary>
        /// Inicia a Lista de equipes a partir das lista de jogadores recebidas
        /// </summary>
        /// <param name="jogadores"></param>
        public Mesa(List<IJogador> jogadores)
        {
            gamers = new List<IJogador>();
            gamers = jogadores;
            equipeMesa = new List<IEquipe>();
            redistribuirEquipes();
        }

        /// <summary>
        /// Construtor onde as equipes já estão iniciadas
        /// </summary>
        /// <param name="equipes"></param>
        public Mesa(List<IEquipe> equipes)
        {
            equipeMesa = equipes;
            gamers = new List<IJogador>();

            foreach (IEquipe x in equipes)
            {
                gamers.Concat(x.jogadores);
            }

        }



        /// <summary>
        /// Metodo para adicionar um novo jogador na mesa.
        /// </summary>
        /// <param name="jog"></param>
        public void AddJogador(IJogador jog)
        {
            gamers.Add(jog);
        }

        //Métodos Interface

        /// <summary>
        /// Metodo para iniciar o jogo chamando a rodada.
        /// </summary>
        public void jogar()
        {

            if (gamers.Count == 0)
            {
                throw new Exception();
            }
            else
            {
                IRodada rodada = FabricaRodada.CriarRodada(equipeMesa);
                int numRodadas = 0;
                while (rodada.fim() == false)
                {
                    Log.getLog().logar($"{numRodadas}Rodada", TipoLog.logControle);
                    rodada.rodar();
                    numRodadas++;
                }
                Log.getLog().logar($"O jogo terminou depois de {numRodadas}Rodada", TipoLog.logControle);
            }

        }

        /// <summary>
        /// Preencher a lista de jogadores no meu jogo atual
        /// </summary>
        /// <param name="jogadores"></param>
        public void setJogadores(List<IJogador> jogadores)
        {
            gamers = jogadores;
        }


        /// <summary>
        /// Redistribui os jogadores cadastrados entre equipes para que o jogo comece
        /// </summary>
        public void redistribuirEquipes()
        {

            EnumTipoJogo x = Jogo.getJogo().tipoJogo;
            if (x == EnumTipoJogo.truco || x == EnumTipoJogo.buraco)
            {
                List<IJogador> aux = new List<IJogador>();

                foreach (IJogador  jog in gamers)
                {
                    aux.Add(jog);
                }

                Random rdn = new Random();

                List<IJogador> Eqp1 = new List<IJogador>();
                int aleatorio = rdn.Next(0, aux.Count);
                Eqp1.Add(aux[aleatorio]);
                aux.RemoveAt(aleatorio);

                aleatorio = rdn.Next(0, aux.Count);
                Eqp1.Add(aux[aleatorio]);
                aux.RemoveAt(aleatorio);

                List<IJogador> Eqp2 = aux;

                equipeMesa = new List<IEquipe>();
                equipeMesa.Add(new Equipe(Eqp1));
                equipeMesa.Add(new Equipe(Eqp2));

            }
            else
            {
                List<IJogador> aux = new List<IJogador>();

                foreach (IJogador jogadorAuxiliar in gamers)
                    aux.Add(jogadorAuxiliar);

                Random rdn = new Random();
                int aleatorio;

                while (aux.Count > 0)
                {
                    aleatorio = rdn.Next(0, aux.Count);
                    Equipe unique = new Equipe(new List<IJogador>() { aux[aleatorio] });
                    aux.RemoveAt(aleatorio);
                    equipeMesa.Add(unique);
                }

            }


        }


        /// <summary>
        /// Setar as possiveis equipes para o jogo poder começar
        /// </summary>
        /// <param name="equipe"></param>
        public void setEquipe(List<IEquipe> equipe)
        {
            this.equipeMesa = equipe;
        }
    }
}
