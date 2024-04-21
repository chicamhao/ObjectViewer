using SharpGL;
using System;
using ObjectBuilder.ObjectBuilder;

namespace ObjectBuilder
{
    class Prism : Object
    {
        public Prism() : base()
        {
            //vertices's coordinates x, y, z
            _mVertices = new double[6, 3]
            {
                //above triangle
                {0.5f, 0.5f, 0.0f},
                { Math.Cos(2 * Constants.PI / 3)*0.5f, 0.5f, Math.Sin(2 * Constants.PI / 3) * 0.5f},
                { Math.Cos(4 * Constants.PI / 3)*0.5f, 0.5f, Math.Sin(4 * Constants.PI / 3) * 0.5f},

                //bottom triangle
                {0.5f, -0.5f, 0.0f},
                { Math.Cos(2 * Constants.PI / 3)*0.5f, -0.5f, Math.Sin(2 * Constants.PI / 3) * 0.5f},
                { Math.Cos(4 * Constants.PI / 3)*0.5f, -0.5f, Math.Sin(4 * Constants.PI / 3) * 0.5f},
            };

            //line vertice's indices.
            _indicesOutLine = new int[9, 2]{
                //above triangle
                {0, 2},
                {0, 1},
                {1, 2},

                {2, 5},
                {5, 4},
                {4, 1},
                {4, 3},
                {3, 5},
                {3, 0}                                          
            };
        }

        //ref: https://stackoverflow.com/questions/33606951/opengl-cube-using-a-for-loop
        public override void DrawObject(OpenGL gl)
        {
            //setup color.
            gl.Color(_color.R, _color.G, _color.B);

            //enable texture state and bind texture object to the path.
            if (_texturePath != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                _texture.Create(gl, _texturePath);
                _texture.Bind(gl);
            }
            //------------------------------------------------------------------------------------------------------------------------------------------
            //DRAW TRIANGLES
            
            //TOP
            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.TexCoord(0.5f, 1.0f);  gl.Vertex(_mVertices[0, 0], _mVertices[0, 1], _mVertices[0, 2]);
            gl.TexCoord(0.0f, 0.0f);  gl.Vertex(_mVertices[1, 0], _mVertices[1, 1], _mVertices[1, 2]);
            gl.TexCoord(1.0f, 0.0f);  gl.Vertex(_mVertices[2, 0], _mVertices[2, 1], _mVertices[2, 2]);

            //BOTTOM
            gl.TexCoord(0.5f, 1.0f);  gl.Vertex(_mVertices[3, 0], _mVertices[3, 1], _mVertices[3, 2]);
            gl.TexCoord(0.0f, 0.0f);  gl.Vertex(_mVertices[4, 0], _mVertices[4, 1], _mVertices[4, 2]);
            gl.TexCoord(1.0f, 0.0f);  gl.Vertex(_mVertices[5, 0], _mVertices[5, 1], _mVertices[5, 2]);


            gl.End();

            //------------------------------------------------------------------------------------------------------------------------------------------
            //DRAW RECTANGLES

            //LEFT RECTANGLES
            gl.Begin(OpenGL.GL_POLYGON);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(_mVertices[0, 0], _mVertices[0, 1], _mVertices[0, 2]);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(_mVertices[3, 0], _mVertices[3, 1], _mVertices[3, 2]);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(_mVertices[4, 0], _mVertices[4, 1], _mVertices[4, 2]);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(_mVertices[1, 0], _mVertices[1, 1], _mVertices[1, 2]);
            gl.End();

            //RIGHT RECTANGLES
            gl.Begin(OpenGL.GL_POLYGON);
            gl.TexCoord(0.0f, 1.0f);  gl.Vertex(_mVertices[0, 0], _mVertices[0, 1], _mVertices[0, 2]);
            gl.TexCoord(0.0f, 0.0f);  gl.Vertex(_mVertices[3, 0], _mVertices[3, 1], _mVertices[3, 2]);
            gl.TexCoord(1.0f, 0.0f);  gl.Vertex(_mVertices[5, 0], _mVertices[5, 1], _mVertices[5, 2]);
            gl.TexCoord(1.0f, 1.0f);  gl.Vertex(_mVertices[2, 0], _mVertices[2, 1], _mVertices[2, 2]);
            gl.End();

            //FRONT RECTANGLES
            gl.Begin(OpenGL.GL_POLYGON);
            gl.TexCoord(0.0f, 1.0f);  gl.Vertex(_mVertices[2, 0], _mVertices[2, 1], _mVertices[2, 2]);
            gl.TexCoord(0.0f, 0.0f);  gl.Vertex(_mVertices[5, 0], _mVertices[5, 1], _mVertices[5, 2]);
            gl.TexCoord(1.0f, 0.0f);  gl.Vertex(_mVertices[4, 0], _mVertices[4, 1], _mVertices[4, 2]);
            gl.TexCoord(1.0f, 1.0f);  gl.Vertex(_mVertices[1, 0], _mVertices[1, 1], _mVertices[1, 2]);
            gl.End();
            //------------------------------------------------------------------------------------------------------------------------------------------

            //disable texture state 
            if (_texturePath != null)
            {
                _texture.Destroy(gl);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        public override void DrawOutlineObject(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 9; i += 1)
            {
                gl.Vertex(_mVertices[_indicesOutLine[i, 0], 0], _mVertices[_indicesOutLine[i, 0], 1], _mVertices[_indicesOutLine[i, 0], 2]);
                gl.Vertex(_mVertices[_indicesOutLine[i, 1], 0], _mVertices[_indicesOutLine[i, 1], 1], _mVertices[_indicesOutLine[i, 1], 2]);
            }
            gl.End();
        }

    }
}
