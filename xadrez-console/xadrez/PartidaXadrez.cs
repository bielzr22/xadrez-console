using tabuleiro;
using xadrez_console;
namespace xadrez {
    internal class PartidaXadrez {
        public Tabuleiro tab { get; private set; }
        private int Turno;
        private Cor jogadorAtual;
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
