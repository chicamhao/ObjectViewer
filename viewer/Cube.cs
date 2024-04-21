using ObjectBuilder.ObjectBuilder;
using SharpGL;

namespace ObjectBuilder
{
    public sealed class Cube : Object
    {
        public Cube() : base()
        {
            // vertices's coordinates x, y, z
            _mVertices = new double[8, 3]
            {
                // bottom vertices of a cube
                { -0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit },
                { -0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit },
                { 0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit },
                { 0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit },

                // above vertices of a cube
                { -0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit },
                { -0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit},
                { 0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit },
                { 0.5f * Constants.WorldUnit, 0.5f * Constants.WorldUnit, -0.5f * Constants.WorldUnit },
            };

            _mTextures = new double[4, 2] {
                {0f, 0f},    
                {0f, 1f * Constants.WorldUnit},    
                {1f * Constants.WorldUnit, 1f * Constants.WorldUnit},    
                {1f * Constants.WorldUnit, 0f}     
            };
            _indicesObject = new int[6, 4]
            {
                {0, 1, 2, 3}, //bottom
                {4, 5, 6, 7}, //top
                {4, 0, 1, 5}, //left
                {5, 1, 2, 6}, //front
                {6, 2, 3, 7}, //right
                {7, 3, 0, 4}, //back
            };

            _indicesOutLine = new int[12, 2]
            {
                {0,1},
                {1,2},

                {2,3},
                {3,0},

                {0,4},
                {4,5},

                {5,1},
                {5,6},

                {6,2},
                {6,7},

                {7,3},
                {7,4},
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

            //draw each faces of the cube.
            gl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 6; i ++)
            {
                gl.TexCoord(_mTextures[0, 0], _mTextures[0, 1]);  gl.Vertex(_mVertices[_indicesObject[i, 0], 0], _mVertices[_indicesObject[i, 0], 1], _mVertices[_indicesObject[i, 0], 2]);
                gl.TexCoord(_mTextures[1, 0], _mTextures[1, 1]);  gl.Vertex(_mVertices[_indicesObject[i, 1], 0], _mVertices[_indicesObject[i, 1], 1], _mVertices[_indicesObject[i, 1], 2]);
                gl.TexCoord(_mTextures[2, 0], _mTextures[2, 1]);  gl.Vertex(_mVertices[_indicesObject[i, 2], 0], _mVertices[_indicesObject[i, 2], 1], _mVertices[_indicesObject[i, 2], 2]);
                gl.TexCoord(_mTextures[3, 0], _mTextures[3, 1]);  gl.Vertex(_mVertices[_indicesObject[i, 3], 0], _mVertices[_indicesObject[i, 3], 1], _mVertices[_indicesObject[i, 3], 2]); 
            }
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
            for (int i = 0; i < 12; i++)
            {
                gl.Vertex(_mVertices[_indicesOutLine[i, 0], 0], _mVertices[_indicesOutLine[i, 0], 1], _mVertices[_indicesOutLine[i, 0], 2]);
                gl.Vertex(_mVertices[_indicesOutLine[i, 1], 0], _mVertices[_indicesOutLine[i, 1], 1], _mVertices[_indicesOutLine[i, 1], 2]);
            }
            gl.End();
        }
    }
}
