using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer4SpriteSheet.Animacion
{
    public class Animacion
    {
        public int Frame { get; set; }
        public int ContadorFrame { get; set; }
        public int VelocidadFrame { get; set; }
        public int velocidadFrame { get; set; }

        public Animacion(Texture2D texture, int contadorFrame)
        {
            Texture = texture;

            ContadorFrame = contadorFrame;


        }

    }
}
