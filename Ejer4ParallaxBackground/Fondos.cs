using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Ejer4ParallaxBackground
{
   public class Fondos
    {
        public Texture2D textura;
        public Rectangle rectangulo;

        public void dibujar(SpriteBatch sprite)
        {
            sprite.Draw(textura,rectangulo,Color.White);
        }
    }

   public class Moverse : Fondos
    {
        public Moverse(Texture2D nuevaTex, Rectangle nuevoRec)
        {
            textura = nuevaTex;
            rectangulo = nuevoRec;
        }

        public void Actualizar()
        {
            rectangulo.X -= 3; //CAMBIANDO EL NUMERO, VA MAS RAPIDO O LENTO 

        }
    }
}
