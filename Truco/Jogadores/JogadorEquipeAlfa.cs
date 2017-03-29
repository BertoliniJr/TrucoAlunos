using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGame;



namespace CardGame
{

   

    class JogadorEquipeAlfa : Jogador
    {

        public JogadorEquipeAlfa(string n) : base(n) { }

        public override Carta Jogar(List<Carta> cartasRodada, Carta manilha)
        {

            // encontra maior da mesa
            if (_mao.Count == 3)
            {
                ordenar(manilha);
            }

            Carta maiorMesa = cartasRodada.LastOrDefault();
            for (int i = 0; i < cartasRodada.Count - 1; i++)
            {
                if (TrucoAuxiliar.comparar(cartasRodada[i], maiorMesa, manilha) > 0)
                {
                    maiorMesa = cartasRodada[i];
                }
            }

            //descarta
            Carta carta = _mao.LastOrDefault();

            if (cartasRodada.LastOrDefault() == null)
            {
                _mao.Remove(carta);
                return carta;
            }
            else if (cartasRodada.Count == 1)
            {



                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            }
                if (cartasRodada.Count == 2)
                {
                for (int i = 0; i < _mao.Count; i++)
                {
                    if (TrucoAuxiliar.comparar(_mao[i], maiorMesa, manilha) > 0)
                    {
                        carta = _mao[i];
                        _mao.RemoveAt(i);
                        return carta;

                    }
                }
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
                    
            }
            
          
                
                else 
            {
                for (int i = 0; i < _mao.Count; i++)
                {

                    if (TrucoAuxiliar.comparar(_mao[i], maiorMesa, manilha) > 0)
                    {
                         carta = _mao[i];
                        _mao.RemoveAt(i);
                        return carta;

                    }
                   
                }
                carta = _mao[0];
                _mao.RemoveAt(0);
                return carta;
            }
        }
        public override  void novaCarta(Carta carta, Jogador jogador, Carta manilha)
        {
            if (Equipe.BuscaID(IDEquipe).PontosEquipe < 12)
            {
                for (int i = 0; i < _mao.Count; i++)
                {
                
                    if (jogador.IDEquipe != IDEquipe
                        && TrucoAuxiliar.comparar(_mao[i], carta, manilha) > 0)
                    {
                        if (_mao[i].valor(manilha) > 10)
                        {
                            trucar(this, Truco.truco);
                        }
                    }

                }
           }


            if (jogador.IDEquipe != IDEquipe
                && ((Carta)carta).valor(manilha) < 2
                && _mao.Count > 0
                && _mao.Max(a => a.valor(manilha)) > 10)

                trucar(this, Truco.truco);
        }

        public override Escolha trucado(Jogador trucante, Truco valor, Carta manilha)
        {
            for (int i = 0; i < _mao.Count; i++)
            {
                if (_mao[i].valor(manilha) >= 13 )
                {
                    return Escolha.aumentar;
                }else
                {
                    if (_mao[i].valor(manilha) > 10)
                    {
                        return Escolha.aceitar;
                    }
                }
            }
            return Escolha.correr;

         }   


    }
}
