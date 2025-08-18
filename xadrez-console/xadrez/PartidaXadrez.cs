using tabuleiro;
using xadrez_console;
namespace xadrez {
    internal class PartidaXadrez {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }  
        public bool terminado { get; private set; }

        public PartidaXadrez() {
            tab = new Tabuleiro(8,8);
            Turno = 1;
            jogadorAtual = Cor.Azul;
            colocarPecas();
            terminado = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.aumentaMovimento();

            Peca pecaCapturada = tab.retirarPeca(destino);

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
        private void colocarPecas() {

            tab.colocarPeca(new Rei(Cor.Azul, tab), new PosicaoXadrez('e', 1).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Azul, tab), new PosicaoXadrez('d', 1).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Azul, tab), new PosicaoXadrez('f', 1).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Azul, tab), new PosicaoXadrez('e', 2).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Azul, tab), new PosicaoXadrez('d', 2).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Azul, tab), new PosicaoXadrez('f', 2).convertePosicao());


            tab.colocarPeca(new Rei(Cor.Vermelha, tab), new PosicaoXadrez('e', 8).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Vermelha, tab), new PosicaoXadrez('d', 8).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Vermelha, tab), new PosicaoXadrez('f', 8).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Vermelha, tab), new PosicaoXadrez('e', 7).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Vermelha, tab), new PosicaoXadrez('d', 7).convertePosicao());
            tab.colocarPeca(new Torre(Cor.Vermelha, tab), new PosicaoXadrez('f', 7).convertePosicao());


            Tela.imprimirTabuleiro(tab);
        }
    }
}
