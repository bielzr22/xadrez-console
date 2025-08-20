using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console.xadrez {
    internal class Cavalo : Peca {

        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.defineValor(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            pos.defineValor(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if(Tabuleiro.posicaoValida(pos) && podeMover(pos))
                mat[Posicao.Linha, Posicao.Coluna] = true;

            return mat;
        }

        public override string ToString() {
            return "C";
        }
        public bool podeMover(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }
    }
}
