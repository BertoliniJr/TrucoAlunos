using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class JogadorProfessor : Jogador
    {
        public JogadorProfessor(string n) : base(n)
        {
            nome = $"Professor {n}";
            cartasMao = new List<Tuple<Jogador, Carta>>();
            trucoAtual = null;
            cartasNaoUasadas = geraBaralho();
            equipeTrucante = null;
        }

        private List<Tuple<Jogador, Carta>> cartasMao;
        private Truco? trucoAtual;
        private int? equipeTrucante;
        private List<Carta> cartasNaoUasadas;
        private int pontosRodada;

        private Carta jogarCarta(Carta a, Carta manilha)
        {
            avaliarTruco(manilha);
            _mao.Remove(a);
            return a;
        }

        private Carta menorQMata(Carta a, Carta manilha)
        {
            List<Carta> maoOrdenada = _mao.OrderBy(x => x.valor(manilha)).ToList();
            foreach (var item in maoOrdenada)
            {
                if (item.compara(a, manilha) > 0)
                    return item;
            }
            return null;
        }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            if (_mao.Count == 3)
            foreach (var item in _mao)
                cartasNaoUasadas.Remove(item);

            if (probabilidadeVitoria(manilha) > 70)
                pedirTruco();

            switch (_mao.Count)
            {
                case 3:
                    #region PrimeiraJogada
                    switch (cartasRodada.Count)
                    {
                        case 0:
                        #region SerPrimeiroJogar
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 1:
                        #region SerPrimeirodaDuplaJogar
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 2:
                        #region SerPenultimoJogar
                            if (cartasRodada[0].compara(cartasRodada[1], manilha) > 0 && cartasRodada[0].valor(manilha) > 7)
                                return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                            if (menorQMata(cartasRodada[1], manilha) != null)
                                return jogarCarta(menorQMata(cartasRodada[1], manilha), manilha);
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                            #endregion

                        case 3:
                            #region SerUltimo
                            if (menorQMata(cartasRodada[2], manilha) != null)
                                return jogarCarta(menorQMata(cartasRodada[2], manilha), manilha);
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        default:
                            break;
                    }
                    break;
                #endregion

                case 2:
                case 1:
                    #region SegundaOuUltimaJogada
                    switch (cartasRodada.Count)
                    {
                        case 0:
                            #region SerPrimeiroJogar
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 1:
                            #region SerPrimeirodaDuplaJogar
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).First(), manilha);
                        #endregion

                        case 2:
                            #region SerPenultimoJogar
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).Last(), manilha);
                        #endregion

                        case 3:
                            #region SerUltimo
                            return jogarCarta(_mao.OrderBy(x => x.valor(manilha)).Last(), manilha);
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
            cartasMao = new List<Tuple<Jogador, Carta>>();
            trucoAtual = null;
            cartasNaoUasadas = geraBaralho();
            equipeTrucante = null;
        }

        private void avaliarTruco(Carta manilha)
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
                    case Truco.truco:
                        if (probabilidadeVitoria(manilha) > 75)
                            pedirTruco();
                        break;
                    case Truco.seis:
                        if (probabilidadeVitoria(manilha) > 80 && Equipe.BuscaID(IDEquipe).PontosEquipe < 9)
                            pedirTruco();
                        break;
                    case Truco.nove:
                        if (probabilidadeVitoria(manilha) > 84 && Equipe.BuscaID(IDEquipe).PontosEquipe < 6)
                            pedirTruco();
                        break;
                    case Truco.doze:
                        if (probabilidadeVitoria(manilha) > 90 && Equipe.BuscaID(IDEquipe).PontosEquipe < 3)
                            pedirTruco();
                        break;
                    case Truco.jogo:
                        break;
                    default:
                        break;
                }
            }
        }
        
        public override void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
            if (cartasMao == null || cartasMao.Count == 4)
                cartasMao = new List<Tuple<Jogador, Carta>>();
            
            cartasMao.Add(new Tuple<Jogador, Carta>(jogador, carta));

            if (cartasMao.Count == 4)
            {
                cartasMao = cartasMao.OrderByDescending(x => x.Item2.valor(manilha)).ToList();
                if (cartasMao[0].Item2.compara(cartasMao[1].Item2, manilha) == 0
                    && cartasMao[0].Item1.IDEquipe == IDEquipe)
                    pontosRodada = 1;
            }

            cartasNaoUasadas.Remove(carta);

            avaliarTruco(manilha);
        }

        private void pedirTruco()
        {
            if (trucoAtual == null)
            {
                equipeTrucante = IDEquipe;
                trucoAtual = Truco.truco;
            }
            else
            {
                equipeTrucante = IDEquipe;
                trucoAtual = trucoAtual.Value.proximo();
            }
            base.trucar(this, trucoAtual.Value);
        }

        private int probabilidadeVitoria(Carta manilha)
        {
            int vitoria;
            cartasNaoUasadas.Remove(manilha);
            List<Carta> mesaEquipe = cartasMao.Where(x => x.Item1.IDEquipe == IDEquipe).Select(z => z.Item2).ToList();
            Carta maiorcarta = (_mao).Union(mesaEquipe).OrderBy(y => y.valor(manilha)).Last();
            double cartasMelhores = cartasNaoUasadas.Where(x => x.valor(manilha) >= (maiorcarta.valor(manilha))).Count();
            double totalCartas = cartasNaoUasadas.Count();
            vitoria = (int)((1 - (cartasMelhores / totalCartas)) * 100);
            if (pontosRodada == 1)
                return vitoria;
            else
            {
                if (_mao.Count() > 1)
                {
                    cartasMelhores = cartasNaoUasadas.Where(x => x.valor(manilha) >= (_mao.OrderByDescending(y => y.valor(manilha)).ToList()[1].valor(manilha))).Count();
                    totalCartas = cartasNaoUasadas.Count();
                    return (vitoria * (int)((1 - (cartasMelhores / totalCartas)) * 100))/100;
                }
                else
                    return vitoria;
            }
        }

        private static List<Carta> geraBaralho()
        {
            List<Carta> retorno = new List<Carta>();
            for (int i = 1; i < 14; i++)
            {
                if (i != 8 && i != 9 && i != 10)
                {
                    retorno.Add(new Carta(Naipes.copas, i));
                    retorno.Add(new Carta(Naipes.espadas, i));
                    retorno.Add(new Carta(Naipes.ouros, i));
                    retorno.Add(new Carta(Naipes.paus, i));
                }
            }
            return retorno;
        }

        public override Escolha trucado(Jogador trucante, Truco pedido, Carta manilha)
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
                    case Truco.truco:
                        if (90 > probabilidadeVitoria(manilha) && probabilidadeVitoria(manilha) > 70)
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 80)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case Truco.seis:
                        if ( (Equipe.BuscaID(IDEquipe).PontosEquipe >= 9 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case Truco.nove:
                        if ((Equipe.BuscaID(IDEquipe).PontosEquipe >= 6 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case Truco.doze:
                        if ((Equipe.BuscaID(IDEquipe).PontosEquipe >= 3 && probabilidadeVitoria(manilha) > 75)
                            || (probabilidadeVitoria(manilha) < 90 && probabilidadeVitoria(manilha) > 75))
                            return Escolha.aceitar;
                        else if (probabilidadeVitoria(manilha) >= 90)
                            return Escolha.aumentar;
                        else return Escolha.correr;

                    case Truco.jogo:
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
