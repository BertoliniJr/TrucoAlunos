﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truco.Interfaces;

namespace Truco.InfoJogo
{
    public class InfoJogoTruco
    {
        private ICartas _manilha;
        private IJogador[] _jogadores;

        public ICartas manilha
        {
            get
            {
                return _manilha;
            }

            set
            {
                _manilha = value;
            }
        }

        public IJogador[] jogadores
        {
            get
            {
                return _jogadores;
            }

            set
            {
                _jogadores = value;
            }
        }

    }
}