using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TDI
{
    public class Gamemap
    {
        int dificuldade, gold, vida, tempo;
        List<Entidades.Tropa> tropas;
        List<Vector2> posicoes;
        public Gamemap()
        {
            // Constructor logic here]
            tropas = new List<Entidades.Tropa>();
            posicoes = new List<Vector2>();

            gerarRota();
        }

        public int Dificuldade
        {
            get { return dificuldade; }
            set { dificuldade = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int Vida
        {
            get { return vida; }
            set { vida = value; }
        }

        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }

        private void GerarRota()
        {
            posicoes.Add(new Vector2(0, 0));
            posicoes.Add(new Vector2(300, 0));
            posicoes.Add(new Vector2(300, 200));
            posicoes.Add(new Vector2(200, 200));
            posicoes.Add(new Vector2(200, 400));
            posicoes.Add(new Vector2(300, 400));
            posicoes.Add(new Vector2(300, 300));
            posicoes.Add(new Vector2(0, 300));
        }

        public void update(GameTime gameTime)
        {
            if(input.IsKeyDown(Keys.num1))
            {
                tropas.Add(new Entidades.Tropa("Tropa1", 10, 5, 2, 1.0f, posicoes[0]));
            }

            if(tropas.Count > 0)
            {
                foreach(var tropa in tropas)
                {
                    if(tropa.posicao.X != posicoes[tropa.pointAtual + 1].X)
                    {
                        if(tropa.posicao.X < posicoes[tropa.pointAtual + 1].X)
                        {
                            tropa.posicao.X += tropa.Velocidade;
                        }
                        else
                        {
                            tropa.posicao.X -= tropa.Velocidade;
                        }
                        
                    }
                    else if(tropa.posicao.Y != posicoes[tropa.pointAtual + 1].Y)
                    {
                        if(tropa.posicao.Y < posicoes[tropa.pointAtual + 1].Y)
                        {
                            tropa.posicao.Y += tropa.Velocidade;
                        }
                        else
                        {
                            tropa.posicao.Y -= tropa.Velocidade;
                        }
                        
                    }
                    else
                    {
                        tropa.pointAtual++;
                    }
                }
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            // Drawing logic for the game map
        }
    }
}