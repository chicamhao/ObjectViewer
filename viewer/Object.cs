using ObjectBuilder.ObjectBuilder;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;

namespace ObjectBuilder
{
    public class Object
    {
        //vertices's coordinates x, y, z
        protected double[,] _mVertices;

        //vertice's indices.
        protected int[,] _indicesObject;
        protected int[,] _indicesOutLine;

        protected Color _color;
        protected Color _lineColor;

        protected Transformer _transformer;
        protected double _unit;

        //texture
        protected double[,] _mTextures;
        protected Texture _texture;
        protected string _texturePath;

        protected bool _isChoosed;

        //properties
        public string TexturePath
        {
            get => _texturePath;
            set { _texturePath = value; }
        }

        public bool IsChoosed
        {
            get => _isChoosed;
            set { _isChoosed = value; }
        }

        public Transformer Transform
        {
            get => _transformer;
            set { _transformer = value; }
        }

        public Color Color
        {
            get => _color;
            set { _color = value;  }
        }

        public Texture Texture
        {
            get => _texture;
            set { _texture = value; }
        }

        public Object()
        {
            _color = Color.White;
            _lineColor = Color.Black;

            _transformer = new Transformer();
            _texture = new Texture();
            _unit = Constants.WorldUnit;
        }
        
        //method
        public virtual void DrawObject(OpenGL gl) { }

        public virtual void DrawOutlineObject(OpenGL gl) { }

        public void UpdateOutLine(OpenGL gl)
        {
            if (_isChoosed)
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
                gl.Color(_lineColor.R, _lineColor.G, _lineColor.B);
            }
        }

        public void DrawSoildObject(OpenGL gl)
        {
            gl.PushMatrix();

            _transformer.UpdateTransform(gl);

            DrawObject(gl);

            UpdateOutLine(gl);

            DrawOutlineObject(gl);

            gl.PopMatrix();
        }

        ~Object() { }
    }
}
