using tabuleiro;
using xadrez;
using xadrez_console;

internal class Program
{
    private static void Main(string[] args)
    {
        PosicaoXadrez px = new PosicaoXadrez('a', 1);
        Console.WriteLine(px);

        Console.WriteLine(px.convertePosicao());

    }
}