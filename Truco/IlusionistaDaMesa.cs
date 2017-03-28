using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;

namespace Truco
{
    class IlusionistaDaMesa : Jogador
    {
        public IlusionistaDaMesa(string n) : base(n)
        {
        }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {
            Carta aux;
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }
            //ultima carta da mao
            if (_mao.Count == 1)
            {
                return jogaMenor();
            }
            //primeiro a jogar
            if (cartasRodada.LastOrDefault()==null)
            {
                return jogaMenor();
            }
            //segundo a jogar
            if (cartasRodada.Count==1)
            {
                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x,manilha))<7)
                {
                    return jogaMenor();
                }
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < TrucoAuxiliar.gerarValorCarta(_mao[i], manilha))
                    {
                        aux = _mao[i];
                        _mao.RemoveAt(i);
                        return aux;
                    }
                }
            }
            //terceiro a jogar
            if (cartasRodada.Count == 2)
            {
                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) > TrucoAuxiliar.gerarValorCarta(_mao.Last(), manilha))
                {
                    return jogaMenor();
                }
                aux = _mao[0];
                //aux = (Carta)_mao.Where(x=>x.Valor==_mao.Max(y=>y.Valor)&&x.Valor<11);
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.gerarValorCarta(_mao[i], manilha) < 11)
                    {
                        aux = _mao[i];
                    }
                }
                _mao.Remove(aux);
                return aux;
            }
            //pe
            for (int i = 0; i < _mao.Count; i++)
            {
                if (cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)) < TrucoAuxiliar.gerarValorCarta(_mao[i], manilha) && TrucoAuxiliar.gerarValorCarta(cartasRodada[cartasRodada.Count - 2], manilha)!= cartasRodada.Max(x => TrucoAuxiliar.gerarValorCarta(x, manilha)))
                {
                    aux = _mao[i];
                    _mao.RemoveAt(i);
                    return aux;
                }
            }
            return jogaMenor();
        }
        public void Correr()
        {
            _mao.RemoveAll(x=>x.Valor<15);
        }
        private Carta jogaMenor()
        {
            Carta aux;
            aux = _mao[0];
            _mao.RemoveAt(0);
            return aux;
        }
    }
}
