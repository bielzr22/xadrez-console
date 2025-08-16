using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    internal class Rei : Peca
    {

        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro){
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //norte
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //nordeste
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //este
            pos.defineValor(this.Posicao.Linha, this.Posicao.Coluna + 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudeste
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sul
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //sudoeste
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //oeste
            pos.defineValor(this.Posicao.Linha, this.Posicao.Coluna - 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //noroeste
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);

            if (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

        public bool podeMover(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override string ToString() {
            return "R";
        }
    }
}

