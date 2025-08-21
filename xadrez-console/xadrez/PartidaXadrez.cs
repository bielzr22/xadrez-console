using tabuleiro;
using xadrez_console;
using xadrez_console.xadrez;
namespace xadrez {
    internal class PartidaXadrez {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }  
        public bool terminado { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque {  get; private set; }

        public PartidaXadrez() {
            tab = new Tabuleiro(8,8);
            Turno = 1;
            jogadorAtual = Cor.Azul;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
            terminado = false;
        }

        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.aumentaMovimento();

            Peca pecaCapturada = tab.retirarPeca(destino);

            tab.colocarPeca(p, destino);

            if (pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            //roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca torre = tab.retirarPeca(origemT);
                torre.aumentaMovimento();
                tab.colocarPeca(torre, destinoT);
            }

            //roque grande
            if(p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca torre = tab.retirarPeca(origemT);
                torre.aumentaMovimento();
                tab.colocarPeca(torre, destinoT);

            }

            return pecaCapturada;
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }

            if(estaEmXeque(adversaria(jogadorAtual)))
                xeque = true;
            else
                xeque = false;

            if (testeXequeMate(adversaria(jogadorAtual)))
                terminado = true;
            else {
                Turno++;
                mudaJogador();
            }
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retirarPeca(destino);
            p.decrementaMovimento();
            if(pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

            //roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);

                Peca torre = tab.retirarPeca(destinoT);
                torre.decrementaMovimento();
                tab.colocarPeca(torre, origemT);
            }

            //roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);

                Peca torre = tab.retirarPeca(destinoT);
                torre.decrementaMovimento();
                tab.colocarPeca(torre, origemT);

            }
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
            if(!tab.peca(origem).movimentoPossivel(destino))
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
            HashSet<Peca> aux = new HashSet<Peca> ();

            foreach (Peca x in pecas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }
            
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Azul)
                return Cor.Vermelha;
            else
                return Cor.Azul;
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) {
                if(x is Rei)
                    return x;
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null)
                throw new TabuleiroException("Não tem rei da cor " + cor + "no tabuleiro!");

            foreach (Peca x in pecasEmJogo(adversaria(cor))) {                
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                    return true;
            }
            return false;
        }

        public bool testeXequeMate(Cor cor) {
            foreach (var x in pecasEmJogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tab.Linhas; i++) {
                    for (int j = 0; j < tab.Colunas; j++) {
                        //pra cada peça em jogo, eu percorro sua matriz de movimentos possiveis
                        if (mat[i, j]) {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca capturada = executaMovimento(origem, destino);                            
                            bool xeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, capturada);
                            //pego essa peça, simulo um movimento e verifico se com esse movimento simulado o rei continua em xeque.
                            //se o rei não estiver em xeque, existe movimentos possiveis para tirar o rei do xeque: não é xeque-mate
                            if (!xeque)
                                return false;
                        }
                    }
                }
            }
            //se nenhuma peça tirar o rei do xeque, é xeque-mate
            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).convertePosicao());
            pecas.Add(peca);
        }
        private void colocarPecas() {
            colocarNovaPeca('a', 1, new Torre(Cor.Azul, tab));
            //colocarNovaPeca('b', 1, new Cavalo(Cor.Azul, tab));
            //colocarNovaPeca('c', 1, new Bispo(Cor.Azul, tab));
            //colocarNovaPeca('d', 1, new Dama(Cor.Azul, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.Azul, tab, this));
            //colocarNovaPeca('f', 1, new Bispo(Cor.Azul, tab));
            //colocarNovaPeca('g', 1, new Cavalo(Cor.Azul, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.Azul, tab));
            colocarNovaPeca('a', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('b', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('c', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('d', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('e', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('f', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('g', 2, new Peao(Cor.Azul, tab));
            colocarNovaPeca('h', 2, new Peao(Cor.Azul, tab));

            colocarNovaPeca('a', 8, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('b', 8, new Cavalo(Cor.Vermelha, tab));
            colocarNovaPeca('c', 8, new Bispo(Cor.Vermelha, tab));
            colocarNovaPeca('d', 8, new Dama(Cor.Vermelha, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.Vermelha, tab, this));
            colocarNovaPeca('f', 8, new Bispo(Cor.Vermelha, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.Vermelha, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Vermelha, tab));
            colocarNovaPeca('a', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('b', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('c', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('d', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('e', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('f', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('g', 7, new Peao(Cor.Vermelha, tab));
            colocarNovaPeca('h', 7, new Peao(Cor.Vermelha, tab));

            Tela.imprimirTabuleiro(tab);
        }
    }
}
