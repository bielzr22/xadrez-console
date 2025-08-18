using tabuleiro;
using xadrez;
using xadrez_console;

internal class Program
{
    private static void Main(string[] args) {
        try {
            PartidaXadrez partidaXadrez = new PartidaXadrez();

            while (!partidaXadrez.terminado) {

                try { 
                    Console.Clear();
                    Tela.imprimirTabuleiro(partidaXadrez.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partidaXadrez.Turno );
                    Console.WriteLine("Aguardando jogada: " + partidaXadrez.jogadorAtual);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lePosicaoXadrez().convertePosicao();
                    partidaXadrez.validarPosicaoDeOrigem(origem);

                    bool[,] posicoesPossiveis = partidaXadrez.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partidaXadrez.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lePosicaoXadrez().convertePosicao();
                    partidaXadrez.validarPosicaoDeDestino(origem, destino);

                    partidaXadrez.realizaJogada(origem, destino);
                }
                catch(Exception ex){ 
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
        

    }
}