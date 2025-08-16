using tabuleiro;
using xadrez;
using xadrez_console;

internal class Program
{
    private static void Main(string[] args) {
        try {
            PartidaXadrez partidaXadrez = new PartidaXadrez();

            while (!partidaXadrez.terminado) {
                Console.Clear();
                Tela.imprimirTabuleiro(partidaXadrez.tab);
                Console.WriteLine();

                Console.Write("Origem: ");
                Posicao origem = Tela.lePosicaoXadrez().convertePosicao();

                bool[,] posicoesPossiveis = partidaXadrez.tab.peca(origem).movimentosPossiveis();

                Console.Clear();
                Tela.imprimirTabuleiro(partidaXadrez.tab, posicoesPossiveis);

                
                Console.Write("Destino: ");
                Posicao destino = Tela.lePosicaoXadrez().convertePosicao();

                partidaXadrez.executaMovimento(origem, destino);
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        

    }
}