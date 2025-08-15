using tabuleiro;


namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab){
            for(int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if(tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i,j));
                        Console.Write(" ");
                    }   
                }
                Console.WriteLine();
            }
           Console.Write("  a b c d e f g h");   
        }

        public static void imprimirPeca(Peca peca) { 
            if(peca.Cor == Cor.Vermelha) {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
