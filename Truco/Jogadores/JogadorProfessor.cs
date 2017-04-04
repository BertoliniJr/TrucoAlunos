using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Auxiliares;
using Truco.Enumeradores;

namespace CardGame
{
    class JogadorProfessor : Jogador
    {
        public JogadorProfessor(string n, Log logar) : base(n, logar)
        {
            nome = $"Professor {n}";
            ICartassMao = new List<Tuple<Jogador, ICartas>>();
            trucoAtual = null;
            ICartassNaoUasadas = geraBaralho();
            equipeTrucante = null;
        }

        private List<Tuple<Jogador, ICartas>> ICartassMao;
        private EnumTruco? trucoAtual;
        private int? equipeTrucante;
        private List<ICartas> ICartassNaoUasadas;
        private int pontosRodada;

        private ICartas jogarICartas(ICartas a, ICartas manilha)
        {
            avaliarTruco(manilha);
            _mao.Remove(a);
            return a;
        }

        private ICartas menorQMata(ICartas a, ICartas manilha)
        {
            List<ICartas> maoOrdenada = _mao.OrderBy(x => x.valor(manilha)).ToList();
            foreach (var item in maoOrdenada)
            {
                if (item.compara(a, manilha) > 0)
                    return item;
            }
            return null;
        }

        public override ICartas Jogar(List<ICartas> ICartassRodada, ICartas manilha)
        {
            if (_mao.Count == 3)
            foreach (var item in _mao)
                ICartassNaoUasadas.Remove(item);

            if (probabilidadeVitoria(manilha) > 70)
                pedirTruco();

            switch (_mao.Count)
            {
                case 3:
                    #region PrimeiraJogada
                    switch (ICartassRodada.Count)
                    {
                        case 0:
                        #region SerPrimeiroJogar
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 1:
                        #region SerPrimeirodaDuplaJogar
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 2:
                        #region SerPenultimoJogar
                            if (ICartassRodada[0].compara(ICartassRodada[1], manilha) > 0 && ICartassRodada[0].valor(manilha) > 7)
                                return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                            if (menorQMata(ICartassRodada[1], manilha) != null)
                                return jogarICartas(menorQMata(ICartassRodada[1], manilha), manilha);
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                            #endregion

                        case 3:
                            #region SerUltimo
                            if (menorQMata(ICartassRodada[2], manilha) != null)
                                return jogarICartas(menorQMata(ICartassRodada[2], manilha), manilha);
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        default:
                            break;
                    }
                    break;
                #endregion

                case 2:
                case 1:
                    #region SegundaOuUltimaJogada
                    switch (ICartassRodada.Count)
                    {
                        case 0:
                            #region SerPrimeiroJogar
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 1:
                            #region SerPrimeirodaDuplaJogar
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 2:
                            #region SerPenultimoJogar
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).Last(), manilha);
                        #endregion

                        case 3:
                            #region SerUltimo
                            return jogarICartas(_mao.OrderBy(x => x.valor(manilha)).Last(), manilha);
                        #endregion

                        default:
                            break;
                    }
                    break;
                #endregion

                default:
                    break;
            }

