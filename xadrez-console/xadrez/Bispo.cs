using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez_console.xadrez {
    internal class Bispo : Peca {

        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro) {
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //nordeste
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);

            while(Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }

                pos.defineValor(Posicao.Linha - 1, Posicao.Coluna + 1);
            }

            //noroeste
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);

            while(Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }

                pos.defineValor(Posicao.Linha - 1, Posicao.Coluna - 1);
            }

            //sudeste
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);

            while(Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }

                pos.defineValor(Posicao.Linha + 1, Posicao.Coluna + 1);
            }

            //sudoeste
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);

            while(Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }

                pos.defineValor(Posicao.Linha + 1, Posicao.Coluna - 1);
            }

            return mat;
        }

        public bool podeMover(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override string ToString() {
            return "B";
        }
    }
}
