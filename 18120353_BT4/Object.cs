using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ObjectBuilder
{
    static class Constants
    {
        public const double PI = 3.14159;
        public const uint WorldUnit = 1;
        public const float CameraUnit = 0.05f;

    }

    class Object
    {
        //vertices's coordinates x, y, z
        protected double[,] mVertices;

        //vertice's indices.
        protected int[,] indicesObject;
        protected int[,] indicesOutLine;

        protected Color color;
        protected Color linecolor;

        protected Transformer transformer;
        protected double unit;

        //texture
        protected double[,] mTextures;
        protected Texture texture;
        protected string texturePath;

        protected bool isChoose = false;


        //properties
        public string TexturePath
        {
            get => this.texturePath;
            set { this.texturePath = value; }
        }
        public bool IsChoose {
            get => this.isChoose;
            set { this.isChoose = value; }
}
        public Transformer Transform
        {
            get => this.transformer;
            set { this.transformer = value; }
        }

        public Color Color
        {
            get => this.color;
            set { this.color = value;  }
        }

        public Texture Texture
        {
            get => this.texture;
            set { this.texture = value; }
        }
        public Object()
        {
            color = new Color();
            color = Color.White;

            linecolor = new Color();
            linecolor = Color.Black;

            transformer = new Transformer();
            texture = new Texture();
            unit = 1.0f;
        }

        
        //method
        public virtual void DrawObject(OpenGL gl) { }

        public virtual void DrawOutlineObject(OpenGL gl) { }

        public void UpdateOutLine(OpenGL gl)
        {
            if (this.isChoose)
            {
                //setup width and color.
                gl.LineWidth(3f);

                //setup black color for soild object.
                //setup color.
                Color orange = Color.Orange;
                gl.Color(orange.R, orange.G, orange.B);
            }
            else
            {
                //setup width and color.
                gl.LineWidth(1f);

                //setup black color for soild object.

                //setup color.
                gl.Color(linecolor.R, linecolor.G, linecolor.B);
            }
        }
        public void DrawSoildObject(OpenGL gl)
        {
            gl.PushMatrix();

            transformer.UpdateTransform(gl);

            DrawObject(gl);

            UpdateOutLine(gl);

            DrawOutlineObject(gl);

            gl.PopMatrix();
        }
        ~Object() { }


    }
}
