
namespace Tabuleiro
{
    internal class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdadeMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; set; }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro )
        {
            Posicao = posicao;
            Cor = cor;
            QtdadeMovimentos = 0;
            Tabuleiro = tabuleiro;
        }
    }
}
