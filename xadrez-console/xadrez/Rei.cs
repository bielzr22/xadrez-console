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
        private PartidaXadrez partidaXadrez;
        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partidaXadrez) : base(cor, tabuleiro){
            this.partidaXadrez = partidaXadrez;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);

            return p != null && p is Torre && p.Cor == this.Cor && p.QtdadeMovimentos == 0;
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

            //jogada especial roque
            if (this.QtdadeMovimentos == 0 && !partidaXadrez.xeque) {
                Posicao pTorre1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 3);
                //roque pequeno
                if (testeTorreParaRoque(pTorre1)) {
                    Posicao p1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna + 2);

                    if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null) {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                    
                }

                Posicao pTorre2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 4);
                //roque grande
                if (testeTorreParaRoque(pTorre2)) {
                    Posicao p1 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(this.Posicao.Linha, this.Posicao.Coluna - 3);

                    if (Tabuleiro.peca(p1) == null && Tabuleiro.peca(p2) == null && Tabuleiro.peca(p3) == null) {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
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