            return _mao.OrderBy(x => x.valor(manilha)).First();

        }

        public override void NovaMao()
        {
            base.NovaMao();
            ICartassMao = new List<Tuple<Jogador, ICartas>>();
            trucoAtual = null;
            ICartassNaoUasadas = geraBaralho();
            equipeTrucante = null;
        }

        private void avaliarTruco(ICartas manilha)
        {
            if (Equipe.BuscaID(IDEquipe).PontosEquipe >= 12 || Equipe.BuscaID(IDEquipe).Adversario.PontosEquipe >= 12 || (equipeTrucante.HasValue && IDEquipe == equipeTrucante))
                return;

            if (trucoAtual == null && (probabilidadeVitoria(manilha) > 70 || probabilidadeVitoria(manilha) < 15))
                pedirTruco();
            else if (trucoAtual == null)
                return;
            else
            {
                switch (trucoAtual.Value)
                {
                    case EnumTruco.truco:
                        if (probabilidadeVitoria(manilha) > 75)
                            pedirTruco();
                        break;
                    case EnumTruco.seis:
                        if (probabilidadeVitoria(manilha) > 80 && Equipe.BuscaID(IDEquipe).PontosEquipe < 9)
                            pedirTruco();
                        break;
                    case EnumTruco.nove:
                        if (probabilidadeVitoria(manilha) > 84 && Equipe.BuscaID(IDEquipe).PontosEquipe < 6)
                            pedirTruco();
                        break;
                    case EnumTruco.doze:
                        if (probabilidadeVitoria(manilha) > 90 && Equipe.BuscaID(IDEquipe).PontosEquipe < 3)
                            pedirTruco();
                        break;
                    case EnumTruco.jogo:
                        break;
                    default:
                        break;
                }
            }
        }
        
        public override void novaICartas(ICartas ICartas, Jogador jogador, ICartas manilha)
        {
            if (ICartassMao == null || ICartassMao.Count == 4)
                ICartassMao = new List<Tuple<Jogador, ICartas>>();
            
            ICartassMao.Add(new Tuple<Jogador, ICartas>(jogador, ICartas));

            if (ICartassMao.Count == 4)
            {
                ICartassMao = ICartassMao.OrderByDescending(x => x.Item2.valor(manilha)).ToList();
                if (ICartassMao[0].Item2.compara(ICartassMao[1].Item2, manilha) == 0
                    && ICartassMao[0].Item1.IDEquipe == IDEquipe)
                    pontosRodada = 1;
            }

            ICartassNaoUasadas.Remove(ICartas);

            avaliarTruco(manilha);
        }

        private void pedirTruco()
        {
            if (trucoAtual == null)
            {
                equipeTrucante = IDEquipe;
                trucoAtual = EnumTruco.truco;
            }
            else
            {
                equipeTrucante = IDEquipe;
                trucoAtual = trucoAtual.Value.proximo();
            }
            base.trucar(this, trucoAtual.Value);
        }

        private int probabilidadeVitoria(ICartas manilha)
        {
            int vitoria;
            ICartassNaoUasadas.Remove(manilha);
            List<ICartas> mesaEquipe = ICartassMao.Where(x => x.Item1.IDEquipe == IDEquipe).Select(z => z.Item2).ToList();
            ICartas maiorICartas = (_mao).Union(mesaEquipe).OrderBy(y => y.valor(manilha)).Last();
            double ICartassMelhores = ICartassNaoUasadas.Where(x => x.valor(manilha) >= (maiorICartas.valor(manilha))).Count();
            double totalICartass = ICartassNaoUasadas.Count();
            vitoria = (int)((1 - (ICartassMelhores / totalICartass)) * 100);
            if (pontosRodada == 1)
                return vitoria;
            else
            {
                if (_mao.Count() > 1)
                {
                    ICartassMelhores = ICartassNaoUasadas.Where(x => x.valor(manilha) >= (_mao.OrderByDescending(y => y.valor(manilha)).ToList()[1].valor(manilha))).Count();
                    totalICartass = ICartassNaoUasadas.Count();
                    return (vitoria * (int)((1 - (ICartassMelhores / totalICartass)) * 100))/100;
                }
                else
                    return vitoria;
            }
        }

        private static List<ICartas> geraBaralho()
        {
            List<ICartas> retorno = new List<ICartas>();
            for (int i = 1; i < 14; i++)
            {
                if (i != 8 && i != 9 && i != 10)
                {
                    retorno.Add(new ICartas(Naipes.copas, i));
                    retorno.Add(new ICartas(Naipes.espadas, i));
                    retorno.Add(new ICartas(Naipes.ouros, i));
                    retorno.Add(new ICartas(Naipes.paus, i));
                }
            }
            return retorno;
        }

        public override Escolha trucado(Jogador trucante, EnumTruco pedido, ICartas manilha)
        {
            if (trucante.IDEquipe == IDEquipe)
            {
                equipeTrucante = IDEquipe;
                trucoAtual = pedido;
                return Escolha.aceitar;
            }
            else
            {
                switch (pedido)
                {
                    case EnumTruco.truco:
                        if (90 > probabilidadeVitoria(manilha) && probabilidadeVitoria(manilha) > 50)
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 80)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case EnumTruco.seis:
                        if ( (Equipe.BuscaID(IDEquipe).PontosEquipe >= 9 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case EnumTruco.nove:
                        if ((Equipe.BuscaID(IDEquipe).PontosEquipe >= 6 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case EnumTruco.doze:
                        if ((Equipe.BuscaID(IDEquipe).PontosEquipe >= 3 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case EnumTruco.jogo:
                        if (probabilidadeVitoria(manilha) > 80)
                            return Escolha.aceitar;
                        else return Escolha.correr;
                    default:
                        return Escolha.aceitar;
                }
            }
        }
    }
}
