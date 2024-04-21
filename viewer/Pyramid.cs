using SharpGL;

namespace ObjectBuilder
{
    public sealed class Pyramid : Object
    {
        public Pyramid() : base()
        {
            //vertices's coordinates x, y, z
            _mVertices = new double[5, 3]
            {
                // Bottom vertices of pyramid
                { -0.5, -0.5, -0.5 },
                { -0.5, -0.5, 0.5 },
                { 0.5, -0.5, 0.5 },
                { 0.5, -0.5, -0.5 },

                // top vertex
                { 0, 0.5, 0 },
            };

            _mTextures = new double[3, 2]
            {
                { 0.0, 0.0 }, // Lower-left corner
                { 1.0, 0.0 }, // Lower-right corner
                { 0.5, 1.0 } // Top-center corner
            };

            _indicesObject = new int[4, 3]
            {
                {0, 1, 4}, //right triangle
                {3, 0, 4}, //back triangle
                {2, 3, 4}, //left triangle
                {1, 2, 4}, //front triangle
            };

            _indicesOutLine = new int[8, 2]
            {
                //bottom edges
                {0, 1},
                {1, 2},

                {2, 3},
                {3, 0},

                //side edges
                {0, 4},
                {1, 4},

                {2, 4},
                {3, 4},
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

            //draw each triangle faces of the pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i < 4; i++)
            {
                gl.TexCoord(_mTextures[0, 0], _mTextures[0, 1]); gl.Vertex(_mVertices[_indicesObject[i, 0], 0], _mVertices[_indicesObject[i, 0], 1], _mVertices[_indicesObject[i, 0], 2]);
                gl.TexCoord(_mTextures[1, 0], _mTextures[1, 1]); gl.Vertex(_mVertices[_indicesObject[i, 1], 0], _mVertices[_indicesObject[i, 1], 1], _mVertices[_indicesObject[i, 1], 2]);
                gl.TexCoord(_mTextures[2, 0], _mTextures[2, 1]); gl.Vertex(_mVertices[_indicesObject[i, 2], 0], _mVertices[_indicesObject[i, 2], 1], _mVertices[_indicesObject[i, 2], 2]);
            }
            gl.End();

            //draw bottom face
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0f);     gl.Vertex(_mVertices[0, 0], _mVertices[0, 1], _mVertices[0, 2]);
            gl.TexCoord(1f ,0f);    gl.Vertex(_mVertices[1, 0], _mVertices[1, 1], _mVertices[1, 2]);
            gl.TexCoord(1f, 1f);    gl.Vertex(_mVertices[2, 0], _mVertices[2, 1], _mVertices[2, 2]);
            gl.TexCoord(0f, 1f);    gl.Vertex(_mVertices[3, 0], _mVertices[3, 1], _mVertices[3, 2]);
            gl.End();

            //disable texture state 
            if (_texturePath != null)
            {
                _texture.Destroy(gl);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        public override void DrawOutlineObject(OpenGL gl)
        {
            //draw line
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 8; i++)
            {
                gl.Vertex(_mVertices[_indicesOutLine[i, 0], 0], _mVertices[_indicesOutLine[i, 0], 1], _mVertices[_indicesOutLine[i, 0], 2]);
                gl.Vertex(_mVertices[_indicesOutLine[i, 1], 0], _mVertices[_indicesOutLine[i, 1], 1], _mVertices[_indicesOutLine[i, 1], 2]);
            }
            gl.End();
        }
    }
}
