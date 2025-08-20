using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console.xadrez {
    internal class Peao : Peca {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Azul) {

                pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.defineValor(this.Posicao.Linha - 2, this.Posicao.Coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos) && QtdadeMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;                

                pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if(Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if(Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
            }
            else{

                pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.defineValor(this.Posicao.Linha + 2, this.Posicao.Coluna);
                if (Tabuleiro.posicaoValida(pos) && livre(pos) && QtdadeMovimentos == 0)
                    mat[pos.Linha, pos.Coluna] = true;                

                pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;

                pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                    mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool livre(Posicao pos) {
            return Tabuleiro.peca(pos) == null;
        }
        public override string ToString() {
            return "P";
        }
    }
}
