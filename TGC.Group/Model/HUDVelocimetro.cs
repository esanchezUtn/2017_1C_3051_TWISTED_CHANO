using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Direct3D;
using TGC.Core.Textures;
using TGC.Core.Utils;
using TGC.UtilsGroup;

namespace TGC.Group.Model
{
    class HUDVelocimetro
    {
        public float Velocidad { get; set; } 
        private TgcSprite spriteVelocimetro;
        private TgcSprite spriteAguja;
        private TgcDrawer2D drawer;
        private Boolean visible = false;

        //Velocidad del auto 
        public HUDVelocimetro(string MediaDirectory)
        {
            this.drawer = new TgcDrawer2D(D3DDevice.Instance.Device);
            this.Velocidad = 0;

            spriteVelocimetro = new TgcSprite(drawer);
            spriteVelocimetro.Texture = TgcTexture.createTexture(MediaDirectory + "Textures\\Sprites\\velocimetro.png");
            spriteVelocimetro.Position = new Vector2(D3DDevice.Instance.Width - 260, D3DDevice.Instance.Height - 260);
            spriteVelocimetro.Scaling = new Vector2(0.1f, 0.1f);

            spriteAguja = new TgcSprite(drawer);
            spriteAguja.Texture = TgcTexture.createTexture(MediaDirectory + "Textures\\Sprites\\aguja.png");
            spriteAguja.Position = new Vector2(D3DDevice.Instance.Width - 260, D3DDevice.Instance.Height - 260);
            spriteAguja.Scaling = new Vector2(0.1f, 0.1f);
            spriteAguja.RotationCenter = new Vector2(100, 100);

        }

        public void SetVisible(Boolean visible)
        {
            this.visible = visible;
        }

        public void Render()
        {
            if (this.visible)
            { 
                //Iniciar dibujado
                this.drawer.beginDrawSprite();

                //Dibujo velocimetro
                this.spriteVelocimetro.render();

                //Aplico rotacion a la aguja y la dibujo
                spriteAguja.Rotation = FastMath.Abs(Velocidad) / 800 * FastMath.PI / 2;
                this.spriteAguja.render();

                //Finalizar el dibujado de Sprites
                this.drawer.endDrawSprite();
                ///////////////////////
            }
        }
    }
}