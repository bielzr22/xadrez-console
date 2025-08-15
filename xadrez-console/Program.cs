using tabuleiro;
using xadrez;
using xadrez_console;

internal class Program
{
    private static void Main(string[] args)
    {
        try {

            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(Cor.Azul, tab), new Posicao(0, 0));
            tab.colocarPeca(new Torre(Cor.Azul, tab), new Posicao(1, 2));
            tab.colocarPeca(new Rei(Cor.Azul, tab), new Posicao(0, 0));
            tab.colocarPeca(new Rei(Cor.Azul, tab), new Posicao(3, 6));

            Tela.imprimirTabuleiro(tab);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }

    }
}