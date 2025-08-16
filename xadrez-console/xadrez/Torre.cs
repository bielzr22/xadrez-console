

using tabuleiro;

namespace xadrez
{
    internal class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro){

        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //norte
            pos.defineValor(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //leste
            pos.defineValor(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //sul
            pos.defineValor(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //oeste
            pos.defineValor(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (Tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.peca(pos) != null && Tabuleiro.peca(pos).Cor != this.Cor) {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }

        public bool podeMover(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override string ToString() {
            return "T";
        }

    }
}
