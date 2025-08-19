using tabuleiro;
using xadrez_console;
namespace xadrez {
    internal class PartidaXadrez {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }  
        public bool terminado { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez() {
            tab = new Tabuleiro(8,8);
            Turno = 1;
            jogadorAtual = Cor.Azul;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
            terminado = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.aumentaMovimento();

            Peca pecaCapturada = tab.retirarPeca(destino);

            if(pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            if (jogadorAtual != tab.peca(pos).Cor)
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            if (!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if(!tab.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }

        private void mudaJogador() {
            if (jogadorAtual == Cor.Azul)
                jogadorAtual = Cor.Vermelha;
            else
                jogadorAtual = Cor.Azul;
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> pecas = new HashSet<Peca>();

            foreach (Peca x in capturadas) {
                if(x.Cor == cor) {
                    pecas.Add(x);
                }
            }
            return pecas;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> pecas = new HashSet<Peca> ();

            foreach (Peca x in pecas) {
                if (x.Cor == cor) {
                    pecas.Add(x);
                }
            }
            
            pecas.ExceptWith(pecasCapturadas(cor));
            return pecas;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).convertePosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() {
            colocarNovaPeca('e', 1, new Rei(Cor.Azul, tab));
            colocarNovaPeca('d', 1, new Torre(Cor.Azul, tab));
            colocarNovaPeca('d', 2, new Torre(Cor.Azul, tab));
            colocarNovaPeca('e', 2, new Torre(Cor.Azul, tab));
            colocarNovaPeca('f', 2, new Torre(Cor.Azul, tab));
            colocarNovaPeca('f', 1, new Torre(Cor.Azul, tab));

            colocarNovaPeca('e', 8, new Rei(Cor.Vermelha, tab));
            colocarNovaPeca('d', 8, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('d', 7, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('e', 7, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('f', 7, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('f', 8, new Torre(Cor.Vermelha, tab));

            Tela.imprimirTabuleiro(tab);
        }
    }
}
