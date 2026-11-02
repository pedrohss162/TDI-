using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TDI.Entidades
{
    public class Tropa
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public int Dano { get; set; }
        public int Defesa { get; set; }
        public float Velocidade { get; set; }
        
        public Vector2 Posicao { get; set; }

        public int pointAtual { get; set; } 

        public Tropa(string nome, int quantidade, int dano, int defesa, float velocidade, Vector2 posicao)
        {
            Nome = nome;
            Quantidade = quantidade;
            Dano = dano;
            Defesa = defesa;
            Posicao = posicao;
            Velocidade = velocidade;
            pointAtual = 0;
        }
    }
}