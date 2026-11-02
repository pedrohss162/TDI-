using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TDI
{
    public class Gamemap
    {
        List<Entidades.Tropa> tropas = new List<Entidades.Tropa>();
        List<Vector2> posicoes = new List<Vector2>();
        KeyboardState tecladoAnterior;

        public Gamemap(Viewport viewport)
        {
            GerarRota(viewport);
        }

        private void GerarRota(Viewport viewport)
        {
            Vector2 containerSize = new Vector2(viewport.Width * 0.8f, viewport.Height*0.8f);
            Vector2 containerPosition = new Vector2(viewport.Width * 0.1f, viewport.Height * 0.1f);

            // Gera os waypoints ao redor do container
            posicoes.Add(containerPosition);
            posicoes.Add(containerPosition + new Vector2(containerSize.X, 0));
            posicoes.Add(containerPosition + new Vector2(containerSize.X, containerSize.Y));
            posicoes.Add(containerPosition + new Vector2(0, containerSize.Y));
            posicoes.Add(containerPosition); // volta para o início
        }

        public void Update(GameTime gameTime)
        {
            var teclado = Keyboard.GetState();

            // envia uma tropa por aperto da tecla 1
            if (teclado.IsKeyDown(Keys.D1) && tecladoAnterior.IsKeyUp(Keys.D1))
                tropas.Add(new Entidades.Tropa("Soldado", 10, 5, 2, 100f, posicoes[0]));

            tecladoAnterior = teclado;

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var tropa in tropas)
            {
                // chegou no último waypoint: para
                if (tropa.pointAtual >= posicoes.Count - 1)
                    continue;

                Vector2 destino = posicoes[tropa.pointAtual + 1];
                Vector2 falta = destino - tropa.Posicao;
                float passo = tropa.Velocidade * dt;

                if (falta.Length() <= passo)
                {
                    tropa.Posicao = destino;   // encaixa no waypoint
                    tropa.pointAtual++;
                }
                else
                {
                    falta.Normalize();
                    tropa.Posicao += falta * passo;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D pixel)
        {
            foreach (var tropa in tropas)
                spriteBatch.Draw(pixel, new Rectangle((int)tropa.Posicao.X, (int)tropa.Posicao.Y, 16, 16), Color.Red);
        }
    }
}